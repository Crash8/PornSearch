using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PornSearch.Tests.Data
{
    public class PornSourceData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator() {
            return Enum.GetValues(typeof(PornSource)).Cast<PornSource>().Select(s => new object[] { s }).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
}
