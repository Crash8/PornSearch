using System;
using System.Collections.Generic;
using System.Linq;
using AngleSharp.Dom;
using AngleSharp.Html.Dom;

namespace PornSearch
{
    internal class XVideosSearchParser : IPornSearchParser
    {
        private readonly IDocument _document;
        private readonly IElement _pagination;

        public XVideosSearchParser(IDocument document) {
            _document = document;
            _pagination = _document.QuerySelector("div.pagination");
        }

        public bool IsAvailableContent() {
            return _document.QuerySelector("div.mozaique") != null;
        }

        public bool IsAvailablePagination() {
            return _pagination != null;
        }

        public bool IsAvailableNextButton() {
            return _pagination?.QuerySelector("li > a.next-page") != null;
        }

        public int? GetCurrentPageNumber() {
            return Convert.ToInt32(_pagination?.QuerySelector("li > a.active")?.TextContent);
        }

        public IEnumerable<IPornVideoThumbParser> GetVideoThumbs() {
            const string selector = "div.mozaique > div[data-id]";
            IEnumerable<IHtmlDivElement> elements = _document.QuerySelectorAll<IHtmlDivElement>(selector);
            return elements.Select(div => new XVideosVideoThumbParser(div));
        }
    }
}
