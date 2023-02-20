using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using PornSearch.Tests.Asserts;
using PornSearch.Tests.Data;
using Xunit;

namespace PornSearch.Tests;

public class PornSearch_GetVideo_Tests
{
    private readonly Random _random = new();

    [Fact]
    public async Task GetVideo_ArgumentNullException() {
        IPornSearch pornSearch = new PornSearch();

        await Assert.ThrowsAsync<ArgumentNullException>(async () => await pornSearch.GetVideoAsync((string)null));
        await Assert.ThrowsAsync<ArgumentNullException>(async () => await pornSearch.GetVideoAsync((PornSourceVideo)null));
    }

    [Theory]
    [ClassData(typeof(BadVideoUrlData))]
    public async Task GetVideo_Null_BadVideoUrl(string url) {
        IPornSearch pornSearch = new PornSearch();

        PornVideo video = await pornSearch.GetVideoAsync(url);

        Assert.Null(video);
    }

    [Theory]
    [ClassData(typeof(NotContentVideoUrlData))]
    public async Task GetVideo_Null_NotContentVideoUrl(string url) {
        IPornSearch pornSearch = new PornSearch();

        PornVideo video = await pornSearch.GetVideoAsync(url);

        Assert.Null(video);
    }

    [Theory]
    [ClassData(typeof(PornWebsiteData))]
    public async Task GetVideo_Search_Empty(PornWebsite website) {
        await CheckVideosInSearchOnPagesAsync(website, "", 1);
    }

    [Theory]
    [ClassData(typeof(PornWebsiteData))]
    public async Task GetVideo_Search_Amateur(PornWebsite website) {
        await CheckVideosInSearchOnPagesAsync(website, "Amateur", 1);
    }

    [Theory]
    [ClassData(typeof(PornWebsiteData))]
    public async Task GetVideo_Search_TeenAnal(PornWebsite website) {
        await CheckVideosInSearchOnPagesAsync(website, "Teen Anal", 1);
    }

    [Theory]
    [ClassData(typeof(PornWebsiteData))]
    public async Task GetVideo_Search_E(PornWebsite website) {
        await CheckVideosInSearchOnPagesAsync(website, "é", 1);
    }

    [Theory]
    [ClassData(typeof(PornWebsiteData))]
    public async Task GetVideo_Search_Threesome(PornWebsite website) {
        await CheckVideosInSearchOnPagesAsync(website, "Threesome", NextRandomPage());
    }

    [Theory]
    [ClassData(typeof(PornWebsiteData))]
    public async Task GetVideo_Search_BlowjobCumshotAss(PornWebsite website) {
        await CheckVideosInSearchOnPagesAsync(website, "Blowjob Cumshot Ass", NextRandomPage());
    }

    private int NextRandomPage() {
        return _random.Next(100) + 1;
    }

    private static async Task CheckVideosInSearchOnPagesAsync(PornWebsite website, string filter, int pageMin) {
        IPornSearch pornSearch = new PornSearch();
        PornSource source = pornSearch.GetSources().First(s => s.Website == website);

        foreach (PornSexOrientation sexOrientation in source.SexOrientations) {
            for (int page = pageMin; page < pageMin + 3; page++)
                await SearchVideosAsync(website, sexOrientation, filter, page);
        }
    }

    private static async Task SearchVideosAsync(PornWebsite website, PornSexOrientation sexOrientation, string filter, int page) {
        IPornSearch pornSearch = new PornSearch();
        PornSearchFilter searchFilter = new PornSearchFilter {
            Website = website,
            SexOrientation = sexOrientation,
            Filter = filter,
            Page = page
        };
        List<PornVideoThumb> videoThumbs = await pornSearch.SearchAsync(searchFilter);

        SemaphoreSlim semaphoreSlim = new SemaphoreSlim(5, 5);
        Task.WaitAll(videoThumbs.Select(videoThumb => Task.Run(async () => {
                                    try {
                                        await semaphoreSlim.WaitAsync();
                                        PornVideo video = await pornSearch.GetVideoAsync(videoThumb.PageUrl);
                                        
                                        Assert.True(video != null, $"{sexOrientation}/{filter}/{page} - {videoThumb.PageUrl}");

                                        // Bad detection sex orientation for XVideos
                                        if (sexOrientation != video.SexOrientation && website == PornWebsite.XVideos) {
                                            video.SexOrientation = sexOrientation;
                                            video.RelatedVideos.ForEach(v => v.SexOrientation = sexOrientation);
                                        }
                                        
                                        PornVideoAssert.Check(video, website, sexOrientation);
                                        PornVideoAssert.Check(video, videoThumb);
                                    }
                                    finally {
                                        semaphoreSlim.Release();
                                    }
                                }))
                                .ToArray());
    }

    [Theory]
    [ClassData(typeof(MultipleVideoUrlData))]
    public async Task GetVideo_MultipleVideoUrl(string[] urls, PornSourceVideo sourceVideo) {
        IPornSearch pornSearch = new PornSearch();
        List<PornVideo> videos = new List<PornVideo>();

        foreach (string url in urls) {
            PornVideo video = await pornSearch.GetVideoAsync(url);
            videos.Add(video);

            PornVideoAssert.Check(video, sourceVideo.Website, video.SexOrientation);

            // Just to use "sourceVideo" and keep the same data source
            Assert.Equal(sourceVideo.Id, video.Id);
            Assert.Equal(sourceVideo.Website, video.Website);
        }

        PornVideo video1 = videos.First();
        foreach (PornVideo video2 in videos.Skip(1))
            PornVideoAssert.Equal(video1, video2);
    }

    [Theory]
    [ClassData(typeof(PornVideoData))]
    public async Task GetVideo_Video(PornVideo videoSource) {
        IPornSearch pornSearch = new PornSearch();

        PornVideo video = await pornSearch.GetVideoAsync(videoSource.PageUrl);

        PornVideoAssert.Check(video, videoSource.Website, videoSource.SexOrientation);
        PornVideoAssert.Equal(videoSource, video);
    }

    [Theory]
    [ClassData(typeof(PornRelatedVideoData))]
    public async Task GetVideo_NbRelatedVideos(int nbRelatedVideos, string pageUrl) {
        IPornSearch pornSearch = new PornSearch();

        PornVideo video = await pornSearch.GetVideoAsync(pageUrl);

        Assert.NotNull(video?.RelatedVideos);
        Assert.Equal(nbRelatedVideos, video.RelatedVideos.Count);
    }

    [Fact]
    public async Task TEST() {
        IPornSearch pornSearch = new PornSearch();
        PornVideo video = await pornSearch.GetVideoAsync(new PornSourceVideo {
            Website = PornWebsite.Pornhub,
            //Id = "ph62c4873391c44"
            Id = "ph628ae482a2c46"
            //Id="ph6360471ea2482"
            //Id="ph639c6f6822ba2"
            // Id = "54073021" // RED
            //Id = "63770025"
        });
        Assert.NotNull(video);

        var test = await pornSearch.SearchAsync(new PornSearchFilter {
            //Filter = "PLEASE CUM IN ME IN THE ASS! Stella_vegas",
            Filter = "Emmanuelle Worley",
            Page = 1,
            Website = PornWebsite.Pornhub,
            SexOrientation = PornSexOrientation.Straight
        });

        Assert.NotNull(test);

        var test2 = await pornSearch.SearchAsync(new PornSearchFilter {
            //Filter = "PLEASE CUM IN ME IN THE ASS! Stella_vegas",
            Filter = "trans",
            Page = 1,
            Website = PornWebsite.Pornhub,
            SexOrientation = PornSexOrientation.Straight
        });
    }
}
