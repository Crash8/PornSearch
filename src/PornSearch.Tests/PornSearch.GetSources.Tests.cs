using System;
using System.Collections.Generic;
using Xunit;

namespace PornSearch.Tests
{
    public class PornSearch_GetSources_Tests
    {
        [Fact]
        public void GetSources() {
            PornSearch pornSearch = new PornSearch();
            List<PornSource> sources = pornSearch.GetSources();

            Assert.NotNull(sources);
            Assert.Equal(2, sources.Count);
            foreach (PornSource source in sources) {
                Assert.NotNull(source);
                Assert.NotNull(source.SexOrientations);
                switch (source.Website) {
                    case PornWebsite.Pornhub:
                        Assert.Equal(2, source.SexOrientations.Count);
                        Assert.Contains(PornSexOrientation.Straight, source.SexOrientations);
                        Assert.Contains(PornSexOrientation.Gay, source.SexOrientations);
                        break;
                    case PornWebsite.XVideos:
                        Assert.Equal(3, source.SexOrientations.Count);
                        Assert.Contains(PornSexOrientation.Straight, source.SexOrientations);
                        Assert.Contains(PornSexOrientation.Gay, source.SexOrientations);
                        Assert.Contains(PornSexOrientation.Trans, source.SexOrientations);
                        break;
                    default: throw new NotImplementedException();
                }
            }
        }
    }
}
