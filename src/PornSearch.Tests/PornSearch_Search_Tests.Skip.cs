using System.Collections.Generic;
using System.Threading.Tasks;
using PornSearch.Tests.Asserts;
using PornSearch.Tests.Data;
using PornSearch.Tests.Enums;
using Xunit;

namespace PornSearch.Tests
{
    public partial class PornSearch_Search_Tests
    {
        [Theory]
        [ClassData(typeof(PornSearchLastPageData), Skip = "The last page changes value regularly")]
        public async Task Search_LastPage(PornWebsite website, string filter, PornSexOrientation sexOrientation, int lastPage) {
            List<PornVideoThumb> allVideoThumbs = new List<PornVideoThumb>();
            List<PornVideoThumb> videoThumbs;

            if (lastPage > 1) {
                videoThumbs = await SearchAsync(website, sexOrientation, filter, lastPage - 1, PageSearch.Complete);
                allVideoThumbs.AddRange(videoThumbs);
            }
            videoThumbs = await SearchAsync(website, sexOrientation, filter, lastPage, PageSearch.Partial);
            allVideoThumbs.AddRange(videoThumbs);
            await SearchAsync(website, sexOrientation, filter, lastPage + 1, PageSearch.Empty);

            PornVideoThumbAssert.CheckAll(allVideoThumbs, website, filter, sexOrientation);
        }
    }
}
