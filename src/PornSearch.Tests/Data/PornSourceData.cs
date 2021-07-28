using System;
using System.Collections.Generic;
using System.Linq;

namespace PornSearch.Tests.Data
{
    public class PornSourceData
    {
        public static IEnumerable<object[]> GetAllSources() {
            return from PornSource source in Enum.GetValues(typeof(PornSource)) select new object[] { source };
        }
    }
}
