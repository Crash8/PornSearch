using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PornSearch
{
    public class PornhubSearchSource : IPornSearchSource
    {
        private static readonly HttpClient HttpClient = new HttpClient();

        private const string RegExItemThumb =
            "<li class=\"pcVideoListItem[\\s\\S]*?data-video-vkey=\"(.*?)\"[\\s\\S]*?<a href=\"(.*?)\""
            + " title=\"(.*?)\"[\\s\\S]*?data-src = \"(.*?)\"[\\s\\S]*?<div class=\"usernameWrap\">"
            + "[\\s\\S]*?<a.*href=\"(.*?)\".*?>(.*?)<";

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
            string url = MakeUrl(searchFilter);
            string content = await GetHtmlContentAsync(url);
            return ExtractItemThumb(content);
        }

        private static string MakeUrl(PornSearchFilter searchFilter) {
            string url = $"https://www.pornhub.com{(searchFilter.SexOrientation == PornSexOrientation.Gay ? "/gay" : "")}/video";
            if (!string.IsNullOrWhiteSpace(searchFilter.Filter))
                url += "/search";
            List<string> queries = new List<string>();
            if (!string.IsNullOrWhiteSpace(searchFilter.Filter))
                queries.Add("search=" + Uri.EscapeDataString(searchFilter.Filter.ToLower()).Replace(" ", "+"));
            if (searchFilter.Page > 1)
                queries.Add("page=" + searchFilter.Page);
            string query = string.Join("&", queries);
            if (!string.IsNullOrEmpty(query))
                url += "?" + query;
            return url;
        }

        private static async Task<string> GetHtmlContentAsync(string url) {
            using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url)) {
                request.Headers.Add("User-Agent", "PornSearch/1.0");
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

        private static List<PornItemThumb> ExtractItemThumb(string content) {
            if (content == null)
                throw new ArgumentNullException(nameof(content));
            if (content == "404" || content.IndexOf("<div class=\"noResultsWrapper\">", StringComparison.Ordinal) > 0)
                return new List<PornItemThumb>();
            int startIndex = content.IndexOf("<ul id=\"videoSearchResult\"", StringComparison.Ordinal);
            if (startIndex < 0)
                startIndex = content.IndexOf("<ul id=\"videoCategory\"", StringComparison.Ordinal);
            if (startIndex < 0)
                throw new Exception("Data not found");
            int endIndex = content.IndexOf("</ul>", startIndex, StringComparison.Ordinal);
            string contentItems = content.Substring(startIndex, endIndex - startIndex);
            return Regex.Matches(contentItems, RegExItemThumb)
                        .Cast<Match>()
                        .Select(m => new PornItemThumb {
                            Id = m.Groups[1].Value,
                            Title = HttpUtility.HtmlDecode(m.Groups[3].Value),
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
