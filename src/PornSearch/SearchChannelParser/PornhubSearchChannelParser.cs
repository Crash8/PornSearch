using System;
using System.Collections.Generic;
using System.Linq;
using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using PornSearch.Extensions;

namespace PornSearch
{
    internal class PornhubSearchChannelParser : IPornSearchChannelParser
    {
        private readonly IDocument _document;
        private readonly IElement _pagination;
        private readonly PornIdName _channel;

        public PornhubSearchChannelParser(IDocument document) {
            _document = document;
            _pagination = _document.QuerySelector("div.pagination3");
            _channel = GetChannel();
        }

        public bool IsAvailableContent() {
            return _channel != null;
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
            const string selectorPornstar = "ul#moreData > li.pcVideoListItem";
            const string selectorModel = "ul#mostRecentVideosSection > li.pcVideoListItem";
            const string selectorChannel = "ul#showAllChanelVideos > li.pcVideoListItem";
            string selector = $"{selectorPornstar}, {selectorModel}, {selectorChannel}";
            IEnumerable<IHtmlListItemElement> elements = _document.QuerySelectorAll<IHtmlListItemElement>(selector);
            return elements.Select(li => new PornhubVideoChannelThumbParser(li, _channel));
        }

        private PornIdName GetChannel() {
            IHtmlAnchorElement elementChannelId = _document.QuerySelector<IHtmlAnchorElement>("li#profileHome a")
                                                  ?? _document.QuerySelector<IHtmlAnchorElement>("ul.subFilterList a");
            IElement elementChannelName = _document.QuerySelector("div.nameSubscribe h1") ?? _document.QuerySelector("div.titleWrapper h1");
            if (elementChannelId == null) {
                elementChannelId = _document.QuerySelector<IHtmlAnchorElement>("div.profileUserName a");
                elementChannelName = elementChannelId;
            }
            return elementChannelId == null || elementChannelName == null
                ? null
                : new PornIdName {
                    Id = elementChannelId.GetAttribute("href"),
                    Name = elementChannelName.TextContent.ToHtmlDecode()
                };
        }
    }
}
