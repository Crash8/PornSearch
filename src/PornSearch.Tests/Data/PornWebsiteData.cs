using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PornSearch.Tests.Data
{
    public class PornWebsiteData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator() {
            return ConfigForTests.GetWebsites().Select(s => new object[] { s }).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
}
