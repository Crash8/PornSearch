using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PornSearch.Tests.Data
{
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
                    default: throw new ArgumentOutOfRangeException();
                }
            }
            return sourceChannels.GetEnumerator();
        }

        private static IEnumerable<object[]> GetPornhubEmpty() {
            Dictionary<PornSexOrientation, int> lastPage = new Dictionary<PornSexOrientation, int> {
                { PornSexOrientation.Straight, 2273 },
                { PornSexOrientation.Gay, 1437 }
            };
            return lastPage.Select(c => new object[] { PornWebsite.Pornhub, "", c.Key, c.Value });
        }

        private static IEnumerable<object[]> GetPornhubOnePage() {
            Dictionary<PornSexOrientation, string> lastPage = new Dictionary<PornSexOrientation, string> {
                { PornSexOrientation.Straight, "PIGBOY" },
                { PornSexOrientation.Gay, "Nooberg" }
            };
            return lastPage.Select(c => new object[] { PornWebsite.Pornhub, c.Value, c.Key, 1 });
        }

        private static IEnumerable<object[]> GetPornhubDoubleToys() {
            Dictionary<PornSexOrientation, int> lastPage = new Dictionary<PornSexOrientation, int> {
                { PornSexOrientation.Straight, 803 },
                { PornSexOrientation.Gay, 16 }
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
                { PornSexOrientation.Gay, "1409" },
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

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
}
