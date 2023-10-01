using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngleSharp;
using AngleSharp.Dom;

namespace PornSearch
{
    internal abstract class AbstractSearchWebsite : IPornSearchWebsite
    {
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
            PornHttpClient httpClient = new PornHttpClient();
            httpClient.SetHeaderCookie(cookie);
            httpClient.SetHeaderAcceptLanguage(GetHttpHeaderAcceptLanguage());
            return await httpClient.SendAsync(url);
        }

        protected virtual string GetHttpHeaderAcceptLanguage() {
            return null;
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
        
        public abstract Task<bool> CheckIfCanVideoEmbedInIframeAsync(PornVideo video);
    }
}
