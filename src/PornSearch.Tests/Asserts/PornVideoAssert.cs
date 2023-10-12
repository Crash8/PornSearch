using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using JetBrains.Annotations;
using Xunit;

namespace PornSearch.Tests.Asserts;

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
        Assert_Video_Channel_Name(video.Channel.Name, website);
        Assert_Video_ThumbnailUrl(video.ThumbnailUrl, website);
        Assert_Video_SmallThumbnailUrl(video.SmallThumbnailUrl, website);
        Assert_Video_PageUrl(video.PageUrl, website);
        Assert_Video_VideoEmbedUrl(video.VideoEmbedUrl, website);
        Assert_Video_Duration(video.Duration);
        Assert_Video_Categories(video.Categories, website, sexOrientation);
        Assert_Video_Tags(video.Tags, website, sexOrientation);
        Assert_Video_Actors(video.Actors, website);
        Assert_Video_NbViews(video.NbViews, website);
        Assert_Video_NbLikes(video.NbLikes, website);
        Assert_Video_NbDislikes(video.NbDislikes, website);
        Assert_Video_Date(video.Date);
        Assert_Video_RelatedVideos(video.RelatedVideos, website, sexOrientation);
        Assert_Video_Link_Id_PageUrl(video.Id, video.PageUrl, website);
        Assert_Video_Link_Id_VideoEmbedUrl(video.Id, video.VideoEmbedUrl, website);
        Assert_Video_Link_NbViews_NbLikes_NbDislikes(video.NbViews, video.NbLikes, video.NbDislikes);
        Assert_Video_Not_Same_Value(video);
    }

    [AssertionMethod]
    private static void Assert_Video_Id(string id, PornWebsite website) {
        Assert.NotNull(id);
        switch (website) {
            case PornWebsite.Pornhub:
                Assert.Matches("^(ph[0-9a-f]{13}|[0-9]{5,10}|[a-f0-9]{20}|[0-9a-f]{13})$", id);
                break;
            case PornWebsite.XVideos:
                Assert.Matches("^[0-9]{4,8}$", id);
                break;
            case PornWebsite.YouPorn:
                Assert.Matches("^[0-9]{7,9}$", id);
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
            case PornWebsite.XVideos: {
                if (channelId != "")
                    Assert.Matches("^/[^/\\s]*$", channelId);
                break;
            }
            case PornWebsite.YouPorn:
                Assert.Matches("^((/gay)?/channel/[^/\\s]*|/uservids/[^/\\s]*)/$", channelId);
                break;
            default: throw new ArgumentOutOfRangeException(nameof(website), website, null);
        }
    }

    private static void Assert_Video_Channel_Name(string channelName, PornWebsite website) {
        Assert.NotNull(channelName);
        switch (website) {
            case PornWebsite.Pornhub:
                Assert.NotEqual("", channelName.Trim());
                Assert.Equal(HttpUtility.HtmlDecode(channelName), channelName);
                break;
            case PornWebsite.XVideos:
                if (channelName != "") {
                    Assert.NotEqual("", channelName.Trim());
                    Assert.Equal(HttpUtility.HtmlDecode(channelName), channelName);
                }
                break;
            case PornWebsite.YouPorn:
                Assert.NotEqual("", channelName.Trim());
                Assert.Equal(HttpUtility.HtmlDecode(channelName), channelName);
                break;
            default: throw new ArgumentOutOfRangeException(nameof(website), website, null);
        }
    }

    [AssertionMethod]
    private static void Assert_Video_ThumbnailUrl(string thumbnailUrl, PornWebsite website) {
        Assert.NotNull(thumbnailUrl);
        switch (website) {
            case PornWebsite.Pornhub:
                Assert.Matches("^https://[bcde]i[.]phncdn[.]com/videos[^\\s]*[.]jpg$", thumbnailUrl);
                break;
            case PornWebsite.XVideos:
                Assert.Matches("^http(s)?://(cdn77-pic|img-l3|img-hw|img-cf|img-egc)[.]xvideos-cdn[.]com/videos(_new)*/thumbs[^\\s.]*?[.][0-9]+[.]jpg$",
                               thumbnailUrl);
                break;
            case PornWebsite.YouPorn:
                Assert.Matches("^https://(fi1|fi1-ph|di1|di1-ph)[.]ypncdn[.]com/(videos/|m=eaSaaTbWx/)?[0-9]{6}/[0-9]{2}/[0-9]{6,9}/[^\\s.]*[.]jpg$",
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
                Assert.Matches("^http(s)?://(cdn77-pic|img-l3|img-hw|img-cf|img-egc)[.]xvideos-cdn[.]com/videos(_new)*/thumbs[^\\s.]*?[.][0-9]+[.]jpg$",
                               smallThumbnailUrl);
                break;
            case PornWebsite.YouPorn:
                Assert.Matches("^https://(fi1|fi1-ph|di1|di1-ph)[.]ypncdn[.]com/(videos/|m=(.*)/)?[0-9]{6}/[0-9]{2}/[0-9]{7,9}/[^\\s.]*[.]jpg$",
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
                Assert.Matches("^https://www[.]pornhub[.]com/view_video[.]php[?]viewkey=(ph[0-9a-f]{13}|[0-9]{5,10}|[a-f0-9]{20}|[0-9a-f]{13})$",
                               pageUrl);
                break;
            case PornWebsite.XVideos:
                Assert.Matches("^https://www[.]xvideos[.]com/video[0-9]{4,8}/[^\\s]+$", pageUrl);
                break;
            case PornWebsite.YouPorn:
                Assert.Matches("^https://www[.]youporn[.]com/watch/[0-9]{7,9}/($|[^\\s]*$)", pageUrl);
                break;
            default: throw new ArgumentOutOfRangeException(nameof(website), website, null);
        }
    }

    [AssertionMethod]
    private static void Assert_Video_VideoEmbedUrl(string videoEmbedUrl, PornWebsite website) {
        Assert.NotNull(videoEmbedUrl);
        switch (website) {
            case PornWebsite.Pornhub:
                Assert.Matches("^https://www[.]pornhub[.]com/embed/(ph[0-9a-f]{13}|[0-9]{5,10}|[a-f0-9]{20}|[0-9a-f]{13})$", videoEmbedUrl);
                break;
            case PornWebsite.XVideos:
                Assert.Matches("^https://www[.]xvideos[.]com/embedframe/[0-9]{4,8}$", videoEmbedUrl);
                break;
            case PornWebsite.YouPorn:
                Assert.Matches("^https://www[.]youporn[.]com/embed/[0-9]{7,9}/($|[^\\s]+$)", videoEmbedUrl);
                break;
            default: throw new ArgumentOutOfRangeException(nameof(website), website, null);
        }
    }

    private static void Assert_Video_Duration(TimeSpan duration) {
        Assert.True(duration.TotalSeconds > 0);
    }

    [AssertionMethod]
    private static void Assert_Video_Categories(List<PornIdName> categories, PornWebsite website, PornSexOrientation sexOrientation) {
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
            case PornWebsite.YouPorn:
                Assert.NotNull(categories);
                foreach (PornIdName category in categories) {
                    Assert_Video_Category_Id(category.Id, website, sexOrientation);
                    Assert_Video_Category_Name(category.Name);
                }
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
                        Assert.Matches("^/(gay(/video[?]c=[0-9]+|porn)|popularwithwomen|vr|transgender|categories/[^\\s]+)$", categoryId);
                        break;
                    default: throw new ArgumentOutOfRangeException(nameof(sexOrientation), sexOrientation, null);
                }
                break;
            }
            case PornWebsite.YouPorn: {
                Assert.Matches("^(/gay)?/category/[^\\s/]+/$", categoryId);
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
                        Assert.Matches("^/(video(/search[?]search=[^\\s]+|[?]c=[0-9]+)|categories/[^\\s]+|hd|vr|interactive|popularwithwomen|transgender|gayporn|sfw)$",
                                       tagId);
                        break;
                    case PornSexOrientation.Gay:
                        Assert.Matches("^(/gay(/video(/search[?]search=[^\\s]+|[?]c=[0-9]+)|porn)|/video/gayporn|/popularwithwomen|/video/search[?]search=[^\\s]+|[?]c=[0-9]+)$",
                                       tagId);
                        break;
                    default: throw new ArgumentOutOfRangeException(nameof(sexOrientation), sexOrientation, null);
                }
                break;
            }
            case PornWebsite.XVideos: {
                Assert.Matches("^(/tags/[^\\s]+|/verified/videos)$", tagId);
                break;
            }
            case PornWebsite.YouPorn: {
                Assert.Matches("^(/gay)?/porntags/[^\\s/]+/$", tagId);
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
            case PornWebsite.Pornhub:
                Assert.Matches("^(/pornstar/[^\\s]+|/model)$", actorId);
                break;
            case PornWebsite.XVideos:
                Assert.Matches("^(/[?]k=[^\\s]+|/(pornstar-channels|pornstars|models|amateur-channels|model-channels|amateurs)/[^\\s]+)$",
                               actorId);
                break;
            case PornWebsite.YouPorn:
                Assert.Matches("^(/gay)?/pornstar/[^\\s/]+/$", actorId);
                break;
            default: throw new ArgumentOutOfRangeException(nameof(website), website, null);
        }
    }

    private static void Assert_Video_Actor_Name(string actorName) {
        Assert.NotNull(actorName);
        Assert.NotEqual("", actorName.Trim());
        Assert.Equal(HttpUtility.HtmlDecode(actorName), actorName);
    }

    private static void Assert_Video_NbViews(int? nbViews, PornWebsite website) {
        switch (website) {
            case PornWebsite.Pornhub:
                Assert.True(nbViews > 0);
                break;
            case PornWebsite.XVideos:
                Assert.True(nbViews >= 0);
                break;
            case PornWebsite.YouPorn:
                Assert.True(nbViews > 0);
                break;
            default: throw new ArgumentOutOfRangeException(nameof(website), website, null);
        }
    }

    private static void Assert_Video_NbLikes(int? nbLikes, PornWebsite website) {
        switch (website) {
            case PornWebsite.Pornhub:
                Assert.NotNull(nbLikes);
                Assert.True(nbLikes >= 0);
                break;
            case PornWebsite.XVideos:
                Assert.NotNull(nbLikes);
                Assert.True(nbLikes >= 0);
                break;
            case PornWebsite.YouPorn:
                Assert.Null(nbLikes);
                break;
            default: throw new ArgumentOutOfRangeException(nameof(website), website, null);
        }
    }

    private static void Assert_Video_NbDislikes(int? nbDislikes, PornWebsite website) {
        switch (website) {
            case PornWebsite.Pornhub:
                Assert.NotNull(nbDislikes);
                Assert.True(nbDislikes >= 0);
                break;
            case PornWebsite.XVideos:
                Assert.NotNull(nbDislikes);
                Assert.True(nbDislikes >= 0);
                break;
            case PornWebsite.YouPorn:
                Assert.Null(nbDislikes);
                break;
            default: throw new ArgumentOutOfRangeException(nameof(website), website, null);
        }
    }

    private static void Assert_Video_Date(DateTime date) {
        Assert.True(date < DateTime.Now, date.ToString(CultureInfo.CurrentCulture));
        Assert.True(date > new DateTime(2000, 1, 1));
    }

    private static void Assert_Video_RelatedVideos(List<PornVideoThumb> relatedVideos, PornWebsite website,
                                                   PornSexOrientation sexOrientation) {
        Assert.NotNull(relatedVideos);
        switch (website) {
            case PornWebsite.Pornhub:
                Assert.True(relatedVideos.Count >= 33, relatedVideos.Count.ToString());
                Assert.True(relatedVideos.Count <= 46, relatedVideos.Count.ToString());
                break;
            case PornWebsite.XVideos:
                switch (sexOrientation) {
                    case PornSexOrientation.Straight:
                        Assert.True(relatedVideos.Count <= 40, relatedVideos.Count.ToString());
                        break;
                    case PornSexOrientation.Gay:
                        Assert.True(relatedVideos.Count >= 1, relatedVideos.Count.ToString());
                        Assert.True(relatedVideos.Count <= 40, relatedVideos.Count.ToString());
                        break;
                    case PornSexOrientation.Trans:
                        Assert.True(relatedVideos.Count >= 11, relatedVideos.Count.ToString());
                        Assert.True(relatedVideos.Count <= 40, relatedVideos.Count.ToString());
                        break;
                    default: throw new ArgumentOutOfRangeException(nameof(sexOrientation), sexOrientation, null);
                }
                break;
            case PornWebsite.YouPorn:
                Assert.True(relatedVideos.Count == 24, relatedVideos.Count.ToString());
                break;
            default: throw new ArgumentOutOfRangeException(nameof(website), website, null);
        }
        PornVideoThumbAssert.CheckAll(relatedVideos, website, "filter not empty", sexOrientation);
    }

    [AssertionMethod]
    private static void Assert_Video_Link_Id_PageUrl(string id, string pageUrl, PornWebsite website) {
        switch (website) {
            case PornWebsite.Pornhub:
                Assert.Equal($"https://www.pornhub.com/view_video.php?viewkey={id}", pageUrl);
                break;
            case PornWebsite.XVideos:
                Assert.StartsWith($"https://www.xvideos.com/video{id}/", pageUrl);
                break;
            case PornWebsite.YouPorn:
                Assert.StartsWith($"https://www.youporn.com/watch/{id}/", pageUrl);
                break;
            default: throw new ArgumentOutOfRangeException(nameof(website), website, null);
        }
    }

    [AssertionMethod]
    private static void Assert_Video_Link_Id_VideoEmbedUrl(string id, string videoEmbedUrl, PornWebsite website) {
        switch (website) {
            case PornWebsite.Pornhub:
                Assert.Equal($"https://www.pornhub.com/embed/{id}", videoEmbedUrl);
                break;
            case PornWebsite.XVideos:
                Assert.Equal($"https://www.xvideos.com/embedframe/{id}", videoEmbedUrl);
                break;
            case PornWebsite.YouPorn:
                Assert.StartsWith($"https://www.youporn.com/embed/{id}/", videoEmbedUrl);
                break;
            default: throw new ArgumentOutOfRangeException(nameof(website), website, null);
        }
    }

    private static void Assert_Video_Link_NbViews_NbLikes_NbDislikes(int nbViews, int? nbLikes, int? nbDislikes) {
        if (nbViews > 0 && nbLikes != null && nbDislikes != null) {
            Assert.True(nbViews >= nbLikes);
            Assert.True(nbViews >= nbDislikes);
            Assert.True(nbViews >= nbLikes + nbDislikes);
        }
    }

    [AssertionMethod]
    private static void Assert_Video_Not_Same_Value(PornVideo video) {
        Assert.True(video.Id != video.Title);
        Assert.True(video.Id != video.Channel.Id);
        Assert.True(video.Id != video.Channel.Name);
        Assert.True(video.Id != video.ThumbnailUrl);
        Assert.True(video.Id != video.SmallThumbnailUrl);
        Assert.True(video.Id != video.PageUrl);
        Assert.True(video.Id != video.VideoEmbedUrl);
        if (video.Categories != null) {
            Assert.True(video.Categories.All(c => video.Id != c.Id));
            Assert.True(video.Categories.All(c => video.Id != c.Name));
        }
        Assert.True(video.Tags.All(t => video.Id != t.Id));
        Assert.True(video.Tags.All(t => video.Id != t.Name));
        Assert.True(video.Actors.All(a => video.Id != a.Id));
        Assert.True(video.Actors.All(a => video.Id != a.Name));
        Assert.True(video.RelatedVideos.All(r => video.Id != r.Id));
        Assert.True(video.RelatedVideos.All(r => video.Id != r.Title));
        Assert.True(video.RelatedVideos.All(r => video.Id != r.PageUrl));
        Assert.True(video.RelatedVideos.All(r => video.Id != r.ThumbnailUrl));
        Assert.True(video.RelatedVideos.All(r => video.Id != r.Channel.Id));
        Assert.True(video.RelatedVideos.All(r => video.Id != r.Channel.Name));

        Assert.True(video.Title != video.Channel.Id);
        Assert.True(video.Title != video.ThumbnailUrl);
        Assert.True(video.Title != video.SmallThumbnailUrl);
        Assert.True(video.Title != video.PageUrl);
        Assert.True(video.Title != video.VideoEmbedUrl);
        if (video.Categories != null) {
            Assert.True(video.Categories.All(c => video.Title != c.Id));
            Assert.True(video.Categories.All(c => video.Title != c.Name));
        }
        Assert.True(video.Tags.All(t => video.Title != t.Id));
        Assert.True(video.Actors.All(a => video.Title != a.Id));
        Assert.True(video.RelatedVideos.All(r => video.Title != r.Id));
        Assert.True(video.RelatedVideos.All(r => video.Title != r.PageUrl));
        Assert.True(video.RelatedVideos.All(r => video.Title != r.ThumbnailUrl));
        Assert.True(video.RelatedVideos.All(r => video.Title != r.Channel.Id));

        if (video.Channel.Id != "")
            Assert.True(video.Channel.Id != video.Channel.Name);
        Assert.True(video.Channel.Id != video.ThumbnailUrl);
        Assert.True(video.Channel.Id != video.SmallThumbnailUrl);
        Assert.True(video.Channel.Id != video.PageUrl);
        Assert.True(video.Channel.Id != video.VideoEmbedUrl);
        if (video.Categories != null) {
            Assert.True(video.Categories.All(c => video.Channel.Id != c.Id));
            Assert.True(video.Categories.All(c => video.Channel.Id != c.Name));
        }
        Assert.True(video.Tags.All(t => video.Channel.Id != t.Id));
        Assert.True(video.Tags.All(t => video.Channel.Id != t.Name));
        Assert.True(video.Actors.All(a => video.Channel.Id != a.Name));
        Assert.True(video.RelatedVideos.All(r => video.Channel.Id != r.Id));
        if (video.Channel.Id != "")
            Assert.True(video.RelatedVideos.All(r => video.Channel.Id != r.Title));
        Assert.True(video.RelatedVideos.All(r => video.Channel.Id != r.PageUrl));
        Assert.True(video.RelatedVideos.All(r => video.Channel.Id != r.ThumbnailUrl));
        Assert.True(video.RelatedVideos.Where(r => r.Channel.Name != "").All(r => video.Channel.Id != r.Channel.Name));

        Assert.True(video.Channel.Name != video.ThumbnailUrl);
        Assert.True(video.Channel.Name != video.SmallThumbnailUrl);
        Assert.True(video.Channel.Name != video.PageUrl);
        Assert.True(video.Channel.Name != video.VideoEmbedUrl);
        if (video.Categories != null) {
            Assert.True(video.Categories.All(c => video.Channel.Name != c.Id));
            Assert.True(video.Categories.All(c => video.Channel.Name != c.Name));
        }
        Assert.True(video.Tags.All(t => video.Channel.Name != t.Id));
        Assert.True(video.Actors.All(a => video.Channel.Name != a.Id));
        Assert.True(video.RelatedVideos.All(r => video.Channel.Name != r.Id));
        Assert.True(video.RelatedVideos.All(r => video.Channel.Name != r.PageUrl));
        Assert.True(video.RelatedVideos.All(r => video.Channel.Name != r.ThumbnailUrl));
        Assert.True(video.RelatedVideos.Where(r => r.Channel.Id != "").All(r => video.Channel.Name != r.Channel.Id));

        Assert.True(video.ThumbnailUrl != video.SmallThumbnailUrl);
        Assert.True(video.ThumbnailUrl != video.PageUrl);
        Assert.True(video.ThumbnailUrl != video.VideoEmbedUrl);
        if (video.Categories != null) {
            Assert.True(video.Categories.All(c => video.ThumbnailUrl != c.Id));
            Assert.True(video.Categories.All(c => video.ThumbnailUrl != c.Name));
        }
        Assert.True(video.Tags.All(t => video.ThumbnailUrl != t.Id));
        Assert.True(video.Tags.All(t => video.ThumbnailUrl != t.Name));
        Assert.True(video.Actors.All(a => video.ThumbnailUrl != a.Id));
        Assert.True(video.Actors.All(a => video.ThumbnailUrl != a.Name));
        Assert.True(video.RelatedVideos.All(r => video.ThumbnailUrl != r.Id));
        Assert.True(video.RelatedVideos.All(r => video.ThumbnailUrl != r.Title));
        Assert.True(video.RelatedVideos.All(r => video.ThumbnailUrl != r.PageUrl));
        Assert.True(video.RelatedVideos.All(r => video.ThumbnailUrl != r.ThumbnailUrl));
        Assert.True(video.RelatedVideos.All(r => video.ThumbnailUrl != r.Channel.Id));
        Assert.True(video.RelatedVideos.All(r => video.ThumbnailUrl != r.Channel.Name));

        Assert.True(video.SmallThumbnailUrl != video.PageUrl);
        Assert.True(video.SmallThumbnailUrl != video.VideoEmbedUrl);
        if (video.Categories != null) {
            Assert.True(video.Categories.All(c => video.SmallThumbnailUrl != c.Id));
            Assert.True(video.Categories.All(c => video.SmallThumbnailUrl != c.Name));
        }
        Assert.True(video.Tags.All(t => video.SmallThumbnailUrl != t.Id));
        Assert.True(video.Tags.All(t => video.SmallThumbnailUrl != t.Name));
        Assert.True(video.Actors.All(a => video.SmallThumbnailUrl != a.Id));
        Assert.True(video.Actors.All(a => video.SmallThumbnailUrl != a.Name));
        Assert.True(video.RelatedVideos.All(r => video.SmallThumbnailUrl != r.Id));
        Assert.True(video.RelatedVideos.All(r => video.SmallThumbnailUrl != r.Title));
        Assert.True(video.RelatedVideos.All(r => video.SmallThumbnailUrl != r.PageUrl));
        Assert.True(video.RelatedVideos.All(r => video.SmallThumbnailUrl != r.ThumbnailUrl));
        Assert.True(video.RelatedVideos.All(r => video.SmallThumbnailUrl != r.Channel.Id));
        Assert.True(video.RelatedVideos.All(r => video.SmallThumbnailUrl != r.Channel.Name));

        Assert.True(video.PageUrl != video.VideoEmbedUrl);
        if (video.Categories != null) {
            Assert.True(video.Categories.All(c => video.PageUrl != c.Id));
            Assert.True(video.Categories.All(c => video.PageUrl != c.Name));
        }
        Assert.True(video.Tags.All(t => video.PageUrl != t.Id));
        Assert.True(video.Tags.All(t => video.PageUrl != t.Name));
        Assert.True(video.Actors.All(a => video.PageUrl != a.Id));
        Assert.True(video.Actors.All(a => video.PageUrl != a.Name));
        Assert.True(video.RelatedVideos.All(r => video.PageUrl != r.Id));
        Assert.True(video.RelatedVideos.All(r => video.PageUrl != r.Title));
        Assert.True(video.RelatedVideos.All(r => video.PageUrl != r.PageUrl));
        Assert.True(video.RelatedVideos.All(r => video.PageUrl != r.ThumbnailUrl));
        Assert.True(video.RelatedVideos.All(r => video.PageUrl != r.Channel.Id));
        Assert.True(video.RelatedVideos.All(r => video.PageUrl != r.Channel.Name));

        if (video.Categories != null) {
            Assert.True(video.Categories.All(c => video.VideoEmbedUrl != c.Id));
            Assert.True(video.Categories.All(c => video.VideoEmbedUrl != c.Name));
        }
        Assert.True(video.Tags.All(t => video.VideoEmbedUrl != t.Id));
        Assert.True(video.Tags.All(t => video.VideoEmbedUrl != t.Name));
        Assert.True(video.Actors.All(a => video.VideoEmbedUrl != a.Id));
        Assert.True(video.Actors.All(a => video.VideoEmbedUrl != a.Name));
        Assert.True(video.RelatedVideos.All(r => video.VideoEmbedUrl != r.Id));
        Assert.True(video.RelatedVideos.All(r => video.VideoEmbedUrl != r.Title));
        Assert.True(video.RelatedVideos.All(r => video.VideoEmbedUrl != r.PageUrl));
        Assert.True(video.RelatedVideos.All(r => video.VideoEmbedUrl != r.ThumbnailUrl));
        Assert.True(video.RelatedVideos.All(r => video.VideoEmbedUrl != r.Channel.Id));
        Assert.True(video.RelatedVideos.All(r => video.VideoEmbedUrl != r.Channel.Name));

        if (video.Categories != null)
            foreach (PornIdName category in video.Categories) {
                Assert.True(video.Categories.All(c => category.Id != c.Name));
                Assert.True(video.Tags.All(t => category.Id != t.Name));
                Assert.True(video.Actors.All(a => category.Id != a.Id));
                Assert.True(video.Actors.All(a => category.Id != a.Name));
                Assert.True(video.RelatedVideos.All(r => category.Id != r.Id));
                Assert.True(video.RelatedVideos.All(r => category.Id != r.Title));
                Assert.True(video.RelatedVideos.All(r => category.Id != r.PageUrl));
                Assert.True(video.RelatedVideos.All(r => category.Id != r.ThumbnailUrl));
                Assert.True(video.RelatedVideos.All(r => category.Id != r.Channel.Id));
                Assert.True(video.RelatedVideos.All(r => category.Id != r.Channel.Name));

                Assert.True(video.Tags.All(t => category.Name != t.Id));
                Assert.True(video.Actors.All(a => category.Name != a.Id));
                Assert.True(video.Actors.All(a => category.Name != a.Name));
                Assert.True(video.RelatedVideos.All(r => category.Name != r.Id));
                Assert.True(video.RelatedVideos.All(r => category.Name != r.PageUrl));
                Assert.True(video.RelatedVideos.All(r => category.Name != r.ThumbnailUrl));
                Assert.True(video.RelatedVideos.All(r => category.Name != r.Channel.Id));
            }

        foreach (PornIdName tag in video.Tags) {
            Assert.True(video.Tags.All(t => tag.Id != t.Name));
            Assert.True(video.Actors.All(a => tag.Id != a.Id));
            Assert.True(video.Actors.All(a => tag.Id != a.Name));
            Assert.True(video.RelatedVideos.All(r => tag.Id != r.Id));
            Assert.True(video.RelatedVideos.All(r => tag.Id != r.Title));
            Assert.True(video.RelatedVideos.All(r => tag.Id != r.PageUrl));
            Assert.True(video.RelatedVideos.All(r => tag.Id != r.ThumbnailUrl));
            Assert.True(video.RelatedVideos.All(r => tag.Id != r.Channel.Id));
            Assert.True(video.RelatedVideos.All(r => tag.Id != r.Channel.Name));

            Assert.True(video.Actors.All(a => tag.Name != a.Id));
            Assert.True(video.RelatedVideos.All(r => tag.Name != r.Id));
            Assert.True(video.RelatedVideos.All(r => tag.Name != r.PageUrl));
            Assert.True(video.RelatedVideos.All(r => tag.Name != r.ThumbnailUrl));
            Assert.True(video.RelatedVideos.All(r => tag.Name != r.Channel.Id));
        }

        foreach (PornIdName actor in video.Actors) {
            Assert.True(video.Actors.All(a => actor.Id != a.Name));
            Assert.True(video.RelatedVideos.All(r => actor.Id != r.Id));
            Assert.True(video.RelatedVideos.All(r => actor.Id != r.Title));
            Assert.True(video.RelatedVideos.All(r => actor.Id != r.PageUrl));
            Assert.True(video.RelatedVideos.All(r => actor.Id != r.ThumbnailUrl));
            Assert.True(video.RelatedVideos.All(r => actor.Id != r.Channel.Name));

            Assert.True(video.RelatedVideos.All(r => actor.Name != r.Id));
            Assert.True(video.RelatedVideos.All(r => actor.Name != r.PageUrl));
            Assert.True(video.RelatedVideos.All(r => actor.Name != r.ThumbnailUrl));
            Assert.True(video.RelatedVideos.All(r => actor.Name != r.Channel.Id));
        }
    }

    public static void Check(PornVideo video1, PornVideoThumb videoThumb) {
        Assert.NotNull(video1);
        Assert.NotNull(videoThumb);
        Assert.Equal(video1.Website, videoThumb.Website);
        Assert.Equal(video1.SexOrientation, videoThumb.SexOrientation);
        Assert.Equal(video1.Id, videoThumb.Id);
        Assert.Equal(CleanTitle(video1.Title, video1.Website), CleanTitle(videoThumb.Title, videoThumb.Website));
        Assert.Equal(CleanChannelId(video1.Channel.Id, video1.Website), CleanChannelId(videoThumb.Channel.Id, videoThumb.Website));
        Assert.Equal(CleanChannelName(video1.Channel, video1.Website), CleanChannelName(videoThumb.Channel, videoThumb.Website));
        switch (video1.Website) {
            case PornWebsite.Pornhub: {
                // The 9th character can change value
                const string pattern = "^https://.(.*)$";
                Assert.Equal(Regex.Replace(video1.SmallThumbnailUrl, pattern, "$1"), Regex.Replace(videoThumb.ThumbnailUrl, pattern, "$1"));
                break;
            }
            case PornWebsite.XVideos: {
                // The first subdomain and end of url can change value
                const string pattern = "^http(s)?://[^.]*[.](.*?)[.][0-9]+[.]jpg$";
                Assert.Equal(Regex.Replace(video1.SmallThumbnailUrl, pattern, "$2").Replace("-1", "").Replace("thumbs169ll", "thumbs169"),
                             Regex.Replace(videoThumb.ThumbnailUrl, pattern, "$2").Replace("-1", "").Replace("thumbs169ll", "thumbs169"));
                break;
            }
            case PornWebsite.YouPorn: {
                // The first subdomain of url can change value
                const string pattern = "^https://[^.]*([^=]*).*$";
                Assert.Equal(Regex.Replace(video1.SmallThumbnailUrl, pattern, "$1"), Regex.Replace(videoThumb.ThumbnailUrl, pattern, "$1"));
                break;
            }
            default:
                Assert.Equal(video1.SmallThumbnailUrl, videoThumb.ThumbnailUrl);
                break;
        }
        switch (video1.Website) {
            case PornWebsite.Pornhub:
                Assert.Equal(video1.PageUrl, videoThumb.PageUrl);
                break;
            case PornWebsite.XVideos:
                // End of url can change value
                const string pattern = "^https://www.xvideos.com/video([0-9]+)/.*$";
                Assert.Equal(Regex.Replace(video1.PageUrl, pattern, "$1"), Regex.Replace(videoThumb.PageUrl, pattern, "$1"));
                break;
            case PornWebsite.YouPorn:
                Assert.Equal(video1.PageUrl, videoThumb.PageUrl);
                break;
            default: throw new ArgumentOutOfRangeException(nameof(video1.Website), video1.Website, null);
        }
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
                Assert.Equal(Regex.Replace(video1.ThumbnailUrl, pattern, "$1"), Regex.Replace(video2.ThumbnailUrl, pattern, "$1"));
                Assert.Equal(Regex.Replace(video1.SmallThumbnailUrl, pattern, "$1"),
                             Regex.Replace(video2.SmallThumbnailUrl, pattern, "$1"));
                break;
            }
            case PornWebsite.XVideos: {
                // The first subdomain and end of url can change value
                const string pattern = "^http(s)?://[^.]*[.](.*?)[.][0-9]+[.]jpg$";
                Assert.Equal(Regex.Replace(video1.ThumbnailUrl, pattern, "$2").Replace("-1", ""),
                             Regex.Replace(video2.ThumbnailUrl, pattern, "$2").Replace("-1", ""));
                Assert.Equal(Regex.Replace(video1.SmallThumbnailUrl, pattern, "$2").Replace("-1", ""),
                             Regex.Replace(video2.SmallThumbnailUrl, pattern, "$2").Replace("-1", ""));
                break;
            }
            case PornWebsite.YouPorn: {
                // The first subdomain of url can change value
                const string pattern = "^https://[^.]*(.*)$";
                Assert.Equal(Regex.Replace(video1.ThumbnailUrl, pattern, "$1"), Regex.Replace(video2.ThumbnailUrl, pattern, "$1"));
                Assert.Equal(Regex.Replace(video1.SmallThumbnailUrl, pattern, "$1"),
                             Regex.Replace(video2.SmallThumbnailUrl, pattern, "$1"));
                break;
            }
            default: throw new ArgumentOutOfRangeException();
        }
        Assert.Equal(video1.PageUrl, video2.PageUrl);
        Assert.Equal(video1.VideoEmbedUrl, video2.VideoEmbedUrl);
        Assert.Equal(video1.Duration, video2.Duration);
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
            foreach (PornIdName t in video1.Tags) {
                string tagId1 = CleanTagId(t.Id, video1.Website);
                string tagId2 = CleanTagId(t.Id, video1.Website);
                Assert.Equal(tagId1, tagId2);

                string tagName1 = CleanTagName(t.Name, video1.Website, video1.SexOrientation);
                string tagName2 = CleanTagName(t.Name, video1.Website, video1.SexOrientation);
                Assert.Equal(tagName1, tagName2);
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
        if (video1.NbLikes == null)
            Assert.Null(video2.NbLikes);
        else
            Assert.True(video1.NbLikes <= video2.NbLikes);
        if (video1.NbDislikes == null)
            Assert.Null(video2.NbDislikes);
        else
            Assert.True(video1.NbDislikes <= video2.NbDislikes);
        Assert.Equal(video1.Date, video2.Date);
        if (video1.RelatedVideos != null) {
            Assert.Equal(video1.RelatedVideos.Count, video2.RelatedVideos.Count);
            switch (video1.Website) {
                case PornWebsite.Pornhub: {
                    for (int i = 0; i < video1.RelatedVideos.Count; i++)
                        PornVideoThumbAssert.Equal(video1.RelatedVideos[i], video2.RelatedVideos[i]);
                    break;
                }
                case PornWebsite.XVideos: {
                    for (int i = 0; i < video1.RelatedVideos.Count; i++)
                        PornVideoThumbAssert.Equal(video1.RelatedVideos[i], video2.RelatedVideos[i]);
                    break;
                }
                case PornWebsite.YouPorn: {
                    for (int i = 0; i < video1.RelatedVideos.Count; i++) {
                        PornVideoThumb videothumb = video2.RelatedVideos.FirstOrDefault(v => v.Id == video1.RelatedVideos[i].Id);
                        if (videothumb != null)
                            PornVideoThumbAssert.Equal(video1.RelatedVideos[i], videothumb);
                    }
                    break;
                }
                default: throw new ArgumentOutOfRangeException();
            }
        }
    }

    private static string CleanTagId(string tagId, PornWebsite website) {
        if (website == PornWebsite.Pornhub)
            switch (tagId) {
                case "/gay/video?c=352": return "/gay/video/search?search=cumshot";
            }
        return tagId;
    }

    private static string CleanTagName(string tagName, PornWebsite website, PornSexOrientation sexOrientation) {
        if (website == PornWebsite.Pornhub && sexOrientation == PornSexOrientation.Gay && tagName.StartsWith("Gay "))
            return tagName.Substring(4);
        return tagName;
    }

    private static string CleanTitle(string title, PornWebsite website) {
        if (website == PornWebsite.XVideos) {
            List<string> terms = new List<string> {
                "mom",
                "moms",
                "cousin",
                "father",
                "father's",
                "grandma",
                "sister",
                "daddy",
                "tears",
                "sleepyhead",
                "son",
                "bros",
                "Babygirl",
                "Dad",
                "daughter",
                "daddys",
                "Nina",
                "Fathers\"",
                "MommysGirl",
                "mothers",
                "Beats",
                "Brothers",
                "baby",
                "brother in law",
                "bait",
                "hooker",
                "Father's",
                "unwillingly",
                "DADDY",
                "Escort",
                "Bro",
                "Sis",
                "school",
                "http://",
                "https://"
            };
            return Regex.Replace(title, $"\\b({string.Join("|", terms)})\\b", "", RegexOptions.IgnoreCase).Replace("  ", " ").Trim();
        }
        if (website == PornWebsite.YouPorn) {
            List<string> terms = new List<string> {
                "Young",
                "Skinny boy"
            };
            return Regex.Replace(title, $"\\b({string.Join("|", terms)})\\b", "", RegexOptions.IgnoreCase)
                        .Replace("  ", " ")
                        .Replace("  ", " ")
                        .Trim();
        }
        return title;
    }

    private static string CleanChannelId(string channelId, PornWebsite website) {
        if (website == PornWebsite.XVideos)
            switch (channelId) {
                case "/illico-porno": return "/porno_baguette";
                case "/sansaint":     return "/duncan_saint_official";
                case "/katty-west":   return "/katty_west_official";
            }
        if (website == PornWebsite.YouPorn) {
            channelId = channelId.Replace("/gay/", "/");
            return channelId.StartsWith("/uservids/") ? "" : channelId;
        }
        return channelId;
    }

    private static string CleanChannelName(PornIdName channel, PornWebsite website) {
        if (website == PornWebsite.XVideos)
            switch (channel.Name) {
                case "GenderX Official": return "GenderX Films";
                case "Illico Porno":     return "Porno Baguette";
                case "Finishme2":        return "Finish Me";
                case "Katty West":       return "Katty West Official";
                case "Kompound1":        return "Kompound";
            }
        if (website == PornWebsite.YouPorn)
            return channel.Id.StartsWith("/uservids/") ? "" : channel.Name;
        return channel.Name;
    }
}
