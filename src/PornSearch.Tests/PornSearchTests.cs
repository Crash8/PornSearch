using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace PornSearch.Tests
{
    public class PornSearchTests
    {
        [Theory]
        [MemberData(nameof(PornSourceData))]
        public void GetSource(PornSource source) {
            PornSearch pornSearch = new PornSearch();
            IPornSearchSource pornSearchSource = pornSearch.GetSource(source);

            Assert.NotNull(pornSearchSource);
            Assert.Equal($"PornSearch.{source}SearchSource", pornSearchSource.GetType().FullName);
        }

        public static IEnumerable<object[]> PornSourceData() {
            return from PornSource source in Enum.GetValues(typeof(PornSource)) select new object[] { source };
        }
    }
}
