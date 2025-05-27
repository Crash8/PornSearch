using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using PornSearch.Extensions;

namespace PornSearch
{
    internal class PornhubVideoChannelThumbParser : IPornVideoThumbParser
    {
        private readonly IHtmlListItemElement _root;
        private readonly PornIdName _channel;

        public PornhubVideoChannelThumbParser(IHtmlListItemElement root, PornIdName channel) {
            _root = root;
            _channel = channel;
        }

        public bool IsAvailable() {
            // thumbnail equal "https://ei.phncdn.com/www-static/images/private-video-big-premium.png?cache=2024041801"
            // if the video is not available in your country
            bool ok = !ThumbnailUrl().Contains("private-video-big-premium.png")
                      // Spicevids
                      && PathRelativeUrl() != "javascript:void(0)";
            return ok;
        }

        public PornWebsite Website() {
            return PornWebsite.Pornhub;
        }

        public string Id() {
            return _root.Dataset["video-vkey"];
        }

        public string Title() {
            IHtmlAnchorElement element = _root.QuerySelector<IHtmlAnchorElement>("span.title > a");
            return element?.Title?.ToHtmlDecode();
        }

        public PornIdName Channel() {
            return _channel;
        }

        public string ThumbnailUrl() {
            IHtmlImageElement element = _root.QuerySelector<IHtmlImageElement>("div.phimage > a > img");
            return element?.Source;
        }

        public string PageUrl() {
            return $"https://www.pornhub.com{PathRelativeUrl()}";
        }

        private string PathRelativeUrl() {
            IHtmlAnchorElement element = _root.QuerySelector<IHtmlAnchorElement>("span.title > a");
            return element?.GetAttribute("href");
        }
    }
}
