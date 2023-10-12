using System;
using System.Threading.Tasks;
using PornSearch.Tests.Data;
using Xunit;

namespace PornSearch.Tests;

public class PornSearch_CheckIfCanVideoEmbedInIframe_Tests
{
    [Fact]
    public async Task CheckIfCanVideoEmbedInIframe_ArgumentNullException() {
        IPornSearch pornSearch = new PornSearchEngine();

        await Assert.ThrowsAsync<ArgumentNullException>(async () => await pornSearch.CheckIfCanVideoEmbedInIframeAsync(null));
    }

    [Fact]
    public async Task CheckIfCanVideoEmbedInIframe_YouPorn_Title_Null() {
        IPornSearch pornSearch = new PornSearchEngine();
        PornVideo video = new PornVideo {
            Website = PornWebsite.YouPorn,
            Title = null
        };

        bool actual = await pornSearch.CheckIfCanVideoEmbedInIframeAsync(video);

        Assert.True(actual);
    }

    [Theory]
    [ClassData(typeof(CheckIfCanVideoEmbedInIframeData))]
    public async Task CheckIfCanVideoEmbedInIframe(string url, bool expected) {
        IPornSearch pornSearch = new PornSearchEngine();
        PornVideo video = await pornSearch.GetVideoAsync(url);

        bool actual = await pornSearch.CheckIfCanVideoEmbedInIframeAsync(video);

        Assert.Equal(expected, actual);
    }
}
