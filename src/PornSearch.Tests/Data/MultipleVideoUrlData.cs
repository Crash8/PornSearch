using System;
using System.Collections;
using System.Collections.Generic;

namespace PornSearch.Tests.Data;

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
                case PornWebsite.YouPorn:
                    badUrlVideo.Add(GetYouPornUrl());
                    break;
                default: throw new ArgumentOutOfRangeException();
            }
        }
        return badUrlVideo.GetEnumerator();
    }

    private static object[] GetPornhubUrl() {
        List<string> urls = new List<string> {
            "https://www.pornhub.com/view_video.php?viewkey=ph6157554e428e4",
            "https://fr.pornhub.com/view_video.php?viewkey=PH6157554e428e4",
            "https://rt.pornhub.COM/view_video.php?viewkey=ph6157554e428e4"
        };
        PornSourceVideo sourceVideo = new PornSourceVideo {
            Id = "ph6157554e428e4",
            Website = PornWebsite.Pornhub
        };
        return new object[] { urls, sourceVideo };
    }

    private static object[] GetXVideosUrl() {
        List<string> urls = new List<string> {
            "https://www.xvideos.com/video.iibcpok6ba4/dick_suce_transexuelle_cums",
            "https://www.xvideos.com/video.iibcpok6ba4/dick_suce",
            "https://www.xvideos.com/video.iibcpok6ba4/a"
        };
        PornSourceVideo sourceVideo = new PornSourceVideo {
            Id = "iibcpok6ba4",
            Website = PornWebsite.XVideos
        };
        return new object[] { urls, sourceVideo };
    }

    private static object[] GetYouPornUrl() {
        List<string> urls = new List<string> {
            "https://www.youporn.com/watch/16409220/hot-german-fucks-her-tight-ass/",
            "https://www.youporn.com/watch/16409220/hot-german",
            "https://www.youporn.com/watch/16409220/_",
            "https://www.youporn.com/watch/16409220/",
            "https://www.youporn.com/watch/16409220",
            "https://www.you-porn.com/watch/16409220/test",
            "https://www.youporngay.com/watch/16409220/p",
            "https://fr.youporn.com/watch/16409220/fr"
        };
        PornSourceVideo sourceVideo = new PornSourceVideo {
            Id = "16409220",
            Website = PornWebsite.YouPorn
        };
        return new object[] { urls, sourceVideo };
    }

    IEnumerator IEnumerable.GetEnumerator() {
        return GetEnumerator();
    }
}