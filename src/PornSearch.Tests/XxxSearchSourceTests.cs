using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PornSearch.Tests.Data;
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

            await SearchAsync(source, pornSearchSource, null, 1, 1, false);
            await SearchAsync(source, pornSearchSource, "", 1, 1, false);
            await SearchAsync(source, pornSearchSource, "  ", 1, 1, false);
            await SearchAsync(source, pornSearchSource, "Amateur", 1, 3, false);
            await SearchAsync(source, pornSearchSource, "Teen Anal", 1, 3, false);
            await SearchAsync(source, pornSearchSource, "Blowjob Cumshot Ass", 10000, 10000, true);
            await SearchAsync(source, pornSearchSource, "azertyuiop", 1, 1, true);
        }

        private static async Task SearchAsync(PornSource source, IPornSearchSource searchSource, string filter, int pageMin,
                                              int pageMax, bool empty) {
            List<PornSexOrientation> sexOrientations = searchSource.GetSexOrientations();
            foreach (PornSexOrientation sexOrientation in Enum.GetValues(typeof(PornSexOrientation))) {
                if (sexOrientations.Contains(sexOrientation)) {
                    List<PornItemThumb> allItemThumbs = new List<PornItemThumb>();
                    for (int page = pageMin; page <= pageMax; page++) {
                        PornSearchFilter pornSearchFilter = new PornSearchFilter {
                            SexOrientation = sexOrientation,
                            Filter = filter,
                            Page = page
                        };

                        List<PornItemThumb> itemThumbs = await searchSource.SearchAsync(pornSearchFilter);

                        allItemThumbs.AddRange(itemThumbs);

                        Assert.NotNull(itemThumbs);

                        if (empty) {
                            Assert.Empty(itemThumbs);
                            continue;
                        }

                        Assert.Equal(GetNbItem(source, pornSearchFilter), itemThumbs.Count);

                        foreach (PornItemThumb item in itemThumbs) {
                            Assert.NotNull(item.Id);
                            Assert.True(item.Id.Length > 1);
                            Assert.DoesNotContain(" ", item.Id);

                            Assert.NotNull(item.Title);
                            Assert.True(item.Title.Length > 1);

                            Assert.NotNull(item.Channel);
                            Assert.NotNull(item.Channel.Id);
                            Assert.True(item.Channel.Id.Length > 1);
                            Assert.DoesNotContain(" ", item.Channel.Id);

                            Assert.NotNull(item.Channel.Name);
                            Assert.True(item.Channel.Name.Length > 1);

                            Assert.NotNull(item.ThumbnailUrl);
                            Assert.StartsWith("https://", item.ThumbnailUrl.ToLower());
                            Assert.DoesNotContain(" ", item.ThumbnailUrl);
                            Assert.EndsWith(".jpg", item.ThumbnailUrl.ToLower());

                            Assert.NotEqual(item.Id, item.Title);
                            Assert.NotEqual(item.Id, item.Channel.Id);
                            Assert.NotEqual(item.Id, item.Channel.Name);
                            Assert.NotEqual(item.Id, item.ThumbnailUrl);

                            Assert.NotEqual(item.Title, item.Channel.Id);
                            Assert.NotEqual(item.Title, item.Channel.Name);
                            Assert.NotEqual(item.Title, item.ThumbnailUrl);

                            Assert.NotEqual(item.Channel.Id, item.Channel.Name);
                            Assert.NotEqual(item.Channel.Id, item.ThumbnailUrl);

                            Assert.NotEqual(item.Channel.Name, item.ThumbnailUrl);
                        }
                    }

                    Assert.Equal(allItemThumbs.Count, allItemThumbs.Select(i => i.Id).Distinct().Count());
                    Assert.Equal(allItemThumbs.Count, allItemThumbs.Select(i => i.ThumbnailUrl).Distinct().Count());
                }
            }
        }

        private static int GetNbItem(PornSource source, PornSearchFilter searchFilter) {
            if (source == PornSource.Pornhub) {
                if (string.IsNullOrWhiteSpace(searchFilter.Filter))
                    return searchFilter.Page == 1 ? 32 : 43;
                return 20;
            }
            throw new NotImplementedException();
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
    }
}
