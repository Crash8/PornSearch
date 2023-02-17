using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using PornSearch.Extensions;

namespace PornSearch
{
    public class PornhubVideoThumbParser : IPornVideoThumbParser
    {
        private readonly IHtmlListItemElement _root;

        public PornhubVideoThumbParser(IHtmlListItemElement root) {
            _root = root;
        }

        public bool IsAvailable() {
            // Channel Id may be empty if the video is not available in your country
            return !string.IsNullOrWhiteSpace(Channel()?.Id)
                   // Spicevids
                   && PathRelativeUrl() != "javascript:void(0)";
        }

        public PornWebsite Website() {
            return PornWebsite.Pornhub;
        }

        public bool? IsFreePremium() {
            return _root.QuerySelector("span.phpFreeBlock") != null;
        }

        public string Id() {
            return _root.Dataset["video-vkey"];
        }

        public string Title() {
            IHtmlAnchorElement element = _root.QuerySelector<IHtmlAnchorElement>("span.title > a");
            return element?.Title?.ToHtmlDecode();
        }

        public PornIdName Channel() {
            IHtmlAnchorElement element = _root.QuerySelector<IHtmlAnchorElement>("div.usernameWrap > a");
            return element == null
                ? null
                : new PornIdName {
                    Id = element.GetAttribute("href"),
                    Name = element.Text.ToHtmlDecode()
                };
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
