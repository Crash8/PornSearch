using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using AngleSharp;
using AngleSharp.Dom;

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
            IDocument document = content != null ? await ConvertToDocumentAsync(content) : null;
            IPornSearchParser searchParser = document != null ? GetSearchParser(document) : null;
            return searchParser == null || !searchParser.IsAvailableContent() || IsBeyondLastPageContent(searchParser, searchFilter)
                ? new List<PornVideoThumb>()
                : searchParser.GetVideoThumbs()
                              .Where(p => p.IsAvailable())
                              .Select(p => new PornVideoThumb {
                                          Website = p.Website(),
                                          SexOrientation = searchFilter.SexOrientation,
                                          IsFreePremium = p.IsFreePremium(),
                                          Id = p.Id(),
                                          Title = p.Title(),
                                          Channel = p.Channel(),
                                          ThumbnailUrl = p.ThumbnailUrl(),
                                          PageUrl = p.PageUrl()
                                      })
                              .ToList();
        }

        protected abstract string MakeUrl(PornSearchFilter searchFilter);

        protected virtual async Task<string> GetPageContentAsync(string url) {
            return await GetHtmlContentWithCookieAsync(url, null);
        }

        protected abstract IPornSearchParser GetSearchParser(IDocument document);

        private static bool IsBeyondLastPageContent(IPornSearchParser searchParser, PornSearchFilter searchFilter) {
            if (searchParser.IsAvailablePagination()) {
                if (searchParser.IsAvailableNextButton())
                    return false;
                int? pageActive = searchParser.GetCurrentPageNumber();
                return pageActive == null || searchFilter.Page > pageActive.Value;
            }
            return searchFilter.Page > 1;
        }

        protected async Task<string> GetHtmlContentWithCookieAsync(string url, string cookie) {
            await WaitIfError429FromUrlAsync(url);
            string acceptLanguage = GetHttpHeaderAcceptLanguage();
            using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url)) {
                request.Headers.Add("User-Agent", GetHttpHeaderUserAgent());
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

        protected virtual string GetHttpHeaderUserAgent() {
            return "PornSearch/1.0";
        }

        public abstract PornSourceVideo GetSourceVideo(string url);

        public async Task<PornVideo> GetVideoByIdAsync(string videoId) {
            string url = MakeUrlVideo(videoId);
            string content = await GetPageContentAsync(url);
            IDocument document = content != null ? await ConvertToDocumentAsync(content) : null;
            IPornVideoParser videoParser = document != null ? GetVideoParser(document) : null;
            PornVideo video = !videoParser?.IsAvailable() ?? true
                ? null
                : new PornVideo {
                    Website = videoParser.Website(),
                    SexOrientation = videoParser.SexOrientation(),
                    IsFreePremium = videoParser.IsFreePremium(),
                    Id = videoParser.Id(),
                    Title = videoParser.Title(),
                    Channel = videoParser.Channel(),
                    ThumbnailUrl = videoParser.ThumbnailUrl(),
                    SmallThumbnailUrl = videoParser.SmallThumbnailUrl(),
                    PageUrl = videoParser.PageUrl(),
                    VideoEmbedUrl = videoParser.VideoEmbedUrl(),
                    Duration = videoParser.Duration(),
                    Categories = videoParser.Categories(),
                    Tags = videoParser.Tags(),
                    Actors = videoParser.Actors(),
                    NbViews = videoParser.NbViews(),
                    NbLikes = videoParser.NbLikes(),
                    NbDislikes = videoParser.NbDislikes(),
                    Date = videoParser.Date(),
                    RelatedVideos = videoParser.RelatedVideos()
                };
            return video;
        }

        private static async Task<IDocument> ConvertToDocumentAsync(string content) {
            IConfiguration config = Configuration.Default;
            IBrowsingContext context = BrowsingContext.New(config);
            return await context.OpenAsync(req => req.Content(content));
        }

        protected abstract IPornVideoParser GetVideoParser(IDocument document);

        protected abstract string MakeUrlVideo(string videoId);
    }
}
