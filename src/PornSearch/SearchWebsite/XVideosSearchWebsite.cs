using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AngleSharp.Dom;

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

        protected override IPornSearchParser GetSearchParser(IDocument document) {
            return new XVideosSearchParser(document);
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

        protected override IPornVideoParser GetVideoParser(IDocument document) {
            return new XVideosVideoParser(document);
        }

        public override Task<bool> CheckIfCanVideoEmbedInIframeAsync(PornVideo video) {
            return Task.FromResult(true);
        }
    }
}
