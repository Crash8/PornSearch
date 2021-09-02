using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using Jint;

namespace PornSearch
{
    public class PornhubSearchSource : IPornSearchSource
    {
        private static readonly HttpClient HttpClient = new HttpClient();
        private static string _cookie;

        private const string RegExItemThumb =
            "<li class=\"pcVideoListItem[\\s\\S]*?data-video-vkey=\"(.*?)\"[\\s\\S]*?<a href=\"(.*?)\""
            + " title=\"(.*?)\"[\\s\\S]*?data-src = \"(.*?)\"[\\s\\S]*?<div class=\"usernameWrap\">"
            + "[\\s\\S]*?<(?:a|span)(?:.*?href=\"(.*?)\")?.*?>(.*?)<";

        public List<PornSexOrientation> GetSexOrientations() {
            return new List<PornSexOrientation> {
                PornSexOrientation.Straight,
                PornSexOrientation.Gay
            };
        }

        public async Task<List<PornItemThumb>> SearchAsync(PornSearchFilter searchFilter) {
            if (searchFilter == null)
                throw new ArgumentNullException(nameof(searchFilter));
            if (searchFilter.Page <= 0)
                throw new ArgumentException("Value greater than zero", nameof(searchFilter.Page));
            if (!GetSexOrientations().Contains(searchFilter.SexOrientation))
                return null;
            string url = MakeUrl(searchFilter);
            string content = await GetPageContentAsync(url);
            return ExtractItemThumbs(content, searchFilter.SexOrientation);
        }

        private static string MakeUrl(PornSearchFilter searchFilter) {
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

        private async Task<string> GetPageContentAsync(string url) {
            string content = await GetHtmlContentAsync(url);
            bool hasNeedCookie = Regex.IsMatch(content, "Loading[.]{3}");
            if (hasNeedCookie) {
                _cookie = GetCookie(content);
                content = await GetHtmlContentAsync(url);
            }
            return content;
        }

        private static string GetCookie(string content) {
            content = content.Substring(content.IndexOf("function leastFactor", StringComparison.Ordinal));
            content = content.Substring(0, content.IndexOf("//-->", StringComparison.Ordinal));
            content = content.Replace("document.cookie=", "return ");
            return new Engine().Execute(content).GetValue("go").Invoke().ToString();
        }

        private async Task<string> GetHtmlContentAsync(string url) {
            using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url)) {
                request.Headers.Add("User-Agent", "PornSearch/1.0");
                request.Headers.Add("Referer", url);
                request.Headers.Add("Cookie", _cookie);
                using (HttpResponseMessage response = await HttpClient.SendAsync(request)) {
                    if (response.IsSuccessStatusCode)
                        return await response.Content.ReadAsStringAsync();
                    if (response.StatusCode == HttpStatusCode.NotFound)
                        return "404";
                    HttpRequestException exception = new HttpRequestException(response.ReasonPhrase);
                    exception.Data.Add("StatusCode", response.StatusCode);
                    throw exception;
                }
            }
        }

        private static List<PornItemThumb> ExtractItemThumbs(string content, PornSexOrientation sexOrientation) {
            if (content == null)
                throw new ArgumentNullException(nameof(content));
            if (content == "404" || content.IndexOf("<div class=\"noResultsWrapper\">", StringComparison.Ordinal) > 0)
                return new List<PornItemThumb>();
            int startIndex = content.IndexOf("<ul id=\"videoSearchResult\"", StringComparison.Ordinal);
            if (startIndex < 0)
                startIndex = content.IndexOf("<ul id=\"videoCategory\"", StringComparison.Ordinal);
            if (startIndex < 0)
                throw new Exception("Data not found");
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
                            Title = HttpUtility.HtmlDecode(m.Groups[3].Value).Replace("\u00A0", " "),
                            Channel = new PornIdName {
                                Id = m.Groups[5].Value,
                                Name = m.Groups[6].Value
                            },
                            ThumbnailUrl = m.Groups[4].Value
                        })
                        .ToList();
        }
    }
}
