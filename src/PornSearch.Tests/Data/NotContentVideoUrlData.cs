using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PornSearch.Tests.Data;

public class NotContentVideoUrlData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator() {
        List<object[]> badUrlVideo = new List<object[]>();
        foreach (PornWebsite website in ConfigForTests.GetWebsites()) {
            switch (website) {
                case PornWebsite.Pornhub:
                    badUrlVideo.AddRange(GetPornhubUrl());
                    break;
                case PornWebsite.XVideos:
                    badUrlVideo.AddRange(GetXVideosUrl());
                    break;
                case PornWebsite.YouPorn:
                    badUrlVideo.AddRange(GetYouPornUrl());
                    break;
                default: throw new ArgumentOutOfRangeException();
            }
        }
        return badUrlVideo.GetEnumerator();
    }

    private static IEnumerable<object[]> GetPornhubUrl() {
        List<string> urls = new List<string> {
            "https://www.pornhub.com/view_video.php?viewkey=ph5b902a4e1a5b5", // This content is unavailable in France
            "https://fr.pornhub.com/view_video.php?viewkey=ph60851ff8c987c",  // This content is unavailable in France
            "https://www.pornhub.com/view_video.php?viewkey=ph5fc04dbacd1e6", // This content is unavailable in France
            "https://fr.pornhub.com/view_video.php?viewkey=ph620fea09ca64b",  // This content is unavailable in France
            "https://en.pornhub.com/view_video.php?viewkey=XXXX",
            "https://www.pornhub.com/view_video.php?viewkey=ph40851ff8c987d"
        };
        return urls.Select(u => new object[] { u });
    }

    private static IEnumerable<object[]> GetXVideosUrl() {
        List<string> urls = new List<string> {
            "https://www.xvideos.com/video39855197/_",  // The uploader has not made this video available in your country
            "https://www.xvideos.com/video71164191/a",  // XVideos RED
            "https://www.xvideos.com/video57788343/",
            "https://www.xvideos.com/video179088343/",
            "https://www.xvideos.com/video27488043/test"
        };
        return urls.Select(u => new object[] { u });
    }

    private static IEnumerable<object[]> GetYouPornUrl() {
        List<string> urls = new List<string> {
            "https://www.youporn.com/watch/16325190/",  // This page is not available in your country
            "https://www.youporn.com/watch/17150251/",  // This video has been deactivated.
            "https://www.youporn.com/watch/17065083/",  // This page is not available in your location
            "https://www.youporn.com/watch/16492415/",
            "https://www.youporn.com/watch/XXXX/"
        };
        return urls.Select(u => new object[] { u });
    }

    IEnumerator IEnumerable.GetEnumerator() {
        return GetEnumerator();
    }
}