using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AngleSharp.Dom;

namespace PornSearch
{
    internal class YouPornSearchWebsite : AbstractSearchWebsite
    {
        public override List<PornSexOrientation> GetSexOrientations() {
            return new List<PornSexOrientation> {
                PornSexOrientation.Straight,
                PornSexOrientation.Gay
            };
        }

        protected override string MakeUrl(PornSearchFilter searchFilter) {
            string url = $"https://www.youporn.com{(searchFilter.SexOrientation == PornSexOrientation.Gay ? "/gay/" : "/")}";
            if (!string.IsNullOrWhiteSpace(searchFilter.Filter))
                url += "search/";
            List<string> queries = new List<string>();
            if (!string.IsNullOrWhiteSpace(searchFilter.Filter))
                queries.Add("query=" + string.Join("+", searchFilter.Filter.Split(' ').Select(Uri.EscapeDataString)).ToLower());
            queries.Add("page=" + searchFilter.Page);
            string query = string.Join("&", queries);
            if (!string.IsNullOrEmpty(query))
                url += "?" + query;
            return url;
        }

        protected override string MakeUrlSearchChannel(PornSearchChannelFilter searchChannelFilter) {
            if (!searchChannelFilter.ChannelId.StartsWith("/") || searchChannelFilter.ChannelId.Length <= 2)
                throw new ArgumentException("ChannelId invalid format", nameof(searchChannelFilter.ChannelId));
            return $"https://www.youporn.com{searchChannelFilter.ChannelId}?page={searchChannelFilter.Page}";
        }

        protected override string MakeUrlSearchActor(PornSearchActorFilter searchActorFilter) {
            if (!searchActorFilter.ActorId.StartsWith("/") || searchActorFilter.ActorId.Length <= 2)
                throw new ArgumentException("ActorId invalid format", nameof(searchActorFilter.ActorId));
            return $"https://www.youporn.com{searchActorFilter.ActorId}?page={searchActorFilter.Page}";
        }

        protected override async Task<string> GetPageContentAsync(string url) {
            return await GetHtmlContentWithCookieAsync(url, "age_verified=1");
        }

        protected override IPornSearchParser GetSearchParser(IDocument document) {
            return new YouPornSearchParser(document);
        }

        protected override IPornSearchChannelParser GetSearchChannelParser(IDocument document) {
            return new YouPornSearchChannelParser(document);
        }

        protected override IPornSearchActorParser GetSearchActorParser(IDocument document) {
            return new YouPornSearchActorParser(document);
        }

        public override PornSourceVideo GetSourceVideo(string url) {
            const string pattern = "^https://[a-z]{2,3}[.](youporn|you-porn|youporngay)[.]com/watch/([0-9]+)($|/[^\\s]*$)";
            Match match = Regex.Match(url, pattern);
            return !match.Success
                ? null
                : new PornSourceVideo {
                    Id = match.Groups[2].Value,
                    Website = PornWebsite.YouPorn
                };
        }

        public override string MakeUrlVideo(string videoId) {
            return $"https://www.youporn.com/watch/{videoId}/";
        }

        protected override IPornVideoParser GetVideoParser(IDocument document) {
            return new YouPornVideoParser(document);
        }

        public override Task<bool> CheckIfCanVideoEmbedInIframeAsync(PornVideo video) {
            bool ok = !(video.Title?.Contains('"') ?? false);
            return Task.FromResult(ok);
        }
    }
}
