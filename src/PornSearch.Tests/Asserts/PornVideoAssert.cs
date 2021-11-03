using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Web;
using JetBrains.Annotations;
using Xunit;

namespace PornSearch.Tests.Asserts
{
    public static class PornVideoAssert
    {
        public static void Check(PornVideo video, PornWebsite website, PornSexOrientation sexOrientation) {
            Assert.NotNull(video);
            Assert.Equal(website, video.Website);
            Assert.Equal(sexOrientation, video.SexOrientation);
            Assert_Video_Id(video.Id, website);
            Assert_Video_Title(video.Title);
            Assert.NotNull(video.Channel);
            Assert_Video_Channel_Id(video.Channel.Id, website);
            Assert_Video_Channel_Name(video.Channel.Name);
            Assert_Video_ThumbnailUrl(video.ThumbnailUrl, website);
            Assert_Video_SmallThumbnailUrl(video.SmallThumbnailUrl, website);
            Assert_Video_PageUrl(video.PageUrl, website);
            Assert_Video_Categories(video.Categories, website, sexOrientation);
            Assert_Video_Tags(video.Tags, website, sexOrientation);
            Assert_Video_Actors(video.Actors, website);
            Assert_Video_NbViews(video.NbViews);
            Assert_Video_NbLikes(video.NbLikes);
            Assert_Video_NbDislikes(video.NbDislikes);
            Assert_Video_UploadDate(video.UploadDate);
            Assert_Video_RelatedVideos(video.RelatedVideos, website, sexOrientation);
        }

        [AssertionMethod]
        private static void Assert_Video_Id(string id, PornWebsite website) {
            Assert.NotNull(id);
            switch (website) {
                case PornWebsite.Pornhub:
                    Assert.Matches("^(ph[0-9a-f]{13}|[0-9]{7,10})$", id);
                    break;
                case PornWebsite.XVideos:
                    Assert.Matches("^/video[0-9]{5,8}/[^\\s]*$", id);
                    break;
                default: throw new ArgumentOutOfRangeException(nameof(website), website, null);
            }
        }

        private static void Assert_Video_Title(string title) {
            Assert.NotNull(title);
            Assert.NotEqual("", title.Trim());
            Assert.Equal(HttpUtility.HtmlDecode(title), title);
            Assert.DoesNotContain("\u00A0", title);
        }

        [AssertionMethod]
        private static void Assert_Video_Channel_Id(string channelId, PornWebsite website) {
            Assert.NotNull(channelId);
            switch (website) {
                case PornWebsite.Pornhub: {
                    Assert.Matches("^/(channels|model|pornstar|users)/[^/\\s]*$", channelId);
                    break;
                }
                case PornWebsite.XVideos:
                    Assert.Matches("^/(channels|profiles|models|pornstar-channels|amateur-channels|model-channels|amateurs|pornstars)/[^/\\s]*$",
                                   channelId);
                    break;
                default: throw new ArgumentOutOfRangeException(nameof(website), website, null);
            }
        }

        private static void Assert_Video_Channel_Name(string channelName) {
            Assert.NotNull(channelName);
            Assert.NotEqual("", channelName.Trim());
            Assert.Equal(HttpUtility.HtmlDecode(channelName), channelName);
        }

        [AssertionMethod]
        private static void Assert_Video_ThumbnailUrl(string thumbnailUrl, PornWebsite website) {
            Assert.NotNull(thumbnailUrl);
            switch (website) {
                case PornWebsite.Pornhub:
                    Assert.Matches("^https://[bcde]i[.]phncdn[.]com/videos[^\\s]*[.]jpg$", thumbnailUrl);
                    break;
                case PornWebsite.XVideos:
                    Assert.Matches("^https://(cdn77-pic|img-l3|img-hw)[.]xvideos-cdn[.]com/videos(_new)*/thumbs[^\\s.]*?[.][0-9]+[.]jpg$",
                                   thumbnailUrl);
                    break;
                default: throw new ArgumentOutOfRangeException(nameof(website), website, null);
            }
        }

        [AssertionMethod]
        private static void Assert_Video_SmallThumbnailUrl(string smallThumbnailUrl, PornWebsite website) {
            Assert.NotNull(smallThumbnailUrl);
            switch (website) {
                case PornWebsite.Pornhub:
                    Assert.Matches("^https://[bcde]i[.]phncdn[.]com/videos[^\\s]*[.]jpg$", smallThumbnailUrl);
                    break;
                case PornWebsite.XVideos:
                    Assert.Matches("^https://(cdn77-pic|img-l3|img-hw)[.]xvideos-cdn[.]com/videos(_new)*/thumbs[^\\s.]*?[.][0-9]+[.]jpg$",
                                   smallThumbnailUrl);
                    break;
                default: throw new ArgumentOutOfRangeException(nameof(website), website, null);
            }
        }

        [AssertionMethod]
        private static void Assert_Video_PageUrl(string pageUrl, PornWebsite website) {
            Assert.NotNull(pageUrl);
            switch (website) {
                case PornWebsite.Pornhub:
                    Assert.Matches("^https://www[.]pornhub[.]com/view_video[.]php[?]viewkey=(ph[0-9a-f]{13}|[0-9]{7,10})$",
                                   pageUrl);
                    break;
                case PornWebsite.XVideos:
                    Assert.Matches("^https://www[.]xvideos[.]com/video[0-9]{5,8}/[^\\s]*$", pageUrl);
                    break;
                default: throw new ArgumentOutOfRangeException(nameof(website), website, null);
            }
        }

        [AssertionMethod]
        private static void Assert_Video_Categories(List<PornIdName> categories, PornWebsite website,
                                                    PornSexOrientation sexOrientation) {
            switch (website) {
                case PornWebsite.Pornhub:
                    Assert.NotNull(categories);
                    foreach (PornIdName category in categories) {
                        Assert_Video_Category_Id(category.Id, website, sexOrientation);
                        Assert_Video_Category_Name(category.Name);
                    }
                    break;
                case PornWebsite.XVideos:
                    Assert.Null(categories);
                    break;
                default: throw new ArgumentOutOfRangeException(nameof(website), website, null);
            }
        }

        [AssertionMethod]
        private static void Assert_Video_Category_Id(string categoryId, PornWebsite website, PornSexOrientation sexOrientation) {
            Assert.NotNull(categoryId);
            switch (website) {
                case PornWebsite.Pornhub: {
                    switch (sexOrientation) {
                        case PornSexOrientation.Straight:
                            Assert.Matches("^/(video[?]c=[0-9]+|hd|categories/[^\\s]+|popularwithwomen|vr|transgender|interactive)$",
                                           categoryId);
                            break;
                        case PornSexOrientation.Gay:
                            Assert.Matches("^/(gay(/video[?]c=[0-9]+|porn)|popularwithwomen)$", categoryId);
                            break;
                        default: throw new ArgumentOutOfRangeException(nameof(sexOrientation), sexOrientation, null);
                    }
                    break;
                }
                default: throw new ArgumentOutOfRangeException(nameof(website), website, null);
            }
        }

        private static void Assert_Video_Category_Name(string categoryName) {
            Assert.NotNull(categoryName);
            Assert.NotEqual("", categoryName.Trim());
            Assert.Equal(HttpUtility.HtmlDecode(categoryName), categoryName);
        }

        [AssertionMethod]
        private static void Assert_Video_Tags(List<PornIdName> tags, PornWebsite website, PornSexOrientation sexOrientation) {
            Assert.NotNull(tags);
            foreach (PornIdName tag in tags) {
                Assert_Video_Tag_Id(tag.Id, website, sexOrientation);
                Assert_Video_Tag_Name(tag.Name);
            }
        }

        [AssertionMethod]
        private static void Assert_Video_Tag_Id(string tagId, PornWebsite website, PornSexOrientation sexOrientation) {
            Assert.NotNull(tagId);
            switch (website) {
                case PornWebsite.Pornhub: {
                    switch (sexOrientation) {
                        case PornSexOrientation.Straight:
                            Assert.Matches("^/(video(/search[?]search=[^\\s]+|[?]c=[0-9]+)|categories/[^\\s]+|hd|vr|interactive|popularwithwomen)$",
                                           tagId);
                            break;
                        case PornSexOrientation.Gay:
                            Assert.Matches("^/gay(/video(/search[?]search=[^\\s]+|[?]c=[0-9]+)|porn)$", tagId);
                            break;
                        default: throw new ArgumentOutOfRangeException(nameof(sexOrientation), sexOrientation, null);
                    }
                    break;
                }
                default: throw new ArgumentOutOfRangeException(nameof(website), website, null);
            }
        }

        private static void Assert_Video_Tag_Name(string tagName) {
            Assert.NotNull(tagName);
            Assert.NotEqual("", tagName.Trim());
            Assert.Equal(HttpUtility.HtmlDecode(tagName), tagName);
        }

        [AssertionMethod]
        private static void Assert_Video_Actors(List<PornIdName> actors, PornWebsite website) {
            Assert.NotNull(actors);
            foreach (PornIdName actor in actors) {
                Assert_Video_Actor_Id(actor.Id, website);
                Assert_Video_Actor_Name(actor.Name);
            }
        }

        [AssertionMethod]
        private static void Assert_Video_Actor_Id(string actorId, PornWebsite website) {
            Assert.NotNull(actorId);
            switch (website) {
                case PornWebsite.Pornhub: {
                    Assert.Matches("^/pornstar/[^\\s]+$", actorId);
                    break;
                }
                default: throw new ArgumentOutOfRangeException(nameof(website), website, null);
            }
        }

        private static void Assert_Video_Actor_Name(string actorName) {
            Assert.NotNull(actorName);
            Assert.NotEqual("", actorName.Trim());
            Assert.Equal(HttpUtility.HtmlDecode(actorName), actorName);
        }

        private static void Assert_Video_NbViews(int nbViews) {
            Assert.True(nbViews > 0);
        }

        private static void Assert_Video_NbLikes(int nbLikes) {
            Assert.True(nbLikes >= 0);
        }

        private static void Assert_Video_NbDislikes(int nbDislikes) {
            Assert.True(nbDislikes >= 0);
        }

        private static void Assert_Video_UploadDate(DateTime uploadDate) {
            Assert.True(uploadDate < DateTime.Now);
            Assert.True(uploadDate > new DateTime(2000, 1, 1));
        }

        private static void Assert_Video_RelatedVideos(List<PornVideoThumb> relatedVideos, PornWebsite website,
                                                       PornSexOrientation sexOrientation) {
            Assert.NotNull(relatedVideos);
            switch (website) {
                case PornWebsite.Pornhub:
                    Assert.True(relatedVideos.Count >= 33);
                    Assert.True(relatedVideos.Count <= 45);
                    break;
                default: throw new ArgumentOutOfRangeException(nameof(website), website, null);
            }
            PornVideoThumbAssert.CheckAll(relatedVideos, website, "filter not empty", sexOrientation);
        }

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
