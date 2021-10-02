using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace PornSearch
{
    public class XVideosSearchSource : AbstractSearchSource
    {
        private const string RegExItemThumb =
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
            return content == "404" || content.IndexOf("<div class=\"mozaique", StringComparison.Ordinal) == -1;
        }

        protected override bool IsBeyondLastPageContent(string content, PornSearchFilter searchFilter) {
            int startIndex = content.IndexOf("<div class=\"pagination", StringComparison.Ordinal);
            if (startIndex > 0) {
                int endIndex = content.IndexOf("</ul>", startIndex, StringComparison.Ordinal);
                string contentPagination = content.Substring(startIndex, endIndex - startIndex);
                bool hasNextPage = contentPagination.IndexOf("class=\"no-page next-page\"", StringComparison.Ordinal) > -1;
                if (hasNextPage)
                    return false;
                Match matchPageActive = Regex.Match(content, "<a class=\"active\" href=\"\">([^<]*)</a>");
                return searchFilter.Page > Convert.ToInt32(matchPageActive.Groups[1].Value);
            }
            return searchFilter.Page > 1;
        }

        protected override List<PornItemThumb> ExtractItemThumbs(string content, PornSexOrientation sexOrientation) {
            if (content == null)
                throw new ArgumentNullException(nameof(content));
            int startIndex = content.IndexOf("<div class=\"mozaique", StringComparison.Ordinal);
            int endIndex = content.IndexOf("<div id=\"footer", startIndex, StringComparison.Ordinal);
            string contentItems = content.Substring(startIndex, endIndex - startIndex);
            return Regex.Matches(contentItems, RegExItemThumb)
                        .Cast<Match>()
                        .Select(m => new PornItemThumb {
                                    Source = PornSource.XVideos,
                                    SexOrientation = sexOrientation,
                                    Id = m.Groups[2].Value.Replace("/THUMBNUM", ""),
                                    Title = HttpUtility.HtmlDecode(m.Groups[3].Value).Replace("\u00A0", " "),
                                    Channel = new PornIdName {
                                        Id = m.Groups[4].Value,
                                        Name = HttpUtility.HtmlDecode(m.Groups[5].Value)
                                    },
                                    ThumbnailUrl = m.Groups[1].Value.Replace("THUMBNUM", "1")
                                })
                        .ToList();
        }
    }
}
