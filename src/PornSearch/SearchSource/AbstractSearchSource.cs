using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace PornSearch
{
    public abstract class AbstractSearchSource : IPornSearchSource
    {
        private static readonly HttpClient HttpClient = new HttpClient();
        private static ConcurrentDictionary<string, SemaphoreSlim> _semaphore = new ConcurrentDictionary<string, SemaphoreSlim>();

        public abstract List<PornSexOrientation> GetSexOrientations();

        public async Task<List<PornItemThumb>> SearchAsync(PornSearchFilter searchFilter) {
            if (searchFilter == null)
                throw new ArgumentNullException(nameof(searchFilter));
            if (searchFilter.Page <= 0)
                throw new ArgumentException("Value greater than zero", nameof(searchFilter.Page));
            if (!GetSexOrientations().Contains(searchFilter.SexOrientation))
                return null;
            string url = MakeUrl(searchFilter);
            string content = await GetPageContentAsync(url);
            return IsContentNotFound(content) || IsBeyondLastPageContent(content, searchFilter)
                ? new List<PornItemThumb>()
                : ExtractItemThumbs(content, searchFilter.SexOrientation);
        }

        protected abstract string MakeUrl(PornSearchFilter searchFilter);

        protected virtual async Task<string> GetPageContentAsync(string url) {
            return await GetHtmlContentAsync(url);
        }

        private static async Task<string> GetHtmlContentAsync(string url) {
            return await GetHtmlContentWithCookieAsync(url, null);
        }

        protected virtual bool IsContentNotFound(string content) {
            return content == "404";
        }

        protected virtual bool IsBeyondLastPageContent(string content, PornSearchFilter searchFilter) {
            return false;
        }

        protected static async Task<string> GetHtmlContentWithCookieAsync(string url, string cookie) {
            WaitBeforeSendFromUrl(url);
            using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url)) {
                request.Headers.Add("User-Agent", "PornSearch/1.0");
                request.Headers.Add("Referer", url);
                request.Headers.Add("Cookie", cookie);
                using (HttpResponseMessage response = await HttpClient.SendAsync(request)) {
                    if (response.IsSuccessStatusCode)
                        return await response.Content.ReadAsStringAsync();
                    if (response.StatusCode == HttpStatusCode.NotFound)
                        return "404";
                    if ((int)response.StatusCode == 429) {
                        await WaitFromUrlAsync(url, 30000);
                        return await GetHtmlContentWithCookieAsync(url, cookie);
                    }
                    HttpRequestException exception = new HttpRequestException(response.ReasonPhrase);
                    exception.Data.Add("StatusCode", response.StatusCode);
                    throw exception;
                }
            }
        }

        private static void WaitBeforeSendFromUrl(string url) {
            SemaphoreSlim semaphoreSlim = GetSemaphoreFromUrl(url);
            semaphoreSlim.Wait();
            semaphoreSlim.Release();
        }

        private static SemaphoreSlim GetSemaphoreFromUrl(string url) {
            string key = GetSemaphoreKeyFromUrl(url);
            if (!_semaphore.ContainsKey(key))
                _semaphore.TryAdd(key, new SemaphoreSlim(1));
            return _semaphore[key];
        }

        private static string GetSemaphoreKeyFromUrl(string url) {
            Match match = Regex.Match(url, "(http(s)?://.*?)(/|[?]|$)");
            return match.Groups[1].Value.ToLower();
        }

        private static async Task WaitFromUrlAsync(string url, int delay) {
            SemaphoreSlim semaphoreSlim = GetSemaphoreFromUrl(url);
            await semaphoreSlim.WaitAsync();
            await Task.Delay(delay);
            semaphoreSlim.Release();
        }

        protected abstract List<PornItemThumb> ExtractItemThumbs(string content, PornSexOrientation searchFilterSexOrientation);
    }
}
