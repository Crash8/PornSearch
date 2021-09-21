using System.Collections.Generic;
using System.Threading.Tasks;
using PornSearch.Tests.Asserts;
using PornSearch.Tests.Data;
using PornSearch.Tests.Enums;
using Xunit;

namespace PornSearch.Tests
{
    public partial class XxxSearchSourceTests
    {
        //[Theory]
        [ClassData(typeof(PornSearchLastPageData))]
        public async Task Search_LastPage(PornSource source, string filter, PornSexOrientation sexOrientation, int lastPage) {
            List<PornItemThumb> allItemThumbs = new List<PornItemThumb>();
            List<PornItemThumb> itemThumbs;

            if (lastPage > 1) {
                itemThumbs = await SearchAsync(source, sexOrientation, filter, lastPage - 1, PageSearch.Complete);
                allItemThumbs.AddRange(itemThumbs);
            }
            itemThumbs = await SearchAsync(source, sexOrientation, filter, lastPage, PageSearch.Partial);
            allItemThumbs.AddRange(itemThumbs);
            await SearchAsync(source, sexOrientation, filter, lastPage + 1, PageSearch.Empty);

            PornItemThumbAssert.CheckAll(allItemThumbs, source, filter, sexOrientation);
        }
    }
}
