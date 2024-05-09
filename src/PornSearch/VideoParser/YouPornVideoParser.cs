using System;
using System.Collections.Generic;
using System.Globalization;
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
            return _document.QuerySelector("div.box-404") == null && _document.QuerySelector("div.geo-blocked-content") == null
                                                                  && _document.QuerySelector("div.video-inactive-wrapper") == null;
        }

        public PornWebsite Website() {
            return PornWebsite.YouPorn;
        }

        public PornSexOrientation SexOrientation() {
            IHtmlCollection<IElement> elements = _document.QuerySelectorAll("head > script");
            IElement element = elements.FirstOrDefault(e => e.TextContent.IndexOf("page_params.segment", StringComparison.Ordinal) > 0);
            Match match = Regex.Match(element?.TextContent ?? "", "page_params.segment = '([^\']*)");
            string sexOrientation = match.Success ? match.Groups[1].Value : "straight";
            return (PornSexOrientation)Enum.Parse(typeof(PornSexOrientation), sexOrientation, true);
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
            IHtmlMetaElement element = _document.QuerySelector<IHtmlMetaElement>("head > meta[property='og:image']");
            return element?.Content ?? "";
        }

        public string SmallThumbnailUrl() {
            IHtmlVideoElement element = _document.QuerySelector<IHtmlVideoElement>("div#videoContainer video");
            return element?.Poster ?? "";
        }

        public string PageUrl() {
            IHtmlMetaElement element = _document.QuerySelector<IHtmlMetaElement>("head > meta[property='og:url']");
            return element?.Content;
        }

        public string VideoEmbedUrl() {
            IHtmlMetaElement element = _document.QuerySelector<IHtmlMetaElement>("head > meta[name='twitter:player']");
            return element?.Content ?? "";
        }

        public TimeSpan Duration() {
            IHtmlMetaElement element = _document.QuerySelector<IHtmlMetaElement>("head > meta[property='video:duration']");
            string duration = element?.Content;
            return TimeSpan.FromSeconds(duration.TransformToInt());
        }

        public List<PornIdName> Categories() {
            return _document.QuerySelectorAll<IHtmlAnchorElement>("a.categories-tags")
                            .Select(anchor => new PornIdName {
                                        Id = anchor.GetAttribute("href"),
                                        Name = anchor.Text.ToHtmlDecode()
                                    })
                            .ToList();
        }

        public List<PornIdName> Tags() {
            return _document.QuerySelectorAll<IHtmlAnchorElement>("a.pink-border.tm_carousel_tag")
                            .Select(anchor => new PornIdName {
                                        Id = anchor.GetAttribute("href"),
                                        Name = anchor.Text.ToHtmlDecode()
                                    })
                            .ToList();
        }

        public List<PornIdName> Actors() {
            return _document.QuerySelectorAll<IHtmlAnchorElement>("a.tm_carousel_tag:not(.pink-border):not(.categories-tags)")
                            .Select(anchor => new PornIdName {
                                        Id = anchor.GetAttribute("href"),
                                        Name = anchor.Text.ToHtmlDecode()
                                    })
                            .ToList();
        }

        public int NbViews() {
            IHtmlCollection<IElement> elements = _document.QuerySelectorAll("head > script");
            IElement element = elements.FirstOrDefault(e => e.TextContent.IndexOf("interactionCount", StringComparison.Ordinal) > 0);
            Match match = Regex.Match(element?.TextContent ?? "", ",\"interactionCount\":([^},]*)");
            return match.Success ? match.Groups[1].Value.TransformToInt() : 0;
        }

        public int? NbLikes() {
            return null;
        }

        public int? NbDislikes() {
            return null;
        }

        public DateTime Date() {
            const string searchTerm = "\"uploadDate\":";
            const string pattern = "\"uploadDate\":\"([^T]*)";
            IHtmlCollection<IElement> elements = _document.QuerySelectorAll("head > script");
            IElement element = elements.FirstOrDefault(e => e.TextContent.IndexOf(searchTerm, StringComparison.Ordinal) > 0);
            Match match = Regex.Match(element?.TextContent ?? "", pattern);
            DateTime date = DateTime.MinValue;
            if (match.Success)
                date = DateTime.ParseExact(match.Groups[1].Value, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            return date;
        }

        public List<PornVideoThumb> RelatedVideos() {
            IHtmlCollection<IElement> elements = _document.QuerySelectorAll("div#relatedVideosWrapper div.video-box");
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
