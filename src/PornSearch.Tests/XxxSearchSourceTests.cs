using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PornSearch.Tests.Asserts;
using PornSearch.Tests.Data;
using PornSearch.Tests.Enums;
using Xunit;

namespace PornSearch.Tests
{
    public partial class XxxSearchSourceTests
    {
        private readonly Random _random = new Random();

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
            IPornSearchSource pornSearchSource = pornSearch.GetSource(source);

            foreach (PornSexOrientation sexOrientation in Enum.GetValues(typeof(PornSexOrientation))) {
                for (int page = -1; page <= 0; page++) {
                    PornSearchFilter searchFilter = new PornSearchFilter {
                        SexOrientation = sexOrientation,
                        Page = page
                    };

                    await Assert.ThrowsAsync<ArgumentException>(() => pornSearchSource.SearchAsync(searchFilter));
                }
            }
        }

        [Theory]
        [ClassData(typeof(PornSourceData))]
        public async Task Search_ArgumentNullException(PornSource source) {
            PornSearch pornSearch = new PornSearch();
            IPornSearchSource pornSearchSource = pornSearch.GetSource(source);

            await Assert.ThrowsAsync<ArgumentNullException>(() => pornSearchSource.SearchAsync(null));
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
        public async Task Search_EmptyFilter(PornSource source) {
            PornSearch pornSearch = new PornSearch();
            IPornSearchSource pornSearchSource = pornSearch.GetSource(source);
            int[] pages = { 1, 2, NextRandomPage() };
            string[] filters = { null, "", "  " };

            foreach (PornSexOrientation sexOrientation in pornSearchSource.GetSexOrientations()) {
                foreach (int page in pages) {
                    List<List<PornItemThumb>> allItemThumbsBySearch = new List<List<PornItemThumb>>();

                    foreach (string filter in filters) {
                        List<PornItemThumb> thumbs = await SearchAsync(source, sexOrientation, filter, page, PageSearch.Complete);
                        allItemThumbsBySearch.Add(thumbs);

                        PornItemThumbAssert.CheckAll(thumbs, source, filter, sexOrientation);
                    }

                    foreach (PornItemThumb item1 in allItemThumbsBySearch.First()) {
                        foreach (List<PornItemThumb> otherItemThumbs in allItemThumbsBySearch.Skip(1)) {
                            PornItemThumb item2 = otherItemThumbs.FirstOrDefault(i => i.Id == item1.Id);

                            PornItemThumbAssert.Equal(item1, item2);
                        }
                    }
                }
            }
        }

        [Theory]
        [ClassData(typeof(PornSourceData))]
        public async Task Search_OK(PornSource source) {
            await CheckSearchOn3PagesAsync(source, "", 1, PageSearch.Complete);
            await CheckSearchOn3PagesAsync(source, "Amateur", 1, PageSearch.Complete);
            await CheckSearchOn3PagesAsync(source, "Teen Anal", 1, PageSearch.Complete);
            await CheckSearchOn3PagesAsync(source, "Threesome", NextRandomPage(), PageSearch.Complete);
            await CheckSearchOn3PagesAsync(source, "Blowjob Cumshot Ass", 10000, PageSearch.Empty);
            await CheckSearchOn3PagesAsync(source, "azertyuiop", 1, PageSearch.Empty);
        }

        [Theory]
        [ClassData(typeof(PornSourceChannelData))]
        public async Task Search_SexOrientation(PornSource source, string channel, PornSexOrientation channelSexOrientation) {
            PornSearch pornSearch = new PornSearch();
            IPornSearchSource pornSearchSource = pornSearch.GetSource(source);
            List<PornSexOrientation> sexOrientations = pornSearchSource.GetSexOrientations();

            foreach (PornSexOrientation sexOrientation in sexOrientations) {
                List<PornItemThumb> allItemThumbs = new List<PornItemThumb>();
                for (int page = 1; page <= 2; page++) {
                    List<PornItemThumb> itemThumbs = await SearchAsync(source, sexOrientation, channel, page, PageSearch.Channel);
                    allItemThumbs.AddRange(itemThumbs);

                    int nbItemActor = itemThumbs.Count(i => i.Title.Contains(channel) || i.Channel.Name == channel);
                    const PageSearch pageSearch = PageSearch.Channel;
                    int[] nbItemMax = PornItemThumbAssert.GetNbItemMaxByPage(source, channel, page, sexOrientation, pageSearch);
                    bool isSameSexOrientation = channelSexOrientation == sexOrientation;
                    bool otherwiseStraight = !sexOrientations.Contains(channelSexOrientation)
                                             && sexOrientation == PornSexOrientation.Straight;

                    if (isSameSexOrientation || otherwiseStraight) {
                        Assert.True(itemThumbs.Count >= nbItemMax[0]);
                        Assert.True(itemThumbs.Count <= nbItemMax[1]);
                        Assert.True(nbItemActor > itemThumbs.Count / 2);
                    }
                    else {
                        if (itemThumbs.Count > nbItemMax[1] / 3)
                            Assert.True(nbItemActor <= itemThumbs.Count / 2);
                    }
                }

                PornItemThumbAssert.CheckAll(allItemThumbs, source, channel, sexOrientation);
            }
        }

        [Theory]
        [ClassData(typeof(PornItemThumbData))]
        public async Task Search_ItemThumb(PornItemThumb itemThumb) {
            PornSource source = itemThumb.Source;
            PornSexOrientation sexOrientation = itemThumb.SexOrientation;
            string filter = itemThumb.Title;

            List<PornItemThumb> itemThumbs = await SearchAsync(source, sexOrientation, filter, 1, PageSearch.Partial);

            PornItemThumb itemThumbSearch = itemThumbs.FirstOrDefault(i => i.Id == itemThumb.Id);

            PornItemThumbAssert.CheckAll(itemThumbs, source, filter, sexOrientation);
            PornItemThumbAssert.Equal(itemThumb, itemThumbSearch);
        }

        private static async Task CheckSearchOn3PagesAsync(PornSource source, string filter, int pageMin, PageSearch pageSearch) {
            PornSearch pornSearch = new PornSearch();
            IPornSearchSource pornSearchSource = pornSearch.GetSource(source);

            foreach (PornSexOrientation sexOrientation in pornSearchSource.GetSexOrientations()) {
                List<PornItemThumb> allItemThumbs = new List<PornItemThumb>();

                for (int page = pageMin; page < pageMin + 3; page++) {
                    List<PornItemThumb> itemThumbs = await SearchAsync(source, sexOrientation, filter, page, pageSearch);
                    allItemThumbs.AddRange(itemThumbs);
                }

                PornItemThumbAssert.CheckAll(allItemThumbs, source, filter, sexOrientation);
            }
        }

        private static async Task<List<PornItemThumb>> SearchAsync(PornSource source, PornSexOrientation sexOrientation,
                                                                   string filter, int page, PageSearch pageSearch) {
            PornSearch pornSearch = new PornSearch();
            IPornSearchSource pornSearchSource = pornSearch.GetSource(source);

            PornSearchFilter searchFilter = new PornSearchFilter {
                SexOrientation = sexOrientation,
                Filter = filter,
                Page = page
            };

            List<PornItemThumb> itemThumbs = await pornSearchSource.SearchAsync(searchFilter);

            PornItemThumbAssert.Check_NbItem_ByPage(itemThumbs.Count, source, searchFilter, pageSearch);
            PornItemThumbAssert.Check_All_Unique_Value_ByPage(itemThumbs);

            return itemThumbs;
        }

        private int NextRandomPage() {
            return _random.Next(100) + 1;
        }
    }
}
