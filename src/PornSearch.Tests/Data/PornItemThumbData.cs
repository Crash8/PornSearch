using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PornSearch.Tests.Data
{
    public class PornItemThumbData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator() {
            List<PornItemThumb> itemThumbs = GetPornhubStraight();
            itemThumbs.AddRange(GetPornhubGay());
            return itemThumbs.Select(s => new object[] { s }).GetEnumerator();
        }

        private static List<PornItemThumb> GetPornhubStraight() {
            return new List<PornItemThumb> {
                // Fix the value "&#039;" in the title
                new PornItemThumb {
                    Source = PornSource.Pornhub,
                    SexOrientation = PornSexOrientation.Straight,
                    Id = "ph5fc04dbacd1e6",
                    Title = "Valentine's Day Present is Double Fuck Threesome",
                    Channel = new PornIdName {
                        Id = "/model/miss-daisy-diamond",
                        Name = "Miss Daisy Diamond"
                    },
                    ThumbnailUrl =
                        "https://ci.phncdn.com/videos/202011/27/374175402/original/(m=eafTGgaaaa)(mh=AaHrhQhPfrLPy5_3)14.jpg"
                },
                new PornItemThumb {
                    Source = PornSource.Pornhub,
                    SexOrientation = PornSexOrientation.Straight,
                    Id = "ph5a2f7e4f9c48a",
                    Title = "PropertySex - Hot property manager fucks pissed off tenant",
                    Channel = new PornIdName {
                        Id = "/channels/property-sex",
                        Name = "Property Sex"
                    },
                    ThumbnailUrl =
                        "https://ei.phncdn.com/videos/201712/12/145091652/original/(m=eafTGgaaaa)(mh=dKfuDl_TV80fS7Wi)3.jpg"
                },
                new PornItemThumb {
                    Source = PornSource.Pornhub,
                    SexOrientation = PornSexOrientation.Straight,
                    Id = "ph5d3c7d94e38f0",
                    Title = "Asuka loves ANAL babe cosplay ATM teen ass butt  pornstar Purple Bitch",
                    Channel = new PornIdName {
                        Id = "/model/purple-bitch",
                        Name = "Purple Bitch"
                    },
                    ThumbnailUrl =
                        "https://ci.phncdn.com/videos/201907/27/237967581/original/(m=eafTGgaaaa)(mh=wsgEJN05BpMhMC7D)14.jpg"
                }
            };
        }

        private static IEnumerable<PornItemThumb> GetPornhubGay() {
            return new List<PornItemThumb> {
                new PornItemThumb {
                    Source = PornSource.Pornhub,
                    SexOrientation = PornSexOrientation.Gay,
                    Id = "ph60a518bb2da8a",
                    Title = "Marco Antonio, Pol Prince, Rafael Carreras, Joaquin Santana | Raw Foursome",
                    Channel = new PornIdName {
                        Id = "/channels/lucasentertainment",
                        Name = "Lucas Entertainment"
                    },
                    ThumbnailUrl =
                        "https://ci.phncdn.com/videos/202105/19/388272921/original/(m=eafTGgaaaa)(mh=fVKLwQqYceEaETFL)11.jpg"
                },
                new PornItemThumb {
                    Source = PornSource.Pornhub,
                    SexOrientation = PornSexOrientation.Gay,
                    Id = "ph5ff7f75ae5895",
                    Title = "Huge dick shot cum and continued to fuck the hole while making a creampie.",
                    Channel = new PornIdName {
                        Id = "/model/cris-fabio",
                        Name = "Cris Fabio"
                    },
                    ThumbnailUrl =
                        "https://ei.phncdn.com/videos/202101/08/381309022/original/(m=qM1VY-VbeafTGgaaaa)(mh=6k7w3qreddX5Pn38)0.jpg"
                }
            };
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
}
