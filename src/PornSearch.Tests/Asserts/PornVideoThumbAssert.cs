using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using JetBrains.Annotations;
using PornSearch.Tests.Enums;
using Xunit;

namespace PornSearch.Tests.Asserts;

public static class PornVideoThumbAssert
{
    [AssertionMethod]
    public static void Check_NbVideo_ByPage(int nbVideo, PornSearchFilter searchFilter, PageSearch pageSearch) {
        PornWebsite website = searchFilter.Website;
        string filter = searchFilter.Filter;
        int page = searchFilter.Page;
        string description = $"{website}, '{filter}', {page}, {searchFilter.SexOrientation}";
        int[] nbVideoMax = GetNbVideoMaxByPage(website, filter, page, pageSearch);
        switch (pageSearch) {
            case PageSearch.Empty:
                Assert.True(0 == nbVideo, $"Value = 0, Value: {nbVideo} - {description}");
                break;
            case PageSearch.Complete:
                // If for Pornhub the search filter is empty, Channel Id may be empty if the video is not available in your country
                int tolerance = website == PornWebsite.Pornhub && string.IsNullOrWhiteSpace(filter) ? 2 : 0;
                Assert.True(nbVideo >= nbVideoMax[0] - tolerance,
                            $"Value >= {nbVideoMax[0] - tolerance}, Value: {nbVideo} - {description}");
                Assert.True(nbVideo <= nbVideoMax[1], $"Value <= {nbVideoMax[1]}, Value: {nbVideo} - {description}");
                break;
            case PageSearch.Channel:
                Assert.True(nbVideo >= 0, $"Value >= 0, Value: {nbVideo} - {description}");
                Assert.True(nbVideo <= nbVideoMax[1], $"Value <= {nbVideoMax[1]}, Value: {nbVideo} - {description}");
                break;
            case PageSearch.Partial:
                Assert.True(nbVideo > 0, $"Value > 0, Value: {nbVideo} - {description}");
                Assert.True(nbVideo <= nbVideoMax[1], $"Value <= {nbVideoMax[1]}, Value: {nbVideo} - {description}");
                break;
            default: throw new ArgumentOutOfRangeException(nameof(pageSearch), pageSearch, null);
        }
    }

    public static int[] GetNbVideoMaxByPage(PornWebsite website, string filter, int page, PageSearch pageSearch) {
        return website switch {
            PornWebsite.Pornhub when string.IsNullOrWhiteSpace(filter) => page == 1 ? new[] { 32, 32 } : new[] { 44, 44 },
            PornWebsite.Pornhub when pageSearch == PageSearch.Channel && page == 1 => new[] { 30, 30 },
            PornWebsite.Pornhub => page == 1 ? new[] { 31, 32 } : new[] { 43, 44 },
            PornWebsite.XVideos => string.IsNullOrWhiteSpace(filter) && page == 1 ? new[] { 47, 48 } : new[] { 26, 27 },
            PornWebsite.YouPorn when string.IsNullOrWhiteSpace(filter) => page == 1 ? new[] { 34, 34 } : new[] { 36, 36 },
            PornWebsite.YouPorn => new[] { 32, 32 },
            _ => throw new NotImplementedException()
        };
    }

    [AssertionMethod]
    public static void CheckAll(List<PornVideoThumb> videosThumbs, PornWebsite website, string filter, PornSexOrientation sexOrientation) {
        Assert.NotNull(videosThumbs);
        foreach (PornVideoThumb videoThumb in videosThumbs)
            Assert_VideoThumb(videoThumb, website, sexOrientation);
        Assert_All_Unique_Value(videosThumbs, website, filter, sexOrientation);
        Assert_All_Not_Same_Value(videosThumbs);
    }

    [AssertionMethod]
    private static void Assert_VideoThumb(PornVideoThumb videoThumb, PornWebsite website, PornSexOrientation sexOrientation) {
        Assert.NotNull(videoThumb);
        Assert.Equal(website, videoThumb.Website);
        Assert.Equal(sexOrientation, videoThumb.SexOrientation);
        Assert_VideoThumb_Id(videoThumb.Id, website);
        Assert_VideoThumb_Title(videoThumb.Title, website);
        Assert.NotNull(videoThumb.Channel);
        Assert_VideoThumb_Channel_Id(videoThumb.Channel.Id, website);
        Assert_VideoThumb_Channel_Name(videoThumb.Channel.Name, website);
        Assert_VideoThumb_ThumbnailUrl(videoThumb.ThumbnailUrl, website);
        Assert_VideoThumb_PageUrl(videoThumb.PageUrl, website);
        Assert_VideoThumb_Link_Id_PageUrl(videoThumb.Id, videoThumb.PageUrl, website);
        Assert_VideoThumb_Not_Same_Value(videoThumb);
    }

    [AssertionMethod]
    private static void Assert_VideoThumb_Id(string id, PornWebsite website) {
        Assert.NotNull(id);
        switch (website) {
            case PornWebsite.Pornhub:
                Assert.Matches("^(ph[0-9a-f]{13}|[0-9]{5,10}|[a-f0-9]{20}|[0-9a-f]{13})$", id);
                break;
            case PornWebsite.XVideos:
                Assert.Matches("^[a-z0-9]{7,11}$", id);
                break;
            case PornWebsite.YouPorn:
                Assert.Matches("^[0-9]{4,9}$", id);
                break;
            default: throw new ArgumentOutOfRangeException(nameof(website), website, null);
        }
    }

    private static void Assert_VideoThumb_Title(string title, PornWebsite website) {
        Assert.NotNull(title);
        if (website != PornWebsite.XVideos)
            Assert.NotEqual("", title.Trim());
        Assert.Equal(HttpUtility.HtmlDecode(title), title);
        Assert.DoesNotContain("\u00A0", title);
    }

    [AssertionMethod]
    private static void Assert_VideoThumb_Channel_Id(string channelId, PornWebsite website) {
        Assert.NotNull(channelId);
        switch (website) {
            case PornWebsite.Pornhub:
                Assert.Matches("^/(channels|model|pornstar|users)/[^/\\s]*$", channelId);
                break;
            case PornWebsite.XVideos:
                if (channelId != "")
                    Assert.Matches("^/[^/\\s]*$", channelId);
                break;
            case PornWebsite.YouPorn:
                if (channelId != "")
                    Assert.Matches("^(/gay)?/channel/[^/\\s]*/$", channelId);
                break;
            default: throw new ArgumentOutOfRangeException(nameof(website), website, null);
        }
    }

    private static void Assert_VideoThumb_Channel_Name(string channelName, PornWebsite website) {
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
                if (channelName != "") {
                    Assert.NotEqual("", channelName.Trim());
                    Assert.Equal(HttpUtility.HtmlDecode(channelName), channelName);
                }
                break;
            default: throw new ArgumentOutOfRangeException(nameof(website), website, null);
        }
    }

    [AssertionMethod]
    private static void Assert_VideoThumb_ThumbnailUrl(string thumbnailUrl, PornWebsite website) {
        Assert.NotNull(thumbnailUrl);
        switch (website) {
            case PornWebsite.Pornhub:
                Assert.Matches("^https://[bcde]i[.]phncdn[.]com/videos[^\\s]*[.]jpg$", thumbnailUrl);
                break;
            case PornWebsite.XVideos:
                Assert.Matches("^http(s)?://(cdn77-pic|img-l3|img-hw|img-cf|img-egc|gcore-pic)[.]xvideos-cdn[.]com/videos(_new)*/thumbs[^\\s.]*?[.][0-9]+[.]jpg$",
                               thumbnailUrl);
                break;
            case PornWebsite.YouPorn:
                Assert.Matches("^https://(fi1|fi1-ph|di1|di1-ph)[.]ypncdn[.]com/(videos/|m=eafT8f/)?[0-9]{6}/[0-9]{2}/[0-9]{4,9}/[^\\s.]*[.]jpg$",
                               thumbnailUrl);
                break;
            default: throw new ArgumentOutOfRangeException(nameof(website), website, null);
        }
    }

    [AssertionMethod]
    private static void Assert_VideoThumb_PageUrl(string pageUrl, PornWebsite website) {
        Assert.NotNull(pageUrl);
        switch (website) {
            case PornWebsite.Pornhub:
                Assert.Matches("^https://www[.]pornhub[.]com/view_video[.]php[?]viewkey=(ph[0-9a-f]{13}|[0-9]{5,10}|[a-f0-9]{20}|[0-9a-f]{13})$",
                               pageUrl);
                break;
            case PornWebsite.XVideos:
                Assert.Matches("^https://www[.]xvideos[.]com/video[.][a-z0-9]{7,11}/[^\\s]+$", pageUrl);
                break;
            case PornWebsite.YouPorn:
                Assert.Matches("^https://www[.]youporn[.]com/watch/[0-9]{4,9}[^\\s]+$", pageUrl);
                break;
            default: throw new ArgumentOutOfRangeException(nameof(website), website, null);
        }
    }

    [AssertionMethod]
    private static void Assert_VideoThumb_Link_Id_PageUrl(string id, string pageUrl, PornWebsite website) {
        switch (website) {
            case PornWebsite.Pornhub:
                Assert.Equal($"https://www.pornhub.com/view_video.php?viewkey={id}", pageUrl);
                break;
            case PornWebsite.XVideos:
                Assert.StartsWith($"https://www.xvideos.com/video.{id}/", pageUrl);
                break;
            case PornWebsite.YouPorn:
                Assert.StartsWith($"https://www.youporn.com/watch/{id}/", pageUrl);
                break;
            default: throw new ArgumentOutOfRangeException(nameof(website), website, null);
        }
    }

    private static void Assert_VideoThumb_Not_Same_Value(PornVideoThumb videoThumb) {
        Assert_All_Not_Same_Value(new List<PornVideoThumb> { videoThumb });
    }

    private static void Assert_All_Not_Same_Value(List<PornVideoThumb> videoThumbs) {
        foreach (PornVideoThumb videoThumb in videoThumbs) {
            Assert.Equal(0, videoThumbs.Count(i => videoThumb.Id == i.Title));
            Assert.Equal(0, videoThumbs.Count(i => videoThumb.Id == i.Channel.Id));
            Assert.Equal(0, videoThumbs.Count(i => videoThumb.Id == i.Channel.Name));
            Assert.Equal(0, videoThumbs.Count(i => videoThumb.Id == i.ThumbnailUrl));
            Assert.Equal(0, videoThumbs.Count(i => videoThumb.Id == i.PageUrl));

            Assert.Equal(0, videoThumbs.Where(i => i.Channel.Id != "").Count(i => videoThumb.Title == i.Channel.Id));
            Assert.Equal(0, videoThumbs.Count(i => videoThumb.Title == i.ThumbnailUrl));
            Assert.Equal(0, videoThumbs.Count(i => videoThumb.Title == i.PageUrl));

            Assert.Equal(0, videoThumbs.Where(i => i.Channel.Name != "").Count(i => videoThumb.Channel.Id == i.Channel.Name));
            Assert.Equal(0, videoThumbs.Count(i => videoThumb.Channel.Id == i.ThumbnailUrl));
            Assert.Equal(0, videoThumbs.Count(i => videoThumb.Channel.Id == i.PageUrl));

            Assert.Equal(0, videoThumbs.Count(i => videoThumb.Channel.Name == i.ThumbnailUrl));
            Assert.Equal(0, videoThumbs.Count(i => videoThumb.Channel.Name == i.PageUrl));

            Assert.Equal(0, videoThumbs.Count(i => videoThumb.ThumbnailUrl == i.PageUrl));
        }
    }

    public static void Check_All_Unique_Value_ByPage(List<PornVideoThumb> videoThumbs) {
        Assert.NotNull(videoThumbs);
        Assert_All_Unique_Value(videoThumbs, true);
    }

    private static void Assert_All_Unique_Value(List<PornVideoThumb> videoThumbs, PornWebsite website, string filter,
                                                PornSexOrientation sexOrientation) {
        bool uniqueValue = true;
        if (website == PornWebsite.Pornhub) {
            // If you search for gay videos with the empty search filter, too many videos can be on multiple pages (e.g. on pages 1 and 2)
            bool notGay = sexOrientation != PornSexOrientation.Gay;
            bool gaySearchNotEmpty = sexOrientation == PornSexOrientation.Gay && !string.IsNullOrWhiteSpace(filter);
            uniqueValue = notGay || gaySearchNotEmpty;
        }
        if (website == PornWebsite.YouPorn)
            uniqueValue = false;
        Assert_All_Unique_Value(videoThumbs, uniqueValue);
    }

    private static void Assert_All_Unique_Value(List<PornVideoThumb> videoThumbs, bool uniqueValue) {
        if (uniqueValue) {
            const int tolerance = 2;
            Assert.True(videoThumbs.Count - videoThumbs.Select(i => i.Id).Distinct().Count() <= tolerance);
            Assert.True(videoThumbs.Count - videoThumbs.Select(i => i.ThumbnailUrl).Distinct().Count() <= tolerance);
            Assert.True(videoThumbs.Count - videoThumbs.Select(i => i.PageUrl).Distinct().Count() <= tolerance);
        }
        Assert.Equal(videoThumbs.Select(i => i.Channel.Id).Distinct().Count(),
                     videoThumbs.Select(i => $"{i.Channel.Id} {i.Channel.Name}").Distinct().Count());
    }

    public static void Equal(PornVideoThumb videoThumb1, PornVideoThumb videoThumb2) {
        Assert.NotNull(videoThumb1);
        Assert.NotNull(videoThumb2);
        Assert.Equal(videoThumb1.Website, videoThumb2.Website);
        Assert.Equal(videoThumb1.SexOrientation, videoThumb2.SexOrientation);
        Assert.Equal(videoThumb1.Id, videoThumb2.Id);
        Assert.Equal(videoThumb1.Title, videoThumb2.Title);

        Assert.Equal(videoThumb1.Channel.Id, videoThumb2.Channel.Id);
        Assert.Equal(videoThumb1.Channel.Name, videoThumb2.Channel.Name);
        switch (videoThumb1.Website) {
            case PornWebsite.Pornhub: {
                // The 9th character can change value
                const string pattern = "^https://.(.*)$";
                Assert.Equal(Regex.Replace(videoThumb1.ThumbnailUrl, pattern, "$1"),
                             Regex.Replace(videoThumb2.ThumbnailUrl, pattern, "$1"));
                break;
            }
            case PornWebsite.XVideos: {
                // The first subdomain and end of url can change value
                const string pattern = "^http(s)?://[^.]*[.](.*?)[.][0-9]+[.]jpg$";
                Assert.Equal(Regex.Replace(videoThumb1.ThumbnailUrl, pattern, "$2").Replace("-1", "").Replace("-2", "").Replace("thumbs169ll", "thumbs169"),
                             Regex.Replace(videoThumb2.ThumbnailUrl, pattern, "$2")
                                  .Replace("-1", "")
                                  .Replace("-2", "")
                                  .Replace("thumbs169ll", "thumbs169"));
                break;
            }
            case PornWebsite.YouPorn: {
                // The first subdomain of url can change value
                const string pattern = "^https://[^.]*(.*)$";
                Assert.Equal(Regex.Replace(videoThumb1.ThumbnailUrl, pattern, "$1"),
                             Regex.Replace(videoThumb2.ThumbnailUrl, pattern, "$1"));
                break;
            }
            default:
                Assert.Equal(videoThumb1.ThumbnailUrl, videoThumb2.ThumbnailUrl);
                break;
        }
        switch (videoThumb1.Website) {
            case PornWebsite.Pornhub: {
                Assert.Equal(videoThumb1.PageUrl, videoThumb2.PageUrl);
                break;
            }
            case PornWebsite.XVideos: {
                if (videoThumb2.PageUrl.EndsWith("/_"))
                    Assert.Equal(videoThumb1.PageUrl.Substring(0, videoThumb2.PageUrl.Length - 1) + "_", videoThumb2.PageUrl);
                else
                    Assert.Equal(videoThumb1.PageUrl, videoThumb2.PageUrl);
                break;
            }
            default:
                Assert.Equal(videoThumb1.PageUrl, videoThumb2.PageUrl);
                break;
        }
    }
}
