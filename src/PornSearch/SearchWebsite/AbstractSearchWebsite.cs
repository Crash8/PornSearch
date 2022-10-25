using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace PornSearch
{
    internal abstract class AbstractSearchWebsite : IPornSearchWebsite
    {
        private static readonly HttpClient HttpClient;
        private static readonly ConcurrentDictionary<string, SemaphoreSlim> Semaphore;

        static AbstractSearchWebsite() {
            HttpClient = new HttpClient();
            Semaphore = new ConcurrentDictionary<string, SemaphoreSlim>();
        }

        public abstract List<PornSexOrientation> GetSexOrientations();

        public async Task<List<PornVideoThumb>> SearchAsync(PornSearchFilter searchFilter) {
            if (searchFilter.Page <= 0)
                throw new ArgumentException("Value greater than zero", nameof(searchFilter.Page));
            if (!GetSexOrientations().Contains(searchFilter.SexOrientation))
                return null;
            string url = MakeUrl(searchFilter);
            string content = await GetPageContentAsync(url);
            return content == null || IsContentNotFound(content) || IsBeyondLastPageContent(content, searchFilter)
                ? new List<PornVideoThumb>()
                : ExtractVideoThumbs(content, searchFilter);
        }

        protected abstract string MakeUrl(PornSearchFilter searchFilter);

        protected virtual async Task<string> GetPageContentAsync(string url) {
            return await GetHtmlContentWithCookieAsync(url, null);
        }

        protected abstract bool IsContentNotFound(string content);

        private bool IsBeyondLastPageContent(string content, PornSearchFilter searchFilter) {
            string contentPagination = GetContentPaginationInContent(content);
            if (!string.IsNullOrWhiteSpace(contentPagination)) {
                if (IsNextButtonInContentPagination(contentPagination))
                    return false;
                int? pageActive = GetPageActiveInContentPagination(contentPagination);
                return pageActive == null || searchFilter.Page > pageActive.Value;
            }
            return searchFilter.Page > 1;
        }

        protected abstract string GetContentPaginationInContent(string content);

        protected abstract bool IsNextButtonInContentPagination(string contentPagination);

        protected abstract int? GetPageActiveInContentPagination(string contentPagination);

        protected async Task<string> GetHtmlContentWithCookieAsync(string url, string cookie) {
            await WaitIfError429FromUrlAsync(url);
            string acceptLanguage = GetHttpHeaderAcceptLanguage();
            using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url)) {
                request.Headers.Add("User-Agent", "PornSearch/1.0");
                request.Headers.Add("Referer", url);
                request.Headers.Add("Cookie", cookie);
                if (!string.IsNullOrEmpty(acceptLanguage))
                    request.Headers.Add("Accept-Language", acceptLanguage);
                using (HttpResponseMessage response = await HttpClient.SendAsync(request)) {
                    if (response.IsSuccessStatusCode)
                        return await response.Content.ReadAsStringAsync();
                    if (response.StatusCode == HttpStatusCode.NotFound)
                        return null;
                    if ((int)response.StatusCode == 429) {
                        await WaitDelayFromUrlAsync(url, 30000);
                        return await GetHtmlContentWithCookieAsync(url, cookie);
                    }
                    HttpRequestException exception = new HttpRequestException(response.ReasonPhrase);
                    exception.Data.Add("StatusCode", response.StatusCode);
                    throw exception;
                }
            }
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

        protected virtual string GetHttpHeaderAcceptLanguage() {
            return null;
        }

        protected abstract List<PornVideoThumb> ExtractVideoThumbs(string content, PornSearchFilter searchFilter);

        protected static string HtmlDecode(string htmlText) {
            return HTML5Decode.Utility.HtmlDecode(htmlText).Replace("\u00A0", " ").Trim();
        }

        public abstract PornSourceVideo GetSourceVideo(string url);

        public async Task<PornVideo> GetVideoByIdAsync(string videoId) {
            string url = MakeUrlVideo(videoId);
            string content = await GetPageContentAsync(url);
            return content == null || IsVideoContentNotFound(content) ? null : ExtractVideo(content);
        }

        protected abstract string MakeUrlVideo(string videoId);

        protected abstract bool IsVideoContentNotFound(string content);

        protected abstract PornVideo ExtractVideo(string content);

        protected static int ConvertToInt(string number) {
            if (string.IsNullOrEmpty(number))
                return 0;
            if (number.EndsWith("k", StringComparison.OrdinalIgnoreCase))
                return (int)(Convert.ToSingle(number.Substring(0, number.Length - 1)) * 1000);
            if (number.EndsWith("m", StringComparison.OrdinalIgnoreCase))
                return (int)(Convert.ToSingle(number.Substring(0, number.Length - 1)) * 1000 * 1000);
            return Convert.ToInt32(number.Replace(",", "").Replace(".", "").Replace(" ", ""));
        }

        protected static string ToTitleCase(string text) {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text);
        }
    }
}
