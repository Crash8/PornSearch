using System;
using System.Collections;
using System.Collections.Generic;

namespace PornSearch.Tests.Data;

public class CheckIfCanVideoEmbedInIframeData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator() {
        List<object[]> canVideoEmbedInIframeData = new List<object[]>();
        foreach (PornWebsite website in ConfigForTests.GetWebsites()) {
            switch (website) {
                case PornWebsite.Pornhub:
                    canVideoEmbedInIframeData.AddRange(GetPornhub());
                    break;
                case PornWebsite.XVideos:
                    canVideoEmbedInIframeData.AddRange(GetXVideos());
                    break;
                case PornWebsite.YouPorn:
                    canVideoEmbedInIframeData.AddRange(GetYouPorn());
                    break;
                default: throw new ArgumentOutOfRangeException();
            }
        }
        return canVideoEmbedInIframeData.GetEnumerator();
    }

    private static IEnumerable<object[]> GetPornhub() {
        return new List<object[]> {
            // Straight
            new object[] { "https://www.pornhub.com/view_video.php?viewkey=ph5fc04dbacd1e6", true },
            new object[] { "https://www.pornhub.com/view_video.php?viewkey=ph5d3c7d94e38f0", true },
            new object[] { "https://www.pornhub.com/view_video.php?viewkey=63dd6adb2b748", false },
            new object[] { "https://www.pornhub.com/view_video.php?viewkey=ph5de7d12f4fa33", false },
            // Gay
            new object[] { "https://www.pornhub.com/view_video.php?viewkey=ph5d432ce7a448c", true },
            new object[] { "https://www.pornhub.com/view_video.php?viewkey=ph610ecc9a8ca91", true }
        };
    }

    private static IEnumerable<object[]> GetXVideos() {
        return new List<object[]> {
            // Straight
            new object[] { "https://www.xvideos.com/video39773111/_", true },
            new object[] { "https://www.xvideos.com/video63965375/_", true },
            // Gay
            new object[] { "https://www.xvideos.com/video63543339/_", true },
            new object[] { "https://www.xvideos.com/video7859351/_", true },
            // Trans
            new object[] { "https://www.xvideos.com/video18936599/_", true },
            new object[] { "https://www.xvideos.com/video63886273/_", true }
        };
    }

    private static IEnumerable<object[]> GetYouPorn() {
        return new List<object[]> {
            // Straight
            new object[] { "https://www.youporn.com/watch/14545647/", true },
            new object[] { "https://www.youporn.com/watch/13449035/", true },
            new object[] { "https://www.youporn.com/watch/17139775/", false },
            new object[] { "https://www.youporn.com/watch/15227485", false },
            // Gay
            new object[] { "https://www.youporn.com/watch/16063976/", true },
            new object[] { "https://www.youporn.com/watch/15787014/", true }
        };
    }

    IEnumerator IEnumerable.GetEnumerator() {
        return GetEnumerator();
    }
}
