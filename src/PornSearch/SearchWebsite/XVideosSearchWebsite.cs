using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AngleSharp.Dom;
using AngleSharp.Html.Dom;

namespace PornSearch
{
    internal class XVideosSearchWebsite : AbstractSearchWebsite
    {
        public override List<PornSexOrientation> GetSexOrientations() {
            return new List<PornSexOrientation> {
                PornSexOrientation.Straight,
                PornSexOrientation.Gay,
                PornSexOrientation.Trans
            };
        }

        protected override string MakeUrl(PornSearchFilter searchFilter) {
            string url = "https://www.xvideos.com";
            if (string.IsNullOrWhiteSpace(searchFilter.Filter)) {
                switch (searchFilter.SexOrientation) {
                    case PornSexOrientation.Straight: {
                        if (searchFilter.Page > 1)
                            url += "/new";
                        break;
                    }
                    case PornSexOrientation.Gay:
                        url += "/gay";
                        break;
                    case PornSexOrientation.Trans:
                        url += "/shemale";
                        break;
                    default: throw new ArgumentOutOfRangeException();
                }
                if (searchFilter.Page > 1)
                    url += $"/{searchFilter.Page - 1}";
            }
            else {
                string k = string.Join("+", searchFilter.Filter.Split(' ').Select(Uri.EscapeDataString)).ToLower();
                url += $"/?k={k}";
                switch (searchFilter.SexOrientation) {
                    case PornSexOrientation.Straight: {
                        url += "&typef=straight";
                        break;
                    }
                    case PornSexOrientation.Gay:
                        url += "&typef=gay";
                        break;
                    case PornSexOrientation.Trans:
                        url += "&typef=shemale";
                        break;
                    default: throw new ArgumentOutOfRangeException();
                }
                if (searchFilter.Page > 1)
                    url += $"&p={searchFilter.Page - 1}";
            }
            return url;
        }

        protected override bool IsContentNotFound(string content) {
            return content.IndexOf("<div class=\"mozaique", StringComparison.Ordinal) == -1;
        }

        protected override string GetContentPaginationInContent(string content) {
            int startIndex = content.IndexOf("<div class=\"pagination", StringComparison.Ordinal);
            if (startIndex > 0) {
                int endIndex = content.IndexOf("</ul>", startIndex, StringComparison.Ordinal);
                return content.Substring(startIndex, endIndex - startIndex);
            }
            return null;
        }

        protected override bool IsNextButtonInContentPagination(string contentPagination) {
            return contentPagination.IndexOf("class=\"no-page next-page\"", StringComparison.Ordinal) > -1;
        }

        protected override int? GetPageActiveInContentPagination(string contentPagination) {
            Match matchPageActive = Regex.Match(contentPagination, "<a class=\"active\" href=\"\">([^<]*)</a>");
            return Convert.ToInt32(matchPageActive.Groups[1].Value);
        }

        protected override async Task<List<PornVideoThumb>> ExtractVideoThumbsAsync(string content, PornSearchFilter searchFilter) {
            IDocument document = await ConvertToDocumentAsync(content);
            const string selector = "div.mozaique > div[data-id]";
            IEnumerable<IHtmlDivElement> elements = document.QuerySelectorAll<IHtmlDivElement>(selector);
            return elements.Select(div => new XVideosVideoThumbParser(div))
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
            const string pattern = "^https://www[.]xvideos[.]com/video([0-9]+)/[^\\s]+$";
            Match match = Regex.Match(url, pattern);
            return !match.Success
                ? null
                : new PornSourceVideo {
                    Id = match.Groups[1].Value,
                    Website = PornWebsite.XVideos
                };
        }

        protected override string MakeUrlVideo(string videoId) {
            return $"https://www.xvideos.com/video{videoId}/a";
        }

        protected override bool IsVideoContentNotFound(string content) {
            return false;
        }

        protected override async Task<PornVideo> ExtractVideoAsync(string content) {
            IDocument document = await ConvertToDocumentAsync(content);
            IPornVideoParser videoParser = new XVideosVideoParser(document);
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
