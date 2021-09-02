using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PornSearch.Tests.Data
{
    public class PornSourceChannelData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator() {
            List<object[]> sourceChannels = new List<object[]>();
            foreach (PornSource source in Enum.GetValues(typeof(PornSource))) {
                switch (source) {
                    case PornSource.Pornhub:
                        sourceChannels.AddRange(GetPornhub());
                        break;
                    case PornSource.XVideos:
                        sourceChannels.AddRange(GetXVideos());
                        break;
                    default: throw new ArgumentOutOfRangeException();
                }
            }
            return sourceChannels.GetEnumerator();
        }

        private static IEnumerable<object[]> GetPornhub() {
            Dictionary<string, PornSexOrientation> channels = new Dictionary<string, PornSexOrientation> {
                // Pornstars
                { "Riley Reid", PornSexOrientation.Straight },
                { "Cade Maddox", PornSexOrientation.Gay },
                { "Daisy Taylor", PornSexOrientation.Trans },
                // Channels
                { "Brazzers", PornSexOrientation.Straight },
                { "Black Male Me", PornSexOrientation.Gay },
                { "Dream Tranny", PornSexOrientation.Trans },
                // Models
                { "yinyleon", PornSexOrientation.Straight },
                { "Zilv Gudel", PornSexOrientation.Gay },
                { "Kasey Kei", PornSexOrientation.Trans }
            };
            return channels.Select(c => new object[] { PornSource.Pornhub, c.Key, c.Value });
        }

        private static IEnumerable<object[]> GetXVideos() {
            Dictionary<string, PornSexOrientation> channels = new Dictionary<string, PornSexOrientation> {
                // Pornstars
                { "Lana Rhoades", PornSexOrientation.Straight },
                { "Tim Kruger", PornSexOrientation.Gay },
                { "Chanel Santini", PornSexOrientation.Trans },
                // Pornstars Channels
                { "Mia Khalifa", PornSexOrientation.Straight },
                { "PIGBOY", PornSexOrientation.Gay },
                { "Mariana Cordoba", PornSexOrientation.Trans },
                // Channels
                { "Team Skeet", PornSexOrientation.Straight },
                { "Hot Boys", PornSexOrientation.Gay },
                { "Ladyboy Gold", PornSexOrientation.Trans },
                // Amateurs Channels
                { "Angel Emily", PornSexOrientation.Straight },
                { "Gaktrizzy", PornSexOrientation.Gay },
                { "Nathalia Fontes", PornSexOrientation.Trans }
            };
            return channels.Select(c => new object[] { PornSource.Pornhub, c.Key, c.Value });
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
}
