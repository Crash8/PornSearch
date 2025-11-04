using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AngleSharp;
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

        protected override string MakeUrlSearchChannel(PornSearchChannelFilter searchChannelFilter) {
            if (!searchChannelFilter.ChannelId.StartsWith("/") || searchChannelFilter.ChannelId.Length <= 2)
                throw new ArgumentException("ChannelId invalid format", nameof(searchChannelFilter.ChannelId));
            return searchChannelFilter.ChannelId.StartsWith("/profiles/")
                ? $"https://www.xvideos.com{searchChannelFilter.ChannelId}/videos/new/{searchChannelFilter.Page - 1}"
                : $"https://www.xvideos.com/channels{searchChannelFilter.ChannelId}/videos/new/{searchChannelFilter.Page - 1}";
        }

        protected override string MakeUrlSearchActor(PornSearchActorFilter searchActorFilter) {
            if (!searchActorFilter.ActorId.StartsWith("/") || searchActorFilter.ActorId.Length <= 2)
                throw new ArgumentException("ActorId invalid format", nameof(searchActorFilter.ActorId));
            return $"https://www.xvideos.com{searchActorFilter.ActorId}/videos/new/{searchActorFilter.Page - 1}";
        }

        protected override IPornSearchParser GetSearchParser(IDocument document, bool useWebProxy) {
            return new XVideosSearchParser(document, useWebProxy);
        }

        protected override IPornSearchChannelParser GetSearchChannelParser(IDocument document) {
            return new XVideosSearchChannelParser(document);
        }

        protected override IPornSearchActorParser GetSearchActorParser(IDocument document) {
            return new XVideosSearchActorParser(document);
        }

        public override PornSourceVideo GetSourceVideo(string url) {
            const string pattern = "^https://[a-z]{2,3}[.]xvideos(53)?[.](com|es)/video[.]?([^/]+)/[^\\s]+$";
            Match match = Regex.Match(url, pattern);
            return !match.Success
                ? null
                : new PornSourceVideo {
                    Id = match.Groups[3].Value,
                    Website = PornWebsite.XVideos
                };
        }

        public override string MakeUrlVideo(string videoId) {
            return Regex.IsMatch(videoId, "^[0-9]+$")
                ? $"https://www.xvideos.com/video{videoId}/a"
                : $"https://www.xvideos.com/video.{videoId}/a";
        }

        protected override IPornVideoParser GetVideoParser(IDocument document) {
            return new XVideosVideoParser(document);
        }

        public override async Task<bool> CheckIfCanVideoEmbedInIframeAsync(PornVideo video, bool useWebProxy) {
            string url = video.PageUrl;
            if (string.IsNullOrEmpty(url))
                return false;
            PornHttpClient httpClient = new PornHttpClient();
            string content = await httpClient.SendAsync(url, useWebProxy);
            if (content == null)
                return false;
            IConfiguration config = Configuration.Default;
            IBrowsingContext context = BrowsingContext.New(config);
            IDocument documentVideoEmbed = await context.OpenAsync(req => req.Content(content));
            var span = documentVideoEmbed.QuerySelector<IHtmlSpanElement>("span.video-interactive-mark");
            return span == null;
        }
    }
}
