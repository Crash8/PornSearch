using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using PornSearch.Extensions;

namespace PornSearch
{
    internal class YouPornVideoParser : IPornVideoParser
    {
        private readonly IDocument _document;

        public YouPornVideoParser(IDocument document) {
            _document = document;
        }

        public bool IsAvailable() {
            return _document.QuerySelector("div.box-404") == null && _document.QuerySelector("div.geo-blocked-content") == null;
        }

        public PornWebsite Website() {
            return PornWebsite.YouPorn;
        }

        public PornSexOrientation SexOrientation() {
            IHtmlCollection<IElement> elements = _document.QuerySelectorAll("head > script");
            IElement element = elements.FirstOrDefault(e => e.TextContent.IndexOf("site_orientation", StringComparison.Ordinal) > 0);
            Match match = Regex.Match(element?.TextContent ?? "", "'site_orientation': '([^\']*)");
            string sexOrientation = match.Success ? match.Groups[1].Value : "straight";
            return (PornSexOrientation)Enum.Parse(typeof(PornSexOrientation), sexOrientation, true);
        }

        public bool? IsFreePremium() {
            return null;
        }

        public string Id() {
            IHtmlMetaElement element = _document.QuerySelector<IHtmlMetaElement>("head > meta[property='og:url']");
            string url = element?.Content ?? "";
            Match match = Regex.Match(url, "/watch/([0-9]+)/");
            return match.Success ? match.Groups[1].Value : null;
        }

        public string Title() {
            IHtmlMetaElement element = _document.QuerySelector<IHtmlMetaElement>("head > meta[property='og:title']");
            return element?.Content?.ToHtmlDecode();
        }

        public PornIdName Channel() {
            IHtmlAnchorElement element = _document.QuerySelector<IHtmlAnchorElement>("div.submitByLink > a");
            return element == null
                ? null
                : new PornIdName {
                    Id = element.GetAttribute("href"),
                    Name = element.Text.ToHtmlDecode()
                };
        }

        public string ThumbnailUrl() {
            IHtmlLinkElement element = _document.QuerySelector<IHtmlLinkElement>("head > link[rel='preload']");
            string url = element?.Href ?? "";
            return url.Replace("/videos/stage/", "/videos/");
        }

        public string SmallThumbnailUrl() {
            IHtmlMetaElement element = _document.QuerySelector<IHtmlMetaElement>("head > meta[property='og:image']");
            string url = element?.Content ?? "";
            return url.Replace("/videos/stage/", "/videos/");
        }

        public string PageUrl() {
            IHtmlMetaElement element = _document.QuerySelector<IHtmlMetaElement>("head > meta[property='og:url']");
            return element?.Content;
        }

        public string VideoEmbedUrl() {
            IHtmlMetaElement element = _document.QuerySelector<IHtmlMetaElement>("head > meta[property='og:video:url']");
            return element?.Content;
        }

        public TimeSpan Duration() {
            IHtmlMetaElement element = _document.QuerySelector<IHtmlMetaElement>("head > meta[property='video:duration']");
            string duration = element?.Content;
            return TimeSpan.FromSeconds(duration.TransformToInt());
        }

        public List<PornIdName> Categories() {
            return _document.QuerySelectorAll<IHtmlAnchorElement>("a[data-espnode='category_tag']")
                            .Select(anchor => new PornIdName {
                                        Id = anchor.GetAttribute("href"),
                                        Name = anchor.Text.ToHtmlDecode()
                                    })
                            .ToList();
        }

        public List<PornIdName> Tags() {
            return _document.QuerySelectorAll<IHtmlAnchorElement>("a[data-espnode='porntag_tag']")
                            .Select(anchor => new PornIdName {
                                        Id = anchor.GetAttribute("href"),
                                        Name = anchor.Text.ToHtmlDecode()
                                    })
                            .ToList();
        }

        public List<PornIdName> Actors() {
            return _document.QuerySelectorAll<IHtmlAnchorElement>("a[data-espnode='pornstar_tag']")
                            .Select(anchor => new PornIdName {
                                        Id = anchor.GetAttribute("href"),
                                        Name = anchor.Text.ToHtmlDecode()
                                    })
                            .ToList();
        }

        public int NbViews() {
            IHtmlDivElement element = _document.QuerySelector<IHtmlDivElement>("div.js_videoInfoViews");
            return element?.Dataset["value"].TransformToInt() ?? 0;
        }

        public int NbLikes() {
            return 0;
        }

        public int NbDislikes() {
            return 0;
        }

        public DateTime Date() {
            IHtmlSpanElement element = _document.QuerySelector<IHtmlSpanElement>("div.video-uploaded span");
            string date = (element?.Text() ?? "").Replace("th", "").Replace("nd", "").Replace("st", "").Replace("rd", "");
            return DateTime.ParseExact(date, "MMM d yyyy", null);
        }

        public List<PornVideoThumb> RelatedVideos() {
            IHtmlCollection<IElement> elements = _document.QuerySelectorAll("div#relatedVideosCntr div[data-espnode='videobox']");
            return elements.OfType<IHtmlDivElement>()
                           .Select(div => new YouPornVideoThumbParser(div))
                           .Where(p => p.IsAvailable())
                           .Select(p => new PornVideoThumb {
                                       Website = p.Website(),
                                       SexOrientation = SexOrientation(),
                                       Id = p.Id(),
                                       Title = p.Title(),
                                       Channel = p.Channel(),
                                       ThumbnailUrl = p.ThumbnailUrl(),
                                       PageUrl = p.PageUrl()
                                   })
                           .ToList();
        }
    }
}
