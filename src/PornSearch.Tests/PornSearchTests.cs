using PornSearch.Tests.Data;
using Xunit;

namespace PornSearch.Tests
{
    public class PornSearchTests
    {
        [Theory]
        [MemberData(nameof(PornSourceData.GetAllSources), MemberType = typeof(PornSourceData))]
        public void GetSource(PornSource source) {
            PornSearch pornSearch = new PornSearch();

            IPornSearchSource pornSearchSource = pornSearch.GetSource(source);

            Assert.NotNull(pornSearchSource);
            Assert.Equal($"PornSearch.{source}SearchSource", pornSearchSource.GetType().FullName);
        }
    }
}
