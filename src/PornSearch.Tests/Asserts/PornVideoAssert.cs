using System.Text.RegularExpressions;
using Xunit;

namespace PornSearch.Tests.Asserts
{
    public static class PornVideoAssert
    {
        public static void Check(PornVideo video1, PornVideoThumb videoThumb) {
            Assert.NotNull(video1);
            Assert.NotNull(videoThumb);
            Assert.Equal(video1.Website, videoThumb.Website);
            Assert.Equal(video1.SexOrientation, videoThumb.SexOrientation);
            Assert.Equal(video1.Id, videoThumb.Id);
            Assert.Equal(video1.Title, videoThumb.Title);
            Assert.Equal(video1.Channel.Id, videoThumb.Channel.Id);
            Assert.Equal(video1.Channel.Name, videoThumb.Channel.Name);
            switch (video1.Website) {
                case PornWebsite.Pornhub: {
                    // The 9th character can change value
                    const string pattern = "^https://.(.*)$";
                    Assert.Equal(Regex.Replace(video1.SmallThumbnailUrl, pattern, "$1"),
                                 Regex.Replace(videoThumb.ThumbnailUrl, pattern, "$1"));
                    break;
                }
                case PornWebsite.XVideos: {
                    // The first subdomain and end of url can change value
                    const string pattern = "^https://[^.]*[.](.*?)[.][0-9]+[.]jpg$";
                    Assert.Equal(Regex.Replace(video1.SmallThumbnailUrl, pattern, "$1"),
                                 Regex.Replace(videoThumb.ThumbnailUrl, pattern, "$1"));
                    break;
                }
                default:
                    Assert.Equal(video1.SmallThumbnailUrl, videoThumb.ThumbnailUrl);
                    break;
            }
            Assert.Equal(video1.PageUrl, videoThumb.PageUrl);
        }

        public static void Equal(PornVideo video1, PornVideo video2) {
            Assert.NotNull(video1);
            Assert.NotNull(video2);
            Assert.Equal(video1.Website, video2.Website);
            Assert.Equal(video1.SexOrientation, video2.SexOrientation);
            Assert.Equal(video1.Id, video2.Id);
            Assert.Equal(video1.Title, video2.Title);
            Assert.Equal(video1.Channel.Id, video2.Channel.Id);
            Assert.Equal(video1.Channel.Name, video2.Channel.Name);
            switch (video1.Website) {
                case PornWebsite.Pornhub: {
                    // The 9th character can change value
                    const string pattern = "^https://.(.*)$";
                    Assert.Equal(Regex.Replace(video1.ThumbnailUrl, pattern, "$1"),
                                 Regex.Replace(video2.ThumbnailUrl, pattern, "$1"));
                    Assert.Equal(Regex.Replace(video1.SmallThumbnailUrl, pattern, "$1"),
                                 Regex.Replace(video2.SmallThumbnailUrl, pattern, "$1"));
                    break;
                }
                case PornWebsite.XVideos: {
                    // The first subdomain and end of url can change value
                    const string pattern = "^https://[^.]*[.](.*?)[.][0-9]+[.]jpg$";
                    Assert.Equal(Regex.Replace(video1.ThumbnailUrl, pattern, "$1"),
                                 Regex.Replace(video2.ThumbnailUrl, pattern, "$1"));
                    Assert.Equal(Regex.Replace(video1.SmallThumbnailUrl, pattern, "$1"),
                                 Regex.Replace(video2.SmallThumbnailUrl, pattern, "$1"));
                    break;
                }
                default:
                    Assert.Equal(video1.SmallThumbnailUrl, video2.SmallThumbnailUrl);
                    break;
            }
            Assert.Equal(video1.PageUrl, video2.PageUrl);
            if (video1.Categories == null) {
                Assert.Null(video2.Categories);
            }
            else {
                Assert.Equal(video1.Categories.Count, video2.Categories.Count);
                for (int i = 0; i < video1.Categories.Count; i++) {
                    Assert.Equal(video1.Categories[i].Id, video2.Categories[i].Id);
                    Assert.Equal(video1.Categories[i].Name, video2.Categories[i].Name);
                }
            }
            if (video1.Tags == null) {
                Assert.Null(video2.Tags);
            }
            else {
                Assert.Equal(video1.Tags.Count, video2.Tags.Count);
                for (int i = 0; i < video1.Tags.Count; i++) {
                    Assert.Equal(video1.Tags[i].Id, video2.Tags[i].Id);

                    if (video1.Website == PornWebsite.Pornhub && video1.SexOrientation == PornSexOrientation.Gay) {
                        const string pattern = "^(Gay )*(.*)$";
                        Assert.Equal(Regex.Replace(video1.Tags[i].Name, pattern, "$2"),
                                     Regex.Replace(video2.Tags[i].Name, pattern, "$2"));
                    }
                    else {
                        Assert.Equal(video1.Tags[i].Name, video2.Tags[i].Name);
                    }
                }
            }
            if (video1.Actors == null) {
                Assert.Null(video2.Actors);
            }
            else {
                Assert.Equal(video1.Actors.Count, video2.Actors.Count);
                for (int i = 0; i < video1.Actors.Count; i++) {
                    Assert.Equal(video1.Actors[i].Id, video2.Actors[i].Id);
                    Assert.Equal(video1.Actors[i].Name, video2.Actors[i].Name);
                }
            }
            Assert.True(video1.NbViews <= video2.NbViews);
            Assert.True(video1.NbLikes <= video2.NbLikes);
            Assert.True(video1.NbDislikes <= video2.NbDislikes);
            Assert.Equal(video1.UploadDate, video2.UploadDate);
            if (video1.RelatedVideos != null) {
                Assert.Equal(video1.RelatedVideos.Count, video2.RelatedVideos.Count);
                for (int i = 0; i < video1.RelatedVideos.Count; i++)
                    PornVideoThumbAssert.Equal(video1.RelatedVideos[i], video2.RelatedVideos[i]);
            }
        }
    }
}
