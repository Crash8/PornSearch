using System.Collections.Generic;

namespace PornSearch
{
    internal interface IPornSearchChannelParser
    {
        bool IsAvailableContent();
        bool IsAvailablePagination();
        bool IsAvailableNextButton();
        int? GetCurrentPageNumber();
        IEnumerable<IPornVideoThumbParser> GetVideoThumbs();
    }
}
