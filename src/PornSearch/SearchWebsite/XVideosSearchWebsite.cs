using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace PornSearch
{
    internal class XVideosSearchWebsite : AbstractSearchWebsite
    {
        private const string RegExVideoThumb =
            "<div.*class=\"thumb-block.*<img.*?data-src=\"(.*?)\".*?<a href=\"(/video.*?)\" title=\"(.*?)\".*<a href=\"(.*?)\">"
            + "<span.*?>(.*?)<";

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

        protected override List<PornVideoThumb> ExtractVideoThumbs(string content, PornSearchFilter searchFilter) {
            int startIndex = content.IndexOf("<div class=\"mozaique", StringComparison.Ordinal);
            int endIndex = content.IndexOf("<div id=\"footer", startIndex, StringComparison.Ordinal);
            string contentItems = content.Substring(startIndex, endIndex - startIndex);
            return Regex.Matches(contentItems, RegExVideoThumb)
                        .Cast<Match>()
                        .Select(m => new PornVideoThumb {
                                    Website = searchFilter.Website,
                                    SexOrientation = searchFilter.SexOrientation,
                                    Id = m.Groups[2].Value.Replace("/THUMBNUM", ""),
                                    Title = HtmlDecode(m.Groups[3].Value),
                                    Channel = new PornIdName {
                                        Id = m.Groups[4].Value,
                                        Name = HtmlDecode(m.Groups[5].Value)
                                    },
                                    ThumbnailUrl = m.Groups[1].Value.Replace("THUMBNUM", "1"),
                                    PageUrl = $"https://www.xvideos.com{m.Groups[2].Value.Replace("/THUMBNUM", "")}"
                                })
                        .ToList();
        }
    }
}
