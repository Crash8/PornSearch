using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using JetBrains.Annotations;
using PornSearch.Tests.Enums;
using Xunit;

namespace PornSearch.Tests.Asserts
{
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
            if (website == PornWebsite.Pornhub) {
                if (string.IsNullOrWhiteSpace(filter))
                    return page == 1 ? new[] { 32, 32 } : new[] { 44, 44 };
                if (pageSearch == PageSearch.Channel && page == 1)
                    return new[] { 22, 22 };
                return new[] { 20, 20 };
            }
            if (website == PornWebsite.XVideos)
                return string.IsNullOrWhiteSpace(filter) && page == 1 ? new[] { 46, 48 } : new[] { 25, 27 };
            throw new NotImplementedException();
        }

        [AssertionMethod]
        public static void CheckAll(List<PornVideoThumb> videosThumbs, PornWebsite website, string filter,
                                    PornSexOrientation sexOrientation) {
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
            Assert_VideoThumb_Title(videoThumb.Title);
            Assert.NotNull(videoThumb.Channel);
            Assert_VideoThumb_Channel_Id(videoThumb.Channel.Id, website);
            Assert_VideoThumb_Channel_Name(videoThumb.Channel.Name);
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
                    Assert.Matches("^(ph[0-9a-f]{13}|[0-9]{5,10}|[a-f0-9]{20})$", id);
                    break;
                case PornWebsite.XVideos:
                    Assert.Matches("^/video[0-9]{5,8}/[^\\s]*$", id);
                    break;
                default: throw new ArgumentOutOfRangeException(nameof(website), website, null);
            }
        }

        private static void Assert_VideoThumb_Title(string title) {
            Assert.NotNull(title);
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
                    Assert.Matches("^/(channels|profiles|models|pornstar-channels|amateur-channels|model-channels|amateurs|pornstars)/[^/\\s]*$",
                                   channelId);
                    break;
                default: throw new ArgumentOutOfRangeException(nameof(website), website, null);
            }
        }

        private static void Assert_VideoThumb_Channel_Name(string channelName) {
            Assert.NotNull(channelName);
            Assert.NotEqual("", channelName.Trim());
            Assert.Equal(HttpUtility.HtmlDecode(channelName), channelName);
        }

        [AssertionMethod]
        private static void Assert_VideoThumb_ThumbnailUrl(string thumbnailUrl, PornWebsite website) {
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
        private static void Assert_VideoThumb_PageUrl(string pageUrl, PornWebsite website) {
            Assert.NotNull(pageUrl);
            switch (website) {
                case PornWebsite.Pornhub:
                    Assert.Matches("^https://www[.]pornhub[.]com/view_video[.]php[?]viewkey=(ph[0-9a-f]{13}|[0-9]{5,10}|[a-f0-9]{20})$",
                                   pageUrl);
                    break;
                case PornWebsite.XVideos:
                    Assert.Matches("^https://www[.]xvideos[.]com/video[0-9]{5,8}/[^\\s]*$", pageUrl);
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
                    Assert.Equal($"https://www.xvideos.com{id}", pageUrl);
                    break;
                default: throw new ArgumentOutOfRangeException(nameof(website), website, null);
            }
        }

        private static void Assert_VideoThumb_Not_Same_Value(PornVideoThumb videoThumb) {
            Assert_All_Not_Same_Value(new List<PornVideoThumb> { videoThumb });
        }

        private static void Assert_All_Not_Same_Value(List<PornVideoThumb> videoThumbs) {
            foreach (PornVideoThumb videoThumb in videoThumbs) {
                const int tolerance = 2;

                Assert.Equal(0, videoThumbs.Count(i => videoThumb.Id == i.Title));
                Assert.Equal(0, videoThumbs.Count(i => videoThumb.Id == i.Channel.Id));
                Assert.Equal(0, videoThumbs.Count(i => videoThumb.Id == i.Channel.Name));
                Assert.Equal(0, videoThumbs.Count(i => videoThumb.Id == i.ThumbnailUrl));
                Assert.Equal(0, videoThumbs.Count(i => videoThumb.Id == i.PageUrl));

                Assert.Equal(0, videoThumbs.Count(i => videoThumb.Title == i.Channel.Id));
                Assert.Equal(0, videoThumbs.Count(i => videoThumb.Title == i.ThumbnailUrl));
                Assert.Equal(0, videoThumbs.Count(i => videoThumb.Title == i.PageUrl));

                Assert.Equal(0, videoThumbs.Count(i => videoThumb.Channel.Id == i.Channel.Name));
                Assert.Equal(0, videoThumbs.Count(i => videoThumb.Channel.Id == i.ThumbnailUrl));
                Assert.Equal(0, videoThumbs.Count(i => videoThumb.Channel.Id == i.PageUrl));

                Assert.True(videoThumbs.Count(i => videoThumb.Channel.Name == i.Title) <= tolerance,
                            videoThumbs.Count(i => videoThumb.Channel.Name == i.Title).ToString());
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
                    const string pattern = "^https://[^.]*[.](.*?)[.][0-9]+[.]jpg$";
                    Assert.Equal(Regex.Replace(videoThumb1.ThumbnailUrl, pattern, "$1"),
                                 Regex.Replace(videoThumb2.ThumbnailUrl, pattern, "$1"));
                    break;
                }
                default:
                    Assert.Equal(videoThumb1.ThumbnailUrl, videoThumb2.ThumbnailUrl);
                    break;
            }
            Assert.Equal(videoThumb1.PageUrl, videoThumb2.PageUrl);
        }
    }
}
