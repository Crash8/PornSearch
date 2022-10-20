using System;
using PornSearch.Tests.Data;
using Xunit;

namespace PornSearch.Tests
{
    public class PornSearch_GetSourceVideo_Tests
    {
        [Fact]
        public void GetSourceVideo_ArgumentNullException() {
            IPornSearch pornSearch = new PornSearch();

            Assert.Throws<ArgumentNullException>(() => pornSearch.GetSourceVideo(null));
        }

        [Theory]
        [ClassData(typeof(BadVideoUrlData))]
        public void GetSourceVideo_Null(string url) {
            IPornSearch pornSearch = new PornSearch();

            PornSourceVideo sourceVideo = pornSearch.GetSourceVideo(url);

            Assert.Null(sourceVideo);
        }

        [Theory]
        [ClassData(typeof(MultipleVideoUrlData))]
        public void GetSourceVideo_MultipleVideoUrl(string[] urls, PornSourceVideo sourceVideoSource) {
            IPornSearch pornSearch = new PornSearch();

            foreach (string url in urls) {
                PornSourceVideo sourceVideo = pornSearch.GetSourceVideo(url);

                Assert.NotNull(sourceVideo);
                Assert.Equal(sourceVideoSource.Id, sourceVideo.Id);
                Assert.Equal(sourceVideoSource.Website, sourceVideo.Website);
            }
        }
    }
}
