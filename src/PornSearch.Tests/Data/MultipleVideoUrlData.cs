using System;
using System.Collections;
using System.Collections.Generic;

namespace PornSearch.Tests.Data
{
    public class MultipleVideoUrlData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator() {
            List<object[]> badUrlVideo = new List<object[]>();
            foreach (PornWebsite website in ConfigForTests.GetWebsites()) {
                switch (website) {
                    case PornWebsite.Pornhub:
                        badUrlVideo.Add(GetPornhubUrl());
                        break;
                    case PornWebsite.XVideos:
                        badUrlVideo.Add(GetXVideosUrl());
                        break;
                    default: throw new ArgumentOutOfRangeException();
                }
            }
            return badUrlVideo.GetEnumerator();
        }

        private static object[] GetPornhubUrl() {
            List<string> urls = new List<string> {
                "https://www.pornhub.com/view_video.php?viewkey=ph5ec3a0cf12097",
                "https://fr.pornhub.com/view_video.php?viewkey=PH5ec3a0cf12097",
                "https://rt.pornhub.COM/view_video.php?viewkey=ph5ec3a0cf12097"
            };
            PornSourceVideo sourceVideo = new PornSourceVideo {
                Id = "ph5ec3a0cf12097",
                Website = PornWebsite.Pornhub
            };
            return new object[] { urls, sourceVideo };
        }

        private static object[] GetXVideosUrl() {
            List<string> urls = new List<string> {
                "https://www.xvideos.com/video36423251/dick_sucked_shemale_cums",
                "https://www.xvideos.COM/video36423251/dick_sucked",
                "https://www.xvideos.com/video36423251/",
                "https://www.xvideos.com/video36423251/test"
            };
            PornSourceVideo sourceVideo = new PornSourceVideo {
                Id = "36423251",
                Website = PornWebsite.XVideos
            };
            return new object[] { urls, sourceVideo };
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
}
