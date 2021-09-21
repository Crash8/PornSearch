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
            foreach (PornSource source in Enum.GetValues(typeof(PornSource))) {
                switch (source) {
                    case PornSource.Pornhub:
                        sourceChannels.AddRange(GetPornhubEmpty());
                        sourceChannels.AddRange(GetPornhubOnePage());
                        sourceChannels.AddRange(GetPornhubDoubleToys());
                        break;
                    case PornSource.XVideos:
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
                { PornSexOrientation.Straight, 5233 },
                { PornSexOrientation.Gay, 1410 }
            };
            return lastPage.Select(c => new object[] { PornSource.Pornhub, "", c.Key, c.Value });
        }

        private static IEnumerable<object[]> GetPornhubOnePage() {
            Dictionary<PornSexOrientation, string> lastPage = new Dictionary<PornSexOrientation, string> {
                { PornSexOrientation.Straight, "PIGBOY" },
                { PornSexOrientation.Gay, "Nooberg" }
            };
            return lastPage.Select(c => new object[] { PornSource.Pornhub, c.Value, c.Key, 1 });
        }

        private static IEnumerable<object[]> GetPornhubDoubleToys() {
            Dictionary<PornSexOrientation, int> lastPage = new Dictionary<PornSexOrientation, int> {
                { PornSexOrientation.Straight, 789 },
                { PornSexOrientation.Gay, 15 }
            };
            return lastPage.Select(c => new object[] { PornSource.Pornhub, "Double Toys", c.Key, c.Value });
        }

        private static IEnumerable<object[]> GetXVideosEmpty() {
            Dictionary<PornSexOrientation, int> lastPage = new Dictionary<PornSexOrientation, int> {
                { PornSexOrientation.Straight, 20000 },
                { PornSexOrientation.Gay, 298 },
                { PornSexOrientation.Trans, 298 }
            };
            return lastPage.Select(c => new object[] { PornSource.XVideos, "", c.Key, c.Value });
        }

        private static IEnumerable<object[]> GetXVideosOnePage() {
            Dictionary<PornSexOrientation, string> lastPage = new Dictionary<PornSexOrientation, string> {
                { PornSexOrientation.Straight, "PIGBOY" },
                { PornSexOrientation.Gay, "1409" },
                { PornSexOrientation.Trans, "PIGBOY" }
            };
            return lastPage.Select(c => new object[] { PornSource.XVideos, c.Value, c.Key, 1 });
        }

        private static IEnumerable<object[]> GetXVideosDoubleToys() {
            Dictionary<PornSexOrientation, int> lastPage = new Dictionary<PornSexOrientation, int> {
                { PornSexOrientation.Straight, 149 },
                { PornSexOrientation.Gay, 149 },
                { PornSexOrientation.Trans, 149 }
            };
            return lastPage.Select(c => new object[] { PornSource.XVideos, "Double Toys", c.Key, c.Value });
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
}
