using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using PornSearch.Extensions;

namespace PornSearch
{
    internal class YouPornVideoThumbParser : IPornVideoThumbParser
    {
        private readonly IHtmlDivElement _root;

        public YouPornVideoThumbParser(IHtmlDivElement root) {
            _root = root;
        }

        public bool IsAvailable() {
            return _root.QuerySelector("i.icon-lock") == null && _root.QuerySelector("i.icon-lock-foreground") == null;
        }

        public PornWebsite Website() {
            return PornWebsite.YouPorn;
        }

        public bool? IsFreePremium() {
            return null;
        }

        public string Id() {
            return _root.Dataset["video-id"];
        }

        public string Title() {
            IHtmlDivElement element = _root.QuerySelector<IHtmlDivElement>("div.video-box-title");
            return element?.Title?.ToHtmlDecode();
        }

        public PornIdName Channel() {
            IHtmlAnchorElement element = _root.QuerySelector<IHtmlAnchorElement>("span.channelTitle > a");
            return new PornIdName {
                Id = element?.GetAttribute("href") ?? "",
                Name = element?.Text.ToHtmlDecode() ?? ""
            };
        }

        public string ThumbnailUrl() {
            IHtmlImageElement element = _root.QuerySelector<IHtmlImageElement>("img");
            string url = element?.Dataset["thumbnail"] ?? "";
            return url.Replace("/videos/stage/", "/videos/");
        }

        public string PageUrl() {
            IHtmlAnchorElement element = _root.QuerySelector<IHtmlAnchorElement>("a");
            string href = element?.GetAttribute("href") ?? "";
            return href.StartsWith("http") ? href : $"https://www.youporn.com{element?.GetAttribute("href")}";
        }
    }
}
