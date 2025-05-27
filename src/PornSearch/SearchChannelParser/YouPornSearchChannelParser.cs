using System;
using System.Collections.Generic;
using System.Linq;
using AngleSharp.Dom;
using AngleSharp.Html.Dom;

namespace PornSearch
{
    internal class YouPornSearchChannelParser : IPornSearchChannelParser
    {
        private readonly IDocument _document;
        private readonly IElement _pagination;

        public YouPornSearchChannelParser(IDocument document) {
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
            return _pagination?.QuerySelector("div#next div.inactive") == null;
        }

        public int? GetCurrentPageNumber() {
            return Convert.ToInt32(_pagination?.QuerySelector("li.current div")?.TextContent);
        }

        public IEnumerable<IPornVideoThumbParser> GetVideoThumbs() {
            const string selector = "div.three-thumbs-row div.video-box, div.full-row-thumbs div.video-box";
            List<IHtmlDivElement> elements = _document.QuerySelectorAll<IHtmlDivElement>(selector).ToList();
            return elements.Select(div => new YouPornVideoChannelThumbParser(div));
        }
    }
}
