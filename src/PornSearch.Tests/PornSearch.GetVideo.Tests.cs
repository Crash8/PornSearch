using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PornSearch.Tests.Asserts;
using PornSearch.Tests.Data;
using Xunit;

namespace PornSearch.Tests
{
    public class PornSearch_GetVideo_Tests
    {
        private readonly Random _random = new Random();

        [Fact]
        public async Task GetVideo_ArgumentNullException() {
            PornSearch pornSearch = new PornSearch();

            await Assert.ThrowsAsync<ArgumentNullException>(async () => await pornSearch.GetVideoAsync(null));
        }

        [Theory]
        [ClassData(typeof(BadVideoUrlData))]
        public async Task GetVideo_Null_BadVideoUrl(string url) {
            PornSearch pornSearch = new PornSearch();

            PornVideo video = await pornSearch.GetVideoAsync(url);

            Assert.Null(video);
        }

        [Theory]
        [ClassData(typeof(NotContentVideoUrlData))]
        public async Task GetVideo_Null_NotContentVideoUrl(string url) {
            PornSearch pornSearch = new PornSearch();

            PornVideo video = await pornSearch.GetVideoAsync(url);

            Assert.Null(video);
        }

        [Theory]
        [ClassData(typeof(PornWebsiteData))]
        public async Task GetVideo_Search(PornWebsite website) {
            await CheckVideosInSearchOnPagesAsync(website, "", 1);
            await CheckVideosInSearchOnPagesAsync(website, "Amateur", 1);
            await CheckVideosInSearchOnPagesAsync(website, "Teen Anal", 1);
            await CheckVideosInSearchOnPagesAsync(website, "é", 1);
            await CheckVideosInSearchOnPagesAsync(website, "Threesome", NextRandomPage());
            await CheckVideosInSearchOnPagesAsync(website, "Blowjob Cumshot Ass", NextRandomPage());
        }

        private int NextRandomPage() {
            return _random.Next(100) + 1;
        }

        private async Task CheckVideosInSearchOnPagesAsync(PornWebsite website, string filter, int pageMin) {
            PornSearch pornSearch = new PornSearch();
            PornSource source = pornSearch.GetSources().First(s => s.Website == website);

            foreach (PornSexOrientation sexOrientation in source.SexOrientations) {
                for (int page = pageMin; page < pageMin + 1; page++)
                    await SearchVideosAsync(website, sexOrientation, filter, page);
            }
        }

        private async Task SearchVideosAsync(PornWebsite website, PornSexOrientation sexOrientation, string filter, int page) {
            PornSearch pornSearch = new PornSearch();
            PornSearchFilter searchFilter = new PornSearchFilter {
                Website = website,
                SexOrientation = sexOrientation,
                Filter = filter,
                Page = page
            };
            List<PornVideoThumb> videoThumbs = await pornSearch.SearchAsync(searchFilter);

            foreach (PornVideoThumb videoThumb in videoThumbs) {
                PornVideo video = await pornSearch.GetVideoAsync(videoThumb.PageUrl);

                PornVideoAssert.Check(video, videoThumb);
            }
        }

        [Theory]
        [ClassData(typeof(MultipleVideoUrlData))]
        public async Task GetVideo_MultipleVideoUrl(string[] urls, PornSourceVideo sourceVideo) {
            PornSearch pornSearch = new PornSearch();
            List<PornVideo> videos = new List<PornVideo>();

            foreach (string url in urls) {
                PornVideo video = await pornSearch.GetVideoAsync(url);
                videos.Add(video);

                // Just to use "sourceVideo" and keep the same data source
                Assert.Equal(sourceVideo.Id, video.Id);
                Assert.Equal(sourceVideo.Website, video.Website);
            }

            PornVideo video1 = videos.First();
            foreach (PornVideo video2 in videos.Skip(1))
                PornVideoAssert.Equal(video1, video2);
        }

        [Theory]
        [ClassData(typeof(PornVideoData))]
        public async Task GetVideo_Video(PornVideo videoSource) {
            PornSearch pornSearch = new PornSearch();

            PornVideo video = await pornSearch.GetVideoAsync(videoSource.PageUrl);

            PornVideoAssert.Equal(videoSource, video);
        }
    }
}
