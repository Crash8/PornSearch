using System;
using System.Collections;
using System.Collections.Generic;

namespace PornSearch.Tests.Data;

public class PornRelatedVideoData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator() {
        List<object[]> nbRelatedVideos = new List<object[]>();
        foreach (PornWebsite website in ConfigForTests.GetWebsites()) {
            switch (website) {
                case PornWebsite.Pornhub:
                    nbRelatedVideos.AddRange(GetPornhubStraight());
                    nbRelatedVideos.AddRange(GetPornhubGay());
                    break;
                case PornWebsite.XVideos:
                    nbRelatedVideos.AddRange(GetXVideosStraight());
                    nbRelatedVideos.AddRange(GetXVideosGay());
                    nbRelatedVideos.AddRange(GetXVideosTrans());
                    break;
                case PornWebsite.YouPorn:
                    nbRelatedVideos.AddRange(GetYouPornStraight());
                    nbRelatedVideos.AddRange(GetYouPornGay());
                    break;
                default: throw new ArgumentOutOfRangeException();
            }
        }
        return nbRelatedVideos.GetEnumerator();
    }

    private static IEnumerable<object[]> GetPornhubStraight() {
        List<object[]> nbRelatedVideos = new List<object[]> {
            new object[] { 37, 37, "https://www.pornhub.com/view_video.php?viewkey=ph5d3c7d94e38f0" },
            new object[] { 37, 37, "https://www.pornhub.com/view_video.php?viewkey=ph5f734d9e8a4c8" }
        };
        return nbRelatedVideos;
    }

    private static IEnumerable<object[]> GetPornhubGay() {
        List<object[]> nbRelatedVideos =
            new List<object[]> { new object[] { 37, 37, "https://www.pornhub.com/view_video.php?viewkey=ph610ecc9a8ca91" } };
        return nbRelatedVideos;
    }

    private static IEnumerable<object[]> GetXVideosStraight() {
        List<object[]> nbRelatedVideos = new List<object[]> { new object[] { 40, 40, "https://www.xvideos.com/video.hlfbumd4167/_" } };
        return nbRelatedVideos;
    }

    private static IEnumerable<object[]> GetXVideosGay() {
        List<object[]> nbRelatedVideos = new List<object[]> { new object[] { 40, 40, "https://www.xvideos.com/video.kvhmukd804d/_" } };
        return nbRelatedVideos;
    }

    private static IEnumerable<object[]> GetXVideosTrans() {
        List<object[]> nbRelatedVideos = new List<object[]> { new object[] { 40, 40, "https://www.xvideos.com/video.utipmab84dd/_" } };
        return nbRelatedVideos;
    }

    private static IEnumerable<object[]> GetYouPornStraight() {
        List<object[]> nbRelatedVideos = new List<object[]> {
            new object[] {
                24, 24, "https://www.youporn.com/watch/16242150/seductive-slut-amel-annoga-gets-all-her-holes-fucked-wolf-wagner/"
            }
        };
        return nbRelatedVideos;
    }

    private static IEnumerable<object[]> GetYouPornGay() {
        List<object[]> nbRelatedVideos = new List<object[]> {
            new object[] {
                24, 24, "https://www.youporn.com/watch/16030794/gaywire-four-sexy-european-studs-breeding-great-dp-action-for-your-face/"
            }
        };
        return nbRelatedVideos;
    }

    IEnumerator IEnumerable.GetEnumerator() {
        return GetEnumerator();
    }
}
