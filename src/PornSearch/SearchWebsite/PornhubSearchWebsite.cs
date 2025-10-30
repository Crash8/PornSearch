using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.Html.Dom;
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

        protected override string MakeUrlSearchChannel(PornSearchChannelFilter searchChannelFilter) {
            if (!searchChannelFilter.ChannelId.StartsWith("/") || searchChannelFilter.ChannelId.Length <= 2)
                throw new ArgumentException("ChannelId invalid format", nameof(searchChannelFilter.ChannelId));

            if (searchChannelFilter.ChannelId.StartsWith("/channels/"))
                return $"https://www.pornhub.com{searchChannelFilter.ChannelId}/videos?page={searchChannelFilter.Page}";
            return searchChannelFilter.ChannelId.StartsWith("/users/")
                ? $"https://www.pornhub.com{searchChannelFilter.ChannelId}/videos/public?page={searchChannelFilter.Page}"
                : $"https://www.pornhub.com{searchChannelFilter.ChannelId}/videos/upload?o=mr&page={searchChannelFilter.Page}";
        }

        protected override string MakeUrlSearchActor(PornSearchActorFilter searchActorFilter) {
            if (!searchActorFilter.ActorId.StartsWith("/") || searchActorFilter.ActorId.Length <= 2)
                throw new ArgumentException("ActorId invalid format", nameof(searchActorFilter.ActorId));
            return $"https://www.pornhub.com{searchActorFilter.ActorId}/videos?page={searchActorFilter.Page}";
        }

        protected override async Task<string> GetPageContentAsync(string url, bool useWebProxy) {
            string content = await GetHtmlContentWithCookieAsync(url, _cookie, useWebProxy);
            bool hasNeedCookie = content != null && Regex.IsMatch(content, "Loading[.]{3}");
            if (hasNeedCookie) {
                _cookie = GetCookie(content);
                content = await GetPageContentAsync(url, useWebProxy);
            }
            return content;
        }

        private static string GetCookie(string content) {
            content = content.Substring(content.IndexOf("function leastFactor", StringComparison.Ordinal));
            content = content.Substring(0, content.IndexOf("//-->", StringComparison.Ordinal));
            content = content.Replace("document.cookie=", "return ");
            return new Engine().Execute(content).Invoke("go") + "accessAgeDisclaimerPH=1";
        }

        protected override IPornSearchParser GetSearchParser(IDocument document, bool useWebProxy) {
            return new PornhubSearchParser(document);
        }

        protected override IPornSearchChannelParser GetSearchChannelParser(IDocument document) {
            return new PornhubSearchChannelParser(document);
        }

        protected override IPornSearchActorParser GetSearchActorParser(IDocument document) {
            return new PornhubSearchActorParser(document);
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

        public override string MakeUrlVideo(string videoId) {
            return $"https://www.pornhub.com/view_video.php?viewkey={videoId}";
        }

        protected override IPornVideoParser GetVideoParser(IDocument document) {
            return new PornhubVideoParser(document);
        }

        public override async Task<bool> CheckIfCanVideoEmbedInIframeAsync(PornVideo video, bool useWebProxy) {
            string url = video.VideoEmbedUrl;
            if (string.IsNullOrEmpty(url))
                return false;
            PornHttpClient httpClient = new PornHttpClient();
            string content = await httpClient.SendAsync(url, useWebProxy) ?? await httpClient.SendAsync(url, useWebProxy);
            if (content == null)
                return false;
            IConfiguration config = Configuration.Default;
            IBrowsingContext context = BrowsingContext.New(config);
            IDocument documentVideoEmbed = await context.OpenAsync(req => req.Content(content));
            return documentVideoEmbed.QuerySelector<IHtmlDivElement>("div.userMessageSection") == null;
        }
    }
}
