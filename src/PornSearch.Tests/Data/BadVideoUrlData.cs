using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PornSearch.Tests.Data
{
    public class BadVideoUrlData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator() {
            List<object[]> badUrlVideo = new List<object[]>();
            badUrlVideo.AddRange(GetOtherUrl());
            foreach (PornWebsite website in ConfigForTests.GetWebsites()) {
                switch (website) {
                    case PornWebsite.Pornhub:
                        badUrlVideo.AddRange(GetPornhubUrl());
                        break;
                    case PornWebsite.XVideos:
                        badUrlVideo.AddRange(GetXVideosUrl());
                        break;
                    default: throw new ArgumentOutOfRangeException();
                }
            }
            return badUrlVideo.GetEnumerator();
        }

        private static IEnumerable<object[]> GetOtherUrl() {
            List<string> urls = new List<string> {
                "",
                "test",
                "https://www.google.com"
            };
            return urls.Select(u => new object[] { u });
        }

        private static IEnumerable<object[]> GetPornhubUrl() {
            List<string> urls = new List<string> {
                "https://www.pornhub.com/",
                "https://fr.pornhub.com/",
                "https://it.pornhub.com/video/search?search=double",
                "https://fr.pornhub.com/gay/video/search?search=double&page=10",
                "https://www.pornhub.com/video?page=5",
                "https://fr.pornhub.com/view_video.php?viewkey="
            };
            return urls.Select(u => new object[] { u });
        }

        private static IEnumerable<object[]> GetXVideosUrl() {
            List<string> urls = new List<string> {
                "https://www.xvideos.com",
                "https://www.xvideos.com/shemale",
                "https://www.xvideos.com/?k=double&typef=gay&p=8",
                "https://www.xvideos.com/new/12",
                "https://www.xvideos.com/video64117055",
                "https://www.xvideos.com/video64117056/",
                "https://www.xvideos.com/video/",
                "https://www.xvideos.com/video/test"
            };
            return urls.Select(u => new object[] { u });
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
}
