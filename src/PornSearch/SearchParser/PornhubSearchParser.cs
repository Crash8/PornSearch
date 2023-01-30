using System;
using System.Collections.Generic;
using System.Linq;
using AngleSharp.Dom;
using AngleSharp.Html.Dom;

namespace PornSearch
{
    internal class PornhubSearchParser : IPornSearchParser
    {
        private readonly IDocument _document;
        private readonly IElement _pagination;

        public PornhubSearchParser(IDocument document) {
            _document = document;
            _pagination = _document.QuerySelector("div.pagination3");
        }

        public bool IsAvailableContent() {
            return _document.QuerySelector("div.noResultsWrapper") == null;
        }

        public bool IsAvailablePagination() {
            return _pagination != null;
        }

        public bool IsAvailableNextButton() {
            return _pagination?.QuerySelector("li.page_next:not(.disabled)") != null;
        }

        public int? GetCurrentPageNumber() {
            string number = _pagination?.QuerySelector("li.page_current span")?.TextContent;
            return number != null ? Convert.ToInt32(number) : (int?)null;
        }

        public IEnumerable<IPornVideoThumbParser> GetVideoThumbs() {
            const string selector = "ul#videoSearchResult > li.pcVideoListItem, ul#videoCategory > li.pcVideoListItem";
            IEnumerable<IHtmlListItemElement> elements = _document.QuerySelectorAll<IHtmlListItemElement>(selector);
            return elements.Select(li => new PornhubVideoThumbParser(li));
        }
    }
}
