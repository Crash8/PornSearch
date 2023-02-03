using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using Newtonsoft.Json;
using PornSearch.Extensions;

namespace PornSearch
{
    internal class XVideosVideoParser : IPornVideoParser
    {
        private readonly IDocument _document;

        public XVideosVideoParser(IDocument document) {
            _document = document;
        }

        public bool IsAvailable() {
            return _document.QuerySelector("a#site-logo-red-link") == null;
        }

        public PornWebsite Website() {
            return PornWebsite.XVideos;
        }

        // unreliable data
        public PornSexOrientation SexOrientation() {
            const string searchTerm = "page_main_cat";
            const string pattern = "\"page_main_cat\":\"([^\"]*)";
            IHtmlCollection<IElement> elements = _document.QuerySelectorAll("head > script");
            IElement element = elements.FirstOrDefault(e => e.TextContent.IndexOf(searchTerm, StringComparison.Ordinal) > 0);
            Match match = Regex.Match(element?.TextContent ?? "", pattern);
            string sexOrientation = match.Success ? match.Groups[1].Value : "straight";
            return (PornSexOrientation)Enum.Parse(typeof(PornSexOrientation), sexOrientation, true);
        }

        public string Id() {
            IHtmlMetaElement element = _document.QuerySelector<IHtmlMetaElement>("head > meta[property='og:url']");
            string url = element?.Content ?? "";
            Match match = Regex.Match(url, "/video([0-9]+)/");
            return match.Success ? match.Groups[1].Value : null;
        }

        public string Title() {
            IHtmlMetaElement element = _document.QuerySelector<IHtmlMetaElement>("head > meta[property='og:title']");
            return element?.Content?.ToHtmlDecode();
        }

        // unreliable data
        public PornIdName Channel() {
            IHtmlAnchorElement element = _document.QuerySelector<IHtmlAnchorElement>("li.main-uploader > a");
            string url = element?.GetAttribute("href") ?? "/";
            int index = url.IndexOf("/", 1, StringComparison.Ordinal);
            return new PornIdName {
                Id = index == -1 ? "" : url.Substring(index),
                Name = element?.QuerySelector("span.name")?.Text().ToHtmlDecode() ?? ""
            };
        }

        public string ThumbnailUrl() {
            const string searchTerm = "html5player.setThumbUrl169";
            const string pattern = "html5player[.]setThumbUrl169[(]'([^']*)";
            IHtmlCollection<IElement> elements = _document.QuerySelectorAll("div > script");
            IElement element = elements.FirstOrDefault(e => e.TextContent.IndexOf(searchTerm, StringComparison.Ordinal) > 0);
            Match match = Regex.Match(element?.TextContent ?? "", pattern);
            return match.Success ? match.Groups[1].Value : null;
        }

        public string SmallThumbnailUrl() {
            IHtmlMetaElement element = _document.QuerySelector<IHtmlMetaElement>("head > meta[property='og:image']");
            return element?.Content;
        }

        public string PageUrl() {
            IHtmlMetaElement element = _document.QuerySelector<IHtmlMetaElement>("head > meta[property='og:url']");
            return element?.Content;
        }

        public string VideoEmbedUrl() {
            IHtmlInputElement element = _document.QuerySelector<IHtmlInputElement>("input#copy-video-embed");
            Match match = Regex.Match(element?.Value ?? "", " src=\"([^\"]*)");
            return match.Success ? match.Groups[1].Value : null;
        }

        public TimeSpan Duration() {
            IHtmlMetaElement element = _document.QuerySelector<IHtmlMetaElement>("head > meta[property='og:duration']");
            string duration = element?.Content;
            return TimeSpan.FromSeconds(duration.TransformToInt());
        }

        public List<PornIdName> Categories() {
            return null;
        }

        public List<PornIdName> Tags() {
            IHtmlCollection<IElement> elements = _document.QuerySelectorAll("div.video-metadata li > a[href^='/tags/']");
            return elements.OfType<IHtmlAnchorElement>()
                           .Select(anchor => new PornIdName {
                                       Id = anchor.GetAttribute("href"),
                                       Name = anchor.Text.ToHtmlDecode()
                                   })
                           .ToList();
        }

        public List<PornIdName> Actors() {
            IHtmlCollection<IElement> elements = _document.QuerySelectorAll("div.video-metadata li.model > a");
            return elements.OfType<IHtmlAnchorElement>()
                           .Select(anchor => new PornIdName {
                                       Id = anchor.GetAttribute("href"),
                                       Name = anchor.QuerySelector("span.name")?.Text().ToHtmlDecode()
                                   })
                           .ToList();
        }

        // unreliable data
        public int NbViews() {
            int nbViews;
            IElement element = _document.QuerySelector("div#v-views > strong.mobile-hide");
            if (element != null) {
                nbViews = element.Text().TransformToInt();
            }
            else {
                const string searchTerm = "userInteractionCount";
                const string pattern = "\"userInteractionCount\": ([^\\n]*)";
                IHtmlCollection<IElement> elements = _document.QuerySelectorAll("head > script");
                element = elements.FirstOrDefault(e => e.TextContent.IndexOf(searchTerm, StringComparison.Ordinal) > 0);
                Match match = Regex.Match(element?.TextContent ?? "", pattern);
                string userInteractionCount = match.Success ? match.Groups[1].Value : null;
                nbViews = (userInteractionCount?.TransformToInt() ?? 0) + NbLikes() + NbDislikes();
            }
            return nbViews;
        }

        public int NbLikes() {
            IHtmlSpanElement element = _document.QuerySelector<IHtmlSpanElement>("span.rating-good-nbr");
            return element?.Text().TransformToInt() ?? 0;
        }

        public int NbDislikes() {
            IHtmlSpanElement element = _document.QuerySelector<IHtmlSpanElement>("span.rating-bad-nbr");
            return element?.Text().TransformToInt() ?? 0;
        }

        // unreliable data
        public DateTime? Date() {
            const string searchTerm = "\"uploadDate\":";
            const string pattern = "\"uploadDate\": \"([^T]*)";
            IHtmlCollection<IElement> elements = _document.QuerySelectorAll("head > script");
            IElement element = elements.FirstOrDefault(e => e.TextContent.IndexOf(searchTerm, StringComparison.Ordinal) > 0);
            Match match = Regex.Match(element?.TextContent ?? "", pattern);
            return match.Success ? DateTime.ParseExact(match.Groups[1].Value, "yyyy-MM-dd", CultureInfo.InvariantCulture) : (DateTime?)null;
        }

        public List<PornVideoThumb> RelatedVideos() {
            const string searchTerm = "var video_related=";
            IHtmlCollection<IElement> elements = _document.QuerySelectorAll("div > script");
            IElement element = elements.FirstOrDefault(e => e.TextContent.StartsWith(searchTerm));
            string text = element?.TextContent.Substring(searchTerm.Length) ?? "[]";
            int endIndex = text.LastIndexOf("];", StringComparison.Ordinal);
            if (endIndex > 0)
                text = text.Substring(0, endIndex + 1);
            return JsonConvert.DeserializeObject<List<XVideosJsonRelatedVideos>>(text)
                              .Select(r => new XVideosVideoThumbParser(r))
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

internal class XVideosJsonRelatedVideos
{
    public int id { get; set; }
    public string u { get; set; }
    public string i { get; set; }
    public string tf { get; set; }
    public string pn { get; set; }
    public string pu { get; set; }
}
