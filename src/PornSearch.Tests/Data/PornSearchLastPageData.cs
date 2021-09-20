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
                        break;
                    case PornSource.XVideos:
                        sourceChannels.AddRange(GetXVideosEmpty());
                        break;
                    default: throw new ArgumentOutOfRangeException();
                }
            }
            return sourceChannels.GetEnumerator();
        }

        private static IEnumerable<object[]> GetPornhubEmpty() {
            Dictionary<PornSexOrientation, int> lastPage = new Dictionary<PornSexOrientation, int> {
                { PornSexOrientation.Straight, 5230 },
                { PornSexOrientation.Gay, 1409 }
            };
            return lastPage.Select(c => new object[] { PornSource.Pornhub, "", c.Key, c.Value });
        }

        private static IEnumerable<object[]> GetXVideosEmpty() {
            Dictionary<PornSexOrientation, int> lastPage = new Dictionary<PornSexOrientation, int> {
                { PornSexOrientation.Straight, 20000 },
                { PornSexOrientation.Gay, 298 },
                { PornSexOrientation.Trans, 298 }
            };
            return lastPage.Select(c => new object[] { PornSource.XVideos, "", c.Key, c.Value });
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
}
