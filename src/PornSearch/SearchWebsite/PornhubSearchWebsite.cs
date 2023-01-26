using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using Jint;

namespace PornSearch
{
    internal class PornhubSearchWebsite : AbstractSearchWebsite
    {
        private string _cookie;

        public override List<PornSexOrientation> GetSexOrientations() {
            return new List<PornSexOrientation> {
                PornSexOrientation.Straight,
                PornSexOrientation.Gay
            };
        }

        protected override string MakeUrl(PornSearchFilter searchFilter) {
            string url = $"https://www.pornhub.com{(searchFilter.SexOrientation == PornSexOrientation.Gay ? "/gay" : "")}/video";
            if (!string.IsNullOrWhiteSpace(searchFilter.Filter))
                url += "/search";
            List<string> queries = new List<string>();
            if (!string.IsNullOrWhiteSpace(searchFilter.Filter))
                queries.Add("search=" + string.Join("+", searchFilter.Filter.Split(' ').Select(Uri.EscapeDataString)).ToLower());
            if (searchFilter.Page > 1)
                queries.Add("page=" + searchFilter.Page);
            string query = string.Join("&", queries);
            if (!string.IsNullOrEmpty(query))
                url += "?" + query;
            return url;
        }

        protected override async Task<string> GetPageContentAsync(string url) {
            string content = await GetHtmlContentWithCookieAsync(url, _cookie);
            bool hasNeedCookie = content != null && Regex.IsMatch(content, "Loading[.]{3}");
            if (hasNeedCookie) {
                _cookie = GetCookie(content);
                content = await GetPageContentAsync(url);
            }
            return content;
        }

        private static string GetCookie(string content) {
            content = content.Substring(content.IndexOf("function leastFactor", StringComparison.Ordinal));
            content = content.Substring(0, content.IndexOf("//-->", StringComparison.Ordinal));
            content = content.Replace("document.cookie=", "return ");
            return new Engine().Execute(content).GetValue("go").Invoke().ToString();
        }

        protected override string GetContentPaginationInContent(string content) {
            int startIndex = content.IndexOf("<div class=\"pagination3", StringComparison.Ordinal);
            if (startIndex > 0) {
                int endIndex = content.IndexOf("</ul>", startIndex, StringComparison.Ordinal);
                return content.Substring(startIndex, endIndex - startIndex);
            }
            return null;
        }

        protected override bool IsNextButtonInContentPagination(string contentPagination) {
            return contentPagination.IndexOf("class=\"page_next\"", StringComparison.Ordinal) > -1;
        }

        protected override int? GetPageActiveInContentPagination(string contentPagination) {
            Match matchPageActive = Regex.Match(contentPagination, "<li class=\"page_current[^<]*[^>]*>([^<]*)</span>");
            return matchPageActive.Success ? (int?)Convert.ToInt32(matchPageActive.Groups[1].Value) : null;
        }

        protected override bool IsContentNotFound(string content) {
            return content.IndexOf("<div class=\"noResultsWrapper\">", StringComparison.Ordinal) > 0;
        }

        protected override string GetHttpHeaderAcceptLanguage() {
            return "en";
        }

        protected override async Task<List<PornVideoThumb>> ExtractVideoThumbsAsync(string content, PornSearchFilter searchFilter) {
            IDocument document = await ConvertToDocumentAsync(content);
            const string selector = "ul#videoSearchResult > li.pcVideoListItem, ul#videoCategory > li.pcVideoListItem";
            IEnumerable<IHtmlListItemElement> elements = document.QuerySelectorAll<IHtmlListItemElement>(selector);
            return elements.Select(li => new PornhubVideoThumbParser(li))
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

        public override PornSourceVideo GetSourceVideo(string url) {
            const string pattern = "^https://[a-z]{2,3}[.]pornhub[.]com/view_video[.]php[?]viewkey=([^\\s]+)$";
            Match match = Regex.Match(url, pattern);
            return !match.Success
                ? null
                : new PornSourceVideo {
                    Id = match.Groups[1].Value,
                    Website = PornWebsite.Pornhub
                };
        }

        protected override string MakeUrlVideo(string videoId) {
            return $"https://www.pornhub.com/view_video.php?viewkey={videoId}";
        }

        protected override bool IsVideoContentNotFound(string content) {
            return content.IndexOf("<div class=\"geoBlocked\">", StringComparison.Ordinal) > 0
                   || content.IndexOf("<section class=\"noVideo\">", StringComparison.Ordinal) > 0
                   || content.IndexOf("<div class=\"removed\">", StringComparison.Ordinal) > 0;
        }

        protected override async Task<PornVideo> ExtractVideoAsync(string content) {
            IDocument document = await ConvertToDocumentAsync(content);
            IPornVideoParser videoParser = new PornhubVideoParser(document);
            PornVideo video = new PornVideo {
                Website = videoParser.Website(),
                SexOrientation = videoParser.SexOrientation(),
                Id = videoParser.Id(),
                Title = videoParser.Title(),
                Channel = videoParser.Channel(),
                ThumbnailUrl = videoParser.ThumbnailUrl(),
                SmallThumbnailUrl = videoParser.SmallThumbnailUrl(),
                PageUrl = videoParser.PageUrl(),
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
    }
}
