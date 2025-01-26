using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PornSearch.Tests.Data;

public class PornSearchLastPageData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator() {
        List<object[]> sourceChannels = new List<object[]>();
        foreach (PornWebsite website in ConfigForTests.GetWebsites()) {
            switch (website) {
                case PornWebsite.Pornhub:
                    sourceChannels.AddRange(GetPornhubEmpty());
                    sourceChannels.AddRange(GetPornhubOnePage());
                    sourceChannels.AddRange(GetPornhubDoubleToys());
                    break;
                case PornWebsite.XVideos:
                    sourceChannels.AddRange(GetXVideosEmpty());
                    sourceChannels.AddRange(GetXVideosOnePage());
                    sourceChannels.AddRange(GetXVideosDoubleToys());
                    break;
                case PornWebsite.YouPorn:
                    sourceChannels.AddRange(GetYouPornEmpty());
                    sourceChannels.AddRange(GetYouPornOnePage());
                    sourceChannels.AddRange(GetYouPornDoubleToys());
                    break;
                default: throw new ArgumentOutOfRangeException();
            }
        }
        return sourceChannels.GetEnumerator();
    }

    private static IEnumerable<object[]> GetPornhubEmpty() {
        Dictionary<PornSexOrientation, int> lastPage = new Dictionary<PornSexOrientation, int> {
            { PornSexOrientation.Straight, 455 },
            { PornSexOrientation.Gay, 455 }
        };
        return lastPage.Select(c => new object[] { PornWebsite.Pornhub, "", c.Key, c.Value });
    }

    private static IEnumerable<object[]> GetPornhubOnePage() {
        Dictionary<PornSexOrientation, string> lastPage = new Dictionary<PornSexOrientation, string> {
            { PornSexOrientation.Straight, "abd7" },
            { PornSexOrientation.Gay, "Nooberg" }
        };
        return lastPage.Select(c => new object[] { PornWebsite.Pornhub, c.Value, c.Key, 1 });
    }

    private static IEnumerable<object[]> GetPornhubDoubleToys() {
        Dictionary<PornSexOrientation, int> lastPage = new Dictionary<PornSexOrientation, int> {
            { PornSexOrientation.Straight, 100 },
            { PornSexOrientation.Gay, 14 }
        };
        return lastPage.Select(c => new object[] { PornWebsite.Pornhub, "Double Toys", c.Key, c.Value });
    }

    private static IEnumerable<object[]> GetXVideosEmpty() {
        Dictionary<PornSexOrientation, int> lastPage = new Dictionary<PornSexOrientation, int> {
            { PornSexOrientation.Straight, 20000 },
            { PornSexOrientation.Gay, 297 },
            { PornSexOrientation.Trans, 297 }
        };
        return lastPage.Select(c => new object[] { PornWebsite.XVideos, "", c.Key, c.Value });
    }

    private static IEnumerable<object[]> GetXVideosOnePage() {
        Dictionary<PornSexOrientation, string> lastPage = new Dictionary<PornSexOrientation, string> {
            { PornSexOrientation.Straight, "PIGBOY" },
            { PornSexOrientation.Gay, "1403" },
            { PornSexOrientation.Trans, "PIGBOY" }
        };
        return lastPage.Select(c => new object[] { PornWebsite.XVideos, c.Value, c.Key, 1 });
    }

    private static IEnumerable<object[]> GetXVideosDoubleToys() {
        Dictionary<PornSexOrientation, int> lastPage = new Dictionary<PornSexOrientation, int> {
            { PornSexOrientation.Straight, 149 },
            { PornSexOrientation.Gay, 149 },
            { PornSexOrientation.Trans, 149 }
        };
        return lastPage.Select(c => new object[] { PornWebsite.XVideos, "Double Toys", c.Key, c.Value });
    }

    private static IEnumerable<object[]> GetYouPornEmpty() {
        Dictionary<PornSexOrientation, int> lastPage = new Dictionary<PornSexOrientation, int> {
            { PornSexOrientation.Straight, 7778 },
            { PornSexOrientation.Gay, 889 }
        };
        return lastPage.Select(c => new object[] { PornWebsite.YouPorn, "", c.Key, c.Value });
    }

    private static IEnumerable<object[]> GetYouPornOnePage() {
        Dictionary<PornSexOrientation, string> lastPage = new Dictionary<PornSexOrientation, string> {
            { PornSexOrientation.Straight, "amap" },
            { PornSexOrientation.Gay, "abd" }
        };
        return lastPage.Select(c => new object[] { PornWebsite.YouPorn, c.Value, c.Key, 1 });
    }

    private static IEnumerable<object[]> GetYouPornDoubleToys() {
        Dictionary<PornSexOrientation, int> lastPage = new Dictionary<PornSexOrientation, int> {
            { PornSexOrientation.Straight, 115 },
            { PornSexOrientation.Gay, 3 }
        };
        return lastPage.Select(c => new object[] { PornWebsite.YouPorn, "Double Toys", c.Key, c.Value });
    }

    IEnumerator IEnumerable.GetEnumerator() {
        return GetEnumerator();
    }
}