using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PornSearch.Tests.Asserts;
using PornSearch.Tests.Data;
using PornSearch.Tests.Enums;
using Xunit;

namespace PornSearch.Tests
{
    public class XxxSearchSourceTests
    {
        [Theory]
        [ClassData(typeof(PornSourceData))]
        public void GetOrientations(PornSource source) {
            PornSearch pornSearch = new PornSearch();
            IPornSearchSource pornSearchSource = pornSearch.GetSource(source);

            List<PornSexOrientation> sexOrientations = pornSearchSource.GetSexOrientations();

            Assert.NotNull(sexOrientations);
            switch (source) {
                case PornSource.Pornhub:
                    Assert.Equal(2, sexOrientations.Count);
                    Assert.Contains(PornSexOrientation.Straight, sexOrientations);
                    Assert.Contains(PornSexOrientation.Gay, sexOrientations);
                    break;
                case PornSource.XVideos:
                    Assert.Equal(3, sexOrientations.Count);
                    Assert.Contains(PornSexOrientation.Straight, sexOrientations);
                    Assert.Contains(PornSexOrientation.Gay, sexOrientations);
                    Assert.Contains(PornSexOrientation.Trans, sexOrientations);
                    break;
                default: throw new NotImplementedException();
            }
        }

        [Theory]
        [ClassData(typeof(PornSourceData))]
        public async Task Search_ArgumentException(PornSource source) {
            PornSearch pornSearch = new PornSearch();
            IPornSearchSource searchSource = pornSearch.GetSource(source);

            foreach (PornSexOrientation sexOrientation in Enum.GetValues(typeof(PornSexOrientation))) {
                for (int page = -1; page <= 0; page++) {
                    PornSearchFilter searchFilter = new PornSearchFilter {
                        SexOrientation = sexOrientation,
                        Page = page
                    };

                    await Assert.ThrowsAsync<ArgumentException>(() => searchSource.SearchAsync(searchFilter));
                }
            }
        }

        [Theory]
        [ClassData(typeof(PornSourceData))]
        public async Task Search_ArgumentNullException(PornSource source) {
            PornSearch pornSearch = new PornSearch();
            IPornSearchSource searchSource = pornSearch.GetSource(source);

            await Assert.ThrowsAsync<ArgumentNullException>(() => searchSource.SearchAsync(null));
        }

        [Theory]
        [ClassData(typeof(PornSourceData))]
        public async Task Search_Null(PornSource source) {
            PornSearch pornSearch = new PornSearch();
            IPornSearchSource pornSearchSource = pornSearch.GetSource(source);
            List<PornSexOrientation> sexOrientations = pornSearchSource.GetSexOrientations();

            foreach (PornSexOrientation sexOrientation in Enum.GetValues(typeof(PornSexOrientation))) {
                if (!sexOrientations.Contains(sexOrientation)) {
                    PornSearchFilter pornSearchFilter = new PornSearchFilter { SexOrientation = sexOrientation };

                    List<PornItemThumb> itemThumbs = await pornSearchSource.SearchAsync(pornSearchFilter);

                    Assert.Null(itemThumbs);
                }
            }
        }

        [Theory]
        [ClassData(typeof(PornSourceData))]
        public async Task Search_OK(PornSource source) {
            PornSearch pornSearch = new PornSearch();
            IPornSearchSource pornSearchSource = pornSearch.GetSource(source);

            await SearchAsync(source, pornSearchSource, null, 1, 3, PageSearchFill.Complete);
            await SearchAsync(source, pornSearchSource, "", 1, 3, PageSearchFill.Complete);
            await SearchAsync(source, pornSearchSource, "  ", 1, 3, PageSearchFill.Complete);
            await SearchAsync(source, pornSearchSource, "Amateur", 1, 3, PageSearchFill.Complete);
            await SearchAsync(source, pornSearchSource, "Teen Anal", 1, 3, PageSearchFill.Complete);
            await SearchAsync(source, pornSearchSource, "Blowjob Cumshot Ass", 10000, 10003, PageSearchFill.Empty);
            await SearchAsync(source, pornSearchSource, "azertyuiop", 1, 3, PageSearchFill.Empty);
        }

        private static async Task SearchAsync(PornSource source, IPornSearchSource searchSource, string filter, int pageMin,
                                              int pageMax, PageSearchFill pageSearchFill) {
            List<PornSexOrientation> sexOrientations = searchSource.GetSexOrientations();
            foreach (PornSexOrientation sexOrientation in Enum.GetValues(typeof(PornSexOrientation))) {
                if (sexOrientations.Contains(sexOrientation)) {
                    List<PornItemThumb> allItemThumbs = new List<PornItemThumb>();
                    for (int page = pageMin; page <= pageMax; page++) {
                        PornSearchFilter searchFilter = new PornSearchFilter {
                            SexOrientation = sexOrientation,
                            Filter = filter,
                            Page = page
                        };

                        List<PornItemThumb> itemThumbs = await searchSource.SearchAsync(searchFilter);
                        allItemThumbs.AddRange(itemThumbs);

                        PornItemThumbAssert.Check_NbItem_ByPage(itemThumbs.Count, source, searchFilter, pageSearchFill);
                        PornItemThumbAssert.Check_All_Unique_Value_ByPage(itemThumbs, source);
                    }

                    PornItemThumbAssert.CheckAll(allItemThumbs, source, filter, sexOrientation);
                }
            }
        }
    }
}
