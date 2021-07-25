using System;
using Xunit;

namespace PornSearch.Tests
{
    public class PornSourceTests
    {
        [Fact]
        public void GetSource_ArgumentNullException() {
            PornSearch pornSearch = new PornSearch();

            Assert.Throws<ArgumentNullException>(() => pornSearch.GetSource(null));
        }

        [Theory]
        [InlineData("")]
        [InlineData("Youtube")]
        public void GetSource_ArgumentException(string source) {
            PornSearch pornSearch = new PornSearch();

            Assert.Throws<ArgumentException>(() => pornSearch.GetSource(source));
        }

        [Theory]
        [InlineData(PornSource.Pornhub, typeof(PornhubSearchSource))]
        [InlineData("Pornhub", typeof(PornhubSearchSource))]
        [InlineData("PORNHUB", typeof(PornhubSearchSource))]
        [InlineData(PornSource.XVideo, typeof(XVideoSearchSource))]
        [InlineData("XVideo", typeof(XVideoSearchSource))]
        [InlineData("XVIDEO", typeof(XVideoSearchSource))]
        public void GetSource_Type(string source, Type typePornSearchSource) {
            PornSearch pornSearch = new PornSearch();
            IPornSearchSource pornSearchSource = pornSearch.GetSource(source);

            Assert.NotNull(pornSearchSource);
            Assert.Equal(pornSearchSource.GetType(), typePornSearchSource);
        }
    }
}
