using System;
using System.Text.RegularExpressions;
using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using PornSearch.Extensions;

namespace PornSearch
{
    internal class XVideosVideoThumbParser : IPornVideoThumbParser
    {
        private readonly XVideosJsonRelatedVideos _jsonRoot;
        private readonly IHtmlDivElement _divRoot;
        private string _url;

        public XVideosVideoThumbParser(XVideosJsonRelatedVideos root) {
            _jsonRoot = root;
        }

        public XVideosVideoThumbParser(IHtmlDivElement root) {
            _divRoot = root;
        }

        public bool IsAvailable() {
            return true;
        }

        public PornWebsite Website() {
            return PornWebsite.XVideos;
        }

        public string Id() {
            string url = PageUrl();
            Match match = Regex.Match(url, "/video[.]?([^/]*)/");
            return match.Success ? match.Groups[1].Value : _divRoot.Dataset["id"];
        }

        public string Title() {
            if (_jsonRoot != null)
                return _jsonRoot.tf.ToHtmlDecode() ?? "";
            IHtmlAnchorElement element = _divRoot.QuerySelector<IHtmlAnchorElement>("p.title > a");
            return element?.Title?.ToHtmlDecode() ?? "";
        }

        public PornIdName Channel() {
            string channelId;
            string channelName;
            if (_jsonRoot != null) {
                channelId = _jsonRoot.pu ?? "";
                channelName = _jsonRoot.pn;
            }
            else {
                IHtmlAnchorElement element = _divRoot.QuerySelector<IHtmlAnchorElement>("p.metadata a");
                channelId = element?.GetAttribute("href") ?? "";
                channelName = element?.QuerySelector("span.name")?.Text();
            }
            int index = string.IsNullOrEmpty(channelId) ? -1 : channelId.IndexOf("/", 1, StringComparison.Ordinal);
            return new PornIdName {
                Id = index == -1 ? channelId : channelId.Substring(index),
                Name = channelName.ToHtmlDecode() ?? ""
            };
        }

        public string ThumbnailUrl() {
            if (_jsonRoot != null)
                return _jsonRoot.i;
            IHtmlImageElement element = _divRoot.QuerySelector<IHtmlImageElement>("img");
            return element?.Dataset["src"]?.Replace("THUMBNUM", "15");
        }

        public string PageUrl() {
            if (_url == null) {
                if (_jsonRoot != null) {
                    _url = $"https://www.xvideos.com{_jsonRoot.u}";
                }
                else {
                    IHtmlAnchorElement element = _divRoot.QuerySelector<IHtmlAnchorElement>("a");
                    string pageUrl = element?.GetAttribute("href")?.Replace("/THUMBNUM", "") ?? "";
                    if (pageUrl.StartsWith("/search-video/")) {
                        PornHttpClient httpClient = new PornHttpClient();
                        httpClient.SetResult(PornHttpClientResult.LocationFrom301);
                        pageUrl = httpClient.SendAsync($"https://www.xvideos.com{pageUrl}").Result;
                    }
                    _url = $"https://www.xvideos.com{pageUrl}";
                }
            }
            return _url;
        }
    }
}
