using System;
using System.Collections.Generic;
using System.Linq;
using AngleSharp.Dom;
using AngleSharp.Html.Dom;

namespace PornSearch
{
    internal class YouPornSearchParser : IPornSearchParser
    {
        private readonly IDocument _document;
        private readonly IElement _pagination;

        public YouPornSearchParser(IDocument document) {
            _document = document;
            _pagination = _document.QuerySelector("div#pagination");
        }

        public bool IsAvailableContent() {
            return _document.QuerySelector("div.no-result-message-wrapper") == null;
        }

        public bool IsAvailablePagination() {
            return _pagination != null;
        }

        public bool IsAvailableNextButton() {
            return _pagination?.QuerySelector("div#next div.desactive") == null;
        }

        public int? GetCurrentPageNumber() {
            return Convert.ToInt32(_pagination?.QuerySelector("li.current div")?.TextContent);
        }

        public IEnumerable<IPornVideoThumbParser> GetVideoThumbs() {
            const string selector = "div[data-espnode='video_list'] div[data-espnode='videobox']";
            List<IHtmlDivElement> elements = _document.QuerySelectorAll<IHtmlDivElement>(selector).ToList();
            if (elements.Count == 0)
                elements = _document.QuerySelectorAll<IHtmlDivElement>("div[data-espnode='videobox']").ToList();
            return elements.Select(div => new YouPornVideoThumbParser(div));
        }
    }
}
