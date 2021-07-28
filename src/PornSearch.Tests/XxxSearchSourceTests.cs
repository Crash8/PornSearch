using System;
using System.Collections.Generic;
using PornSearch.Tests.Data;
using Xunit;

namespace PornSearch.Tests
{
    public class XxxSearchSourceTests
    {
        [Theory]
        [MemberData(nameof(PornSourceData.GetAllSources), MemberType = typeof(PornSourceData))]
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
    }
}
