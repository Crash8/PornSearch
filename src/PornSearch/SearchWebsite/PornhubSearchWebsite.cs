using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AngleSharp.Dom;
using Jint;

namespace PornSearch
{
    internal class PornhubSearchWebsite : AbstractSearchWebsite
    {
        private string _cookie = "accessAgeDisclaimerPH=1";

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
            return new Engine().Execute(content).GetValue("go").Invoke().ToString() + "; accessAgeDisclaimerPH=1";
        }

        protected override IPornSearchParser GetSearchParser(IDocument document) {
            return new PornhubSearchParser(document);
        }

        protected override string GetHttpHeaderAcceptLanguage() {
            return "en";
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

        protected override IPornVideoParser GetVideoParser(IDocument document) {
            return new PornhubVideoParser(document);
        }
    }
}
