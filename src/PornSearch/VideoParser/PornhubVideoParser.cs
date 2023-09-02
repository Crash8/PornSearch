using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using PornSearch.Extensions;

namespace PornSearch
{
    internal class PornhubVideoParser : IPornVideoParser
    {
        private readonly IDocument _document;

        public PornhubVideoParser(IDocument document) {
            _document = document;
        }

        public bool IsAvailable() {
            IElement geoBlocked = _document.QuerySelector("div.geoBlocked");
            IElement noVideo = _document.QuerySelector("section.noVideo");
            IElement removed = _document.QuerySelector("div.removed");
            return geoBlocked == null && noVideo == null && removed == null;
        }

        public PornWebsite Website() {
            return PornWebsite.Pornhub;
        }

        public PornSexOrientation SexOrientation() {
            IHtmlCollection<IElement> elements = _document.QuerySelectorAll("head > script");
            IElement element = elements.FirstOrDefault(e => e.TextContent.IndexOf("phOrientationSegment", StringComparison.Ordinal) > 0);
            Match match = Regex.Match(element?.TextContent ?? "", "phOrientationSegment.*?= \"([^\"]*)");
            string sexOrientation = match.Success ? match.Groups[1].Value : "straight";
            return (PornSexOrientation)Enum.Parse(typeof(PornSexOrientation), sexOrientation, true);
        }

        public bool? IsFreePremium() {
            return _document.QuerySelector("h1#videoTitle > div.freePremiumVideo") != null;
        }

        public string Id() {
            string id = null;
            IHtmlMetaElement element = _document.QuerySelector<IHtmlMetaElement>("head > meta[property='og:url']");
            if (element?.Content != null) {
                int index = element.Content.IndexOf("=", StringComparison.Ordinal);
                if (index > 0)
                    id = element.Content.Substring(index + 1);
            }
            return id;
        }

        public string Title() {
            IHtmlMetaElement element = _document.QuerySelector<IHtmlMetaElement>("head > meta[property='og:title']");
            return element?.Content?.ToHtmlDecode();
        }

        public PornIdName Channel() {
            IHtmlAnchorElement element = _document.QuerySelector<IHtmlAnchorElement>("div.userInfo a");
            return element == null
                ? null
                : new PornIdName {
                    Id = element.GetAttribute("href"),
                    Name = element.Text.ToHtmlDecode()
                };
        }

        public string ThumbnailUrl() {
            IHtmlMetaElement element = _document.QuerySelector<IHtmlMetaElement>("head > meta[property='og:image']");
            return element?.Content.RemoveUrlQuery();
        }

        public string SmallThumbnailUrl() {
            IHtmlImageElement element = _document.QuerySelector<IHtmlImageElement>("img#videoElementPoster");
            return element?.Source.RemoveUrlQuery();
        }

        public string PageUrl() {
            IHtmlMetaElement element = _document.QuerySelector<IHtmlMetaElement>("head > meta[property='og:url']");
            return element?.Content;
        }

        public string VideoEmbedUrl() {
            IHtmlMetaElement element = _document.QuerySelector<IHtmlMetaElement>("head > meta[property='og:video:url']");
            return element?.Content;
        }

        public async Task<bool> CanVideoEmbedInIframe() {
            PornHttpClient httpClient = new PornHttpClient();
            string content = await httpClient.SendAsync(VideoEmbedUrl());
            IConfiguration config = Configuration.Default;
            IBrowsingContext context = BrowsingContext.New(config);
            IDocument documentVideoEmbed = await context.OpenAsync(req => req.Content(content));
            return documentVideoEmbed.QuerySelector<IHtmlDivElement>("div.userMessageSection") == null;
        }

        public TimeSpan Duration() {
            IHtmlMetaElement element = _document.QuerySelector<IHtmlMetaElement>("head > meta[property='video:duration']");
            string duration = element?.Content;
            return TimeSpan.FromSeconds(duration.TransformToInt());
        }

        public List<PornIdName> Categories() {
            IHtmlCollection<IElement> elements = _document.QuerySelectorAll("div.categoriesWrapper > a");
            return elements.OfType<IHtmlAnchorElement>()
                           .Select(anchor => new PornIdName {
                                       Id = anchor.GetAttribute("href"),
                                       Name = anchor.Text.ToHtmlDecode()
                                   })
                           .ToList();
        }

        public List<PornIdName> Tags() {
            IHtmlCollection<IElement> elements = _document.QuerySelectorAll("div.tagsWrapper > a");
            return elements.OfType<IHtmlAnchorElement>()
                           .Select(anchor => new PornIdName {
                                       Id = anchor.GetAttribute("href"),
                                       Name = anchor.Text.ToHtmlDecode().ToTitleCase()
                                   })
                           .ToList();
        }

        public List<PornIdName> Actors() {
            IHtmlCollection<IElement> elements = _document.QuerySelectorAll("div.pornstarsWrapper > a[data-mxptype='Pornstar']");
            return elements.OfType<IHtmlAnchorElement>()
                           .Select(anchor => new PornIdName {
                                       Id = anchor.GetAttribute("href"),
                                       Name = anchor.Dataset["mxptext"].ToHtmlDecode()
                                   })
                           .ToList();
        }

        public int NbViews() {
            const string searchTerm = "http://schema.org/WatchAction";
            const string pattern = "\"http://schema.org/WatchAction\",[\\s\\S]*?\"userInteractionCount\": \"([^\"]*)";
            IHtmlCollection<IElement> elements = _document.QuerySelectorAll("head > script");
            IElement element = elements.FirstOrDefault(e => e.TextContent.IndexOf(searchTerm, StringComparison.Ordinal) > 0);
            Match match = Regex.Match(element?.TextContent ?? "", pattern);
            return match.Success ? match.Groups[1].Value.TransformToInt() : 0;
        }

        public int? NbLikes() {
            IHtmlSpanElement element = _document.QuerySelector<IHtmlSpanElement>("span.votesUp");
            return element?.Dataset["rating"].TransformToInt() ?? 0;
        }

        public int? NbDislikes() {
            IHtmlSpanElement element = _document.QuerySelector<IHtmlSpanElement>("span.votesDown");
            return element?.Dataset["rating"].TransformToInt() ?? 0;
        }

        public DateTime Date() {
            IHtmlCollection<IElement> elements = _document.QuerySelectorAll("head > script");
            IElement element = elements.FirstOrDefault(e => e.TextContent.IndexOf("'dimension14'", StringComparison.Ordinal) > 0);
            Match match = Regex.Match(element?.TextContent ?? "", "'dimension14', '([^']*)");
            return match.Success ? DateTime.ParseExact(match.Groups[1].Value, "yyyyMMdd", CultureInfo.InvariantCulture) : DateTime.MinValue;
        }

        public List<PornVideoThumb> RelatedVideos() {
            IHtmlCollection<IElement> elements = _document.QuerySelectorAll("ul#recommendedVideos > li, ul#relatedVideosCenter > li");
            return elements.OfType<IHtmlListItemElement>()
                           .Select(li => new PornhubVideoThumbParser(li))
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
