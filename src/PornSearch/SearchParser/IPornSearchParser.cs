using System.Collections.Generic;

namespace PornSearch
{
    internal interface IPornSearchParser
    {
        bool IsAvailableContent();
        bool IsAvailablePagination();
        bool IsAvailableNextButton();
        int? GetCurrentPageNumber();
        IEnumerable<IPornVideoThumbParser> GetVideoThumbs();
    }
}
