using System;
using System.Collections.Generic;
using System.Linq;

namespace PornSearch.Tests
{
    public static class ConfigForTests
    {
        public static List<PornWebsite> GetWebsites() {
            return Enum.GetValues(typeof(PornWebsite))
                       .Cast<PornWebsite>()
                       //.Where(w => w == PornWebsite.XVideos)  // "Where" to use to filter websites for testing
                       .ToList();
        }
    }
}
