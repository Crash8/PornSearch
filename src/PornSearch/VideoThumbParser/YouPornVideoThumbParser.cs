using System.Text.RegularExpressions;
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
            IHtmlAnchorElement element = _root.QuerySelector<IHtmlAnchorElement>("a");
            string href = element?.GetAttribute("href") ?? "";
            Match match = Regex.Match(href, "/watch/([0-9]*)/");
            return match.Success ? match.Groups[1].Value : "";
        }

        public string Title() {
            IHtmlAnchorElement element = _root.QuerySelector<IHtmlAnchorElement>("a.video-title");
            return element?.TextContent.ToHtmlDecode();
        }

        public PornIdName Channel() {
            IHtmlAnchorElement element = _root.QuerySelector<IHtmlAnchorElement>("span.channel-title > a");
            return new PornIdName {
                Id = element?.GetAttribute("href") ?? "",
                Name = element?.Text.ToHtmlDecode() ?? ""
            };
        }

        public string ThumbnailUrl() {
            IHtmlImageElement element = _root.QuerySelector<IHtmlImageElement>("img");
            return element?.Dataset["src"] ?? "";
        }

        public string PageUrl() {
            IHtmlAnchorElement element = _root.QuerySelector<IHtmlAnchorElement>("a");
            string href = element?.GetAttribute("href") ?? "";
            return href.StartsWith("http") ? href : $"https://www.youporn.com{element?.GetAttribute("href")}";
        }
    }
}
