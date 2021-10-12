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
    public partial class PornSearch_Search_Tests
    {
        private readonly Random _random = new Random();

        [Theory]
        [ClassData(typeof(PornWebsiteData))]
        public async Task Search_ArgumentException(PornWebsite website) {
            PornSearch pornSearch = new PornSearch();

            foreach (PornSexOrientation sexOrientation in Enum.GetValues(typeof(PornSexOrientation))) {
                for (int page = -1; page <= 0; page++) {
                    PornSearchFilter searchFilter = new PornSearchFilter {
                        Website = website,
                        SexOrientation = sexOrientation,
                        Page = page
                    };

                    await Assert.ThrowsAsync<ArgumentException>(async () => await pornSearch.SearchAsync(searchFilter));
                }
            }
        }

        [Fact]
        public async Task Search_ArgumentNullException() {
            PornSearch pornSearch = new PornSearch();

            await Assert.ThrowsAsync<ArgumentNullException>(async () => await pornSearch.SearchAsync(null));
        }

        [Theory]
        [ClassData(typeof(PornWebsiteData))]
        public async Task Search_Null(PornWebsite website) {
            PornSearch pornSearch = new PornSearch();
            PornSource source = pornSearch.GetSources().First(s => s.Website == website);

            foreach (PornSexOrientation sexOrientation in Enum.GetValues(typeof(PornSexOrientation))) {
                if (!source.SexOrientations.Contains(sexOrientation)) {
                    PornSearchFilter searchFilter = new PornSearchFilter {
                        Website = website,
                        SexOrientation = sexOrientation
                    };

                    List<PornVideoThumb> videoThumbs = await pornSearch.SearchAsync(searchFilter);

                    Assert.Null(videoThumbs);
                }
            }
        }

        [Theory]
        [ClassData(typeof(PornWebsiteData))]
        public async Task Search_EmptyFilter(PornWebsite website) {
            PornSearch pornSearch = new PornSearch();
            PornSource source = pornSearch.GetSources().First(s => s.Website == website);
            int[] pages = { 1, 2, NextRandomPage() };
            string[] filters = { null, "", "  " };
            const PageSearch pageSearch = PageSearch.Complete;

            foreach (PornSexOrientation sexOrientation in source.SexOrientations) {
                foreach (int page in pages) {
                    List<List<PornVideoThumb>> allVideoThumbsBySearch = new List<List<PornVideoThumb>>();

                    foreach (string filter in filters) {
                        List<PornVideoThumb> videoThumbs = await SearchAsync(website, sexOrientation, filter, page, pageSearch);
                        allVideoThumbsBySearch.Add(videoThumbs);

                        PornVideoThumbAssert.CheckAll(videoThumbs, website, filter, sexOrientation);
                    }

                    foreach (PornVideoThumb videoThumb1 in allVideoThumbsBySearch.First()) {
                        foreach (List<PornVideoThumb> otherVideoThumbs in allVideoThumbsBySearch.Skip(1)) {
                            PornVideoThumb videoThumb2 = otherVideoThumbs.FirstOrDefault(i => i.Id == videoThumb1.Id);

                            PornVideoThumbAssert.Equal(videoThumb1, videoThumb2);
                        }
                    }
                }
            }
        }

        [Theory]
        [ClassData(typeof(PornWebsiteData))]
        public async Task Search_OK(PornWebsite website) {
            await CheckSearchOn3PagesAsync(website, "", 1, PageSearch.Complete);
            await CheckSearchOn3PagesAsync(website, "Amateur", 1, PageSearch.Complete);
            await CheckSearchOn3PagesAsync(website, "Teen Anal", 1, PageSearch.Complete);
            await CheckSearchOn3PagesAsync(website, "Threesome", NextRandomPage(), PageSearch.Complete);
            await CheckSearchOn3PagesAsync(website, "Blowjob Cumshot Ass", 10000, PageSearch.Empty);
            await CheckSearchOn3PagesAsync(website, "azertyuiop", 1, PageSearch.Empty);
        }

        [Theory]
        [ClassData(typeof(PornWebsiteChannelData))]
        public async Task Search_SexOrientation(PornWebsite website, string channel, PornSexOrientation channelSexOrientation) {
            PornSearch pornSearch = new PornSearch();
            PornSource source = pornSearch.GetSources().First(s => s.Website == website);
            const PageSearch pageSearch = PageSearch.Channel;

            foreach (PornSexOrientation sexOrientation in source.SexOrientations) {
                List<PornVideoThumb> allVideoThumbs = new List<PornVideoThumb>();
                for (int page = 1; page <= 2; page++) {
                    List<PornVideoThumb> videoThumbs = await SearchAsync(website, sexOrientation, channel, page, pageSearch);
                    allVideoThumbs.AddRange(videoThumbs);

                    int nbVideoActor = videoThumbs.Count(i => i.Title.Contains(channel) || i.Channel.Name == channel);
                    int[] nbVideoMax = PornVideoThumbAssert.GetNbVideoMaxByPage(website, channel, page, PageSearch.Channel);
                    bool isSameSexOrientation = channelSexOrientation == sexOrientation;
                    bool otherwiseStraight = !source.SexOrientations.Contains(channelSexOrientation)
                                             && sexOrientation == PornSexOrientation.Straight;

                    if (isSameSexOrientation || otherwiseStraight) {
                        Assert.True(videoThumbs.Count >= nbVideoMax[0]);
                        Assert.True(videoThumbs.Count <= nbVideoMax[1]);
                        Assert.True(nbVideoActor > videoThumbs.Count / 2);
                    }
                    else {
                        if (videoThumbs.Count > nbVideoMax[1] / 3)
                            Assert.True(nbVideoActor <= videoThumbs.Count / 2);
                    }
                }

                PornVideoThumbAssert.CheckAll(allVideoThumbs, website, channel, sexOrientation);
            }
        }

        [Theory]
        [ClassData(typeof(PornVideoThumbData))]
        public async Task Search_VideoThumb(PornVideoThumb videoThumb) {
            PornWebsite website = videoThumb.Website;
            PornSexOrientation sexOrientation = videoThumb.SexOrientation;
            string filter = videoThumb.Title;

            List<PornVideoThumb> videoThumbs = await SearchAsync(website, sexOrientation, filter, 1, PageSearch.Partial);

            PornVideoThumb videoThumbSearch = videoThumbs.FirstOrDefault(i => i.Id == videoThumb.Id);

            PornVideoThumbAssert.CheckAll(videoThumbs, website, filter, sexOrientation);
            PornVideoThumbAssert.Equal(videoThumb, videoThumbSearch);
        }

        private static async Task
            CheckSearchOn3PagesAsync(PornWebsite website, string filter, int pageMin, PageSearch pageSearch) {
            PornSearch pornSearch = new PornSearch();
            PornSource source = pornSearch.GetSources().First(s => s.Website == website);

            foreach (PornSexOrientation sexOrientation in source.SexOrientations) {
                List<PornVideoThumb> allVideoThumbs = new List<PornVideoThumb>();

                for (int page = pageMin; page < pageMin + 3; page++) {
                    List<PornVideoThumb> videoThumbs = await SearchAsync(website, sexOrientation, filter, page, pageSearch);
                    allVideoThumbs.AddRange(videoThumbs);
                }

                PornVideoThumbAssert.CheckAll(allVideoThumbs, website, filter, sexOrientation);
            }
        }

        private static async Task<List<PornVideoThumb>> SearchAsync(PornWebsite website, PornSexOrientation sexOrientation,
                                                                    string filter, int page, PageSearch pageSearch) {
            PornSearch pornSearch = new PornSearch();
            PornSearchFilter searchFilter = new PornSearchFilter {
                Website = website,
                SexOrientation = sexOrientation,
                Filter = filter,
                Page = page
            };

            List<PornVideoThumb> videoThumbs = await pornSearch.SearchAsync(searchFilter);

            PornVideoThumbAssert.Check_NbVideo_ByPage(videoThumbs.Count, searchFilter, pageSearch);
            PornVideoThumbAssert.Check_All_Unique_Value_ByPage(videoThumbs);

            return videoThumbs;
        }

        private int NextRandomPage() {
            return _random.Next(100) + 1;
        }
    }
}
