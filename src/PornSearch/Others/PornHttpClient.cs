using System;
using System.Collections.Concurrent;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace PornSearch
{
    internal sealed class PornHttpClient
    {
        private static readonly HttpClient HttpClient = new HttpClient();
        private static readonly ConcurrentDictionary<string, SemaphoreSlim> Semaphore = new ConcurrentDictionary<string, SemaphoreSlim>();
        private string _cookie;
        private string _acceptLanguage;

        private class TrySendException : Exception
        {
            public TrySendException(Exception innerException) : base(null, innerException) { }
        }

        public void SetHeaderCookie(string cookie) {
            _cookie = cookie;
        }

        public void SetHeaderAcceptLanguage(string acceptLanguage) {
            _acceptLanguage = acceptLanguage;
        }

        public async Task<string> SendAsync(string url) {
            int tryCount = 0;
            while (true) {
                try {
                    return await TrySendAsync(url);
                }
                catch (TrySendException ex) {
                    tryCount++;
                    if (tryCount >= 4)
                        throw ex.InnerException ?? new Exception("Http Error");
                    await WaitDelayFromUrlAsync(url, 10000);
                }
            }
        }

        private async Task<string> TrySendAsync(string url) {
            await WaitIfError429FromUrlAsync(url);
            using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url)) {
                request.Headers.Add("User-Agent", GetHttpHeaderUserAgent());
                request.Headers.Add("Referer", url);
                if (!string.IsNullOrEmpty(_cookie))
                    request.Headers.Add("Cookie", _cookie);
                if (!string.IsNullOrEmpty(_acceptLanguage))
                    request.Headers.Add("Accept-Language", _acceptLanguage);
                using (HttpResponseMessage response = await HttpClientSendAsync(request)) {
                    if (response.IsSuccessStatusCode)
                        return await response.Content.ReadAsStringAsync();
                    if (response.StatusCode == HttpStatusCode.NotFound || response.StatusCode == HttpStatusCode.Forbidden)
                        return null;
                    if ((int)response.StatusCode == 429) {
                        await WaitDelayFromUrlAsync(url, 30000);
                        throw new TrySendException(GetHttpRequestException(response.ReasonPhrase, response.StatusCode));
                    }
                    throw GetHttpRequestException(response.ReasonPhrase, response.StatusCode);
                }
            }
        }

        private static HttpRequestException GetHttpRequestException(string message, HttpStatusCode statusCode) {
            HttpRequestException exception = new HttpRequestException(message);
            exception.Data.Add("StatusCode", statusCode);
            return exception;
        }

        private static async Task WaitIfError429FromUrlAsync(string url) {
            await WaitDelayFromUrlAsync(url, 0);
        }

        private static async Task WaitDelayFromUrlAsync(string url, int delay) {
            SemaphoreSlim semaphoreSlim = GetSemaphoreFromUrl(url);
            await semaphoreSlim.WaitAsync();
            if (delay > 0)
                await Task.Delay(delay);
            semaphoreSlim.Release();
        }

        private static SemaphoreSlim GetSemaphoreFromUrl(string url) {
            string key = GetSemaphoreKeyFromUrl(url);
            if (!Semaphore.ContainsKey(key))
                Semaphore.TryAdd(key, new SemaphoreSlim(1));
            return Semaphore[key];
        }

        private static string GetSemaphoreKeyFromUrl(string url) {
            Match match = Regex.Match(url, "(http(s)?://.*?)(/|[?]|$)");
            return match.Groups[1].Value.ToLower();
        }

        private static string GetHttpHeaderUserAgent() {
            return "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_14_6) AppleWebKit/537.36 (KHTML, like Gecko) "
                   + "Chrome/109.0.0.0 Safari/537.36 Edg/109.0.1518.70";
        }

        private static async Task<HttpResponseMessage> HttpClientSendAsync(HttpRequestMessage request) {
            try {
                return await HttpClient.SendAsync(request);
            }
            catch (Exception ex) {
                throw new TrySendException(ex);
            }
        }
    }
}
