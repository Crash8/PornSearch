using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Jint;

namespace PornSearch
{
    public class PornhubSearchSource : AbstractSearchSource
    {
        private static string _cookie;

        private const string RegExItemThumb =
            "<li class=\"pcVideoListItem[\\s\\S]*?data-video-vkey=\"(.*?)\"[\\s\\S]*?<a href=\"(.*?)\""
            + " title=\"(.*?)\"[\\s\\S]*?data-src = \"(.*?)\"[\\s\\S]*?<div class=\"usernameWrap\">"
            + "[\\s\\S]*?<(?:a|span)(?:.*?href=\"(.*?)\")?.*?>(.*?)<";

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
                content = await GetHtmlContentWithCookieAsync(url, _cookie);
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
            int startIndex = content.IndexOf("<div class=\"pagination3\">", StringComparison.Ordinal);
            if (startIndex > 0) {
                int endIndex = content.IndexOf("</ul>", startIndex, StringComparison.Ordinal);
                return content.Substring(startIndex, endIndex - startIndex);
            }
            return null;
        }

        protected override bool IsNextButtonInContentPagination(string contentPagination) {
            return contentPagination.IndexOf("class=\"page_next omega\"", StringComparison.Ordinal) > -1;
        }

        protected override int? GetPageActiveInContentPagination(string contentPagination) {
            Match matchPageActive = Regex.Match(contentPagination, "<li class=\"page_current[^<]*[^>]*>([^<]*)</span>");
            return matchPageActive.Success ? (int?)Convert.ToInt32(matchPageActive.Groups[1].Value) : null;
        }

        protected override bool IsContentNotFound(string content) {
            return content.IndexOf("<div class=\"noResultsWrapper\">", StringComparison.Ordinal) > 0;
        }

        protected override List<PornItemThumb> ExtractItemThumbs(string content, PornSexOrientation sexOrientation) {
            int startIndex = content.IndexOf("<ul id=\"videoSearchResult\"", StringComparison.Ordinal);
            if (startIndex < 0)
                startIndex = content.IndexOf("<ul id=\"videoCategory\"", StringComparison.Ordinal);
            int otherStartIndex = content.IndexOf("<ul ", startIndex + 4, StringComparison.Ordinal);
            int endIndex = content.IndexOf("</ul>", startIndex, StringComparison.Ordinal);
            if (endIndex > otherStartIndex)
                endIndex = content.IndexOf("</ul>", endIndex + 5, StringComparison.Ordinal);
            string contentItems = content.Substring(startIndex, endIndex - startIndex);
            return Regex.Matches(contentItems, RegExItemThumb)
                        .Cast<Match>()
                        .Select(m => new PornItemThumb {
                                    Source = PornSource.Pornhub,
                                    SexOrientation = sexOrientation,
                                    Id = m.Groups[1].Value,
                                    Title = HtmlDecode(m.Groups[3].Value),
                                    Channel = new PornIdName {
                                        Id = m.Groups[5].Value,
                                        Name = HtmlDecode(m.Groups[6].Value)
                                    },
                                    ThumbnailUrl = m.Groups[4].Value,
                                    PageUrl = $"https://www.pornhub.com{m.Groups[2].Value}"
                                })
                        .ToList();
        }
    }
}
