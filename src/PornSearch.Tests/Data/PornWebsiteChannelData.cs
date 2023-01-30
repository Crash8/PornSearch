using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PornSearch.Tests.Data
{
    public class PornWebsiteChannelData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator() {
            List<object[]> websiteChannels = new List<object[]>();
            foreach (PornWebsite website in ConfigForTests.GetWebsites()) {
                switch (website) {
                    case PornWebsite.Pornhub:
                        websiteChannels.AddRange(GetPornhub());
                        break;
                    case PornWebsite.XVideos:
                        websiteChannels.AddRange(GetXVideos());
                        break;
                    default: throw new ArgumentOutOfRangeException();
                }
            }
            return websiteChannels.GetEnumerator();
        }

        private static IEnumerable<object[]> GetPornhub() {
            Dictionary<string, PornSexOrientation> channels = new Dictionary<string, PornSexOrientation> {
                // Pornstars
                { "Riley Reid", PornSexOrientation.Straight },
                { "Cade Maddox", PornSexOrientation.Gay },
                { "Daisy Taylor", PornSexOrientation.Trans },
                // Channels
                { "Brazzers", PornSexOrientation.Straight },
                { "Falcon Studios", PornSexOrientation.Gay },
                { "Ladyboy Gold", PornSexOrientation.Trans }
            };
            return channels.Select(c => new object[] { PornWebsite.Pornhub, c.Key, c.Value });
        }

        private static IEnumerable<object[]> GetXVideos() {
            Dictionary<string, PornSexOrientation> channels = new Dictionary<string, PornSexOrientation> {
                // Pornstars
                { "Mia Khalifa", PornSexOrientation.Straight },
                { "PIGBOY", PornSexOrientation.Gay },
                { "Lola Spais", PornSexOrientation.Trans },
                // Channels
                { "Team Skeet", PornSexOrientation.Straight },
                { "Gaywire", PornSexOrientation.Gay },
                { "GenderX Films", PornSexOrientation.Trans }
            };
            return channels.Select(c => new object[] { PornWebsite.XVideos, c.Key, c.Value });
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
}
