using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JetBrains.Annotations;
using PornSearch.Tests.Enums;
using Xunit;

namespace PornSearch.Tests.Asserts
{
    public static class PornItemThumbAssert
    {
        [AssertionMethod]
        public static void Check_NbItem_ByPage(int nbItem, PornSource source, PornSearchFilter searchFilter,
                                               PageSearch pageSearch) {
            int nbItemMax = GetNbItemMaxByPage(source, searchFilter);
            switch (pageSearch) {
                case PageSearch.Empty:
                    Assert.Equal(0, nbItem);
                    break;
                case PageSearch.Complete:
                    Assert.Equal(nbItemMax, nbItem);
                    break;
                default: throw new ArgumentOutOfRangeException(nameof(pageSearch), pageSearch, null);
            }
        }

        private static int GetNbItemMaxByPage(PornSource source, PornSearchFilter searchFilter) {
            if (source == PornSource.Pornhub) {
                if (string.IsNullOrWhiteSpace(searchFilter.Filter))
                    return searchFilter.Page == 1 ? 32 : 44;
                return 20;
            }
            throw new NotImplementedException();
        }

        [AssertionMethod]
        public static void CheckAll(List<PornItemThumb> items, PornSource source, string filter,
                                    PornSexOrientation sexOrientation) {
            Assert.NotNull(items);
            foreach (PornItemThumb item in items)
                Assert_ItemThumb(item, source, filter);
            Assert_All_Unique_Value(items, source, filter, sexOrientation);
            Assert_All_Not_Same_Value(items);
        }

        private static void Assert_ItemThumb(PornItemThumb item, PornSource source, string filter) {
            Assert.NotNull(item);
            Assert_ItemThumb_Id(item.Id, source);
            Assert_ItemThumb_Title(item.Title);
            Assert.NotNull(item.Channel);
            Assert_ItemThumb_Channel_Id(item.Channel.Id, source, filter);
            Assert_ItemThumb_Channel_Name(item.Channel.Name);
            Assert_ItemThumb_ThumbnailUrl(item.ThumbnailUrl, source);
            Assert_ItemThumb_Not_Same_Value(item);
        }

        [AssertionMethod]
        private static void Assert_ItemThumb_Id(string id, PornSource source) {
            Assert.NotNull(id);
            if (source == PornSource.Pornhub)
                Assert.Matches("^(ph[0-9a-f]{13}|[0-9]{8,10})$", id);
            else
                throw new NotImplementedException();
        }

        private static void Assert_ItemThumb_Title(string title) {
            Assert.NotNull(title);
            Assert.True(title.Length > 1);
            Assert.Equal(HttpUtility.HtmlDecode(title), title);
        }

        [AssertionMethod]
        private static void Assert_ItemThumb_Channel_Id(string channelId, PornSource source, string filter) {
            Assert.NotNull(channelId);
            if (source == PornSource.Pornhub) {
                // If the search filter is empty, Channel Id may be empty if the video is not available in your country
                bool isAvailable = !string.IsNullOrWhiteSpace(filter) || !string.IsNullOrEmpty(channelId);
                if (isAvailable)
                    Assert.Matches("^/(channels|model|pornstar)/[^/\\s]*$", channelId);
            }
            else {
                throw new NotImplementedException();
            }
        }

        private static void Assert_ItemThumb_Channel_Name(string channelName) {
            Assert.NotNull(channelName);
            Assert.True(channelName.Length > 1);
            Assert.Equal(HttpUtility.HtmlDecode(channelName), channelName);
        }

        [AssertionMethod]
        private static void Assert_ItemThumb_ThumbnailUrl(string thumbnailUrl, PornSource source) {
            Assert.NotNull(thumbnailUrl);
            if (source == PornSource.Pornhub)
                Assert.Matches("^https://[bcde]i.phncdn.com/videos[^\\s]*[.]jpg$", thumbnailUrl);
            else
                throw new NotImplementedException();
        }

        private static void Assert_ItemThumb_Not_Same_Value(PornItemThumb item) {
            Assert_All_Not_Same_Value(new List<PornItemThumb> { item });
        }

        private static void Assert_All_Not_Same_Value(List<PornItemThumb> items) {
            foreach (PornItemThumb item in items) {
                Assert.Equal(0, items.Count(i => item.Id == i.Title));
                Assert.Equal(0, items.Count(i => item.Id == item.Channel.Id));
                Assert.Equal(0, items.Count(i => item.Id == item.Channel.Name));
                Assert.Equal(0, items.Count(i => item.Id == item.ThumbnailUrl));

                Assert.Equal(0, items.Count(i => item.Title == item.Channel.Id));
                Assert.Equal(0, items.Count(i => item.Title == item.Channel.Name));
                Assert.Equal(0, items.Count(i => item.Title == item.ThumbnailUrl));

                Assert.Equal(0, items.Count(i => item.Channel.Id == item.Channel.Name));
                Assert.Equal(0, items.Count(i => item.Channel.Id == item.ThumbnailUrl));

                Assert.Equal(0, items.Count(i => item.Channel.Name == item.ThumbnailUrl));
            }
        }

        public static void Check_All_Unique_Value_ByPage(List<PornItemThumb> items, PornSource source) {
            Assert.NotNull(items);
            Assert_All_Unique_Value(items, true, source);
        }

        private static void Assert_All_Unique_Value(List<PornItemThumb> items, PornSource source, string filter,
                                                    PornSexOrientation sexOrientation) {
            bool uniqueValue = true;
            if (source == PornSource.Pornhub) {
                // If you search for gay videos with the empty search filter, too many videos can be on multiple pages (e.g. on pages 1 and 2)
                bool notGay = sexOrientation != PornSexOrientation.Gay;
                bool gaySearchNotEmpty = sexOrientation == PornSexOrientation.Gay && !string.IsNullOrWhiteSpace(filter);
                uniqueValue = notGay || gaySearchNotEmpty;
            }
            Assert_All_Unique_Value(items, uniqueValue, source);
        }

        private static void Assert_All_Unique_Value(List<PornItemThumb> items, bool uniqueValue, PornSource source) {
            if (uniqueValue) {
                // Tolerance value of the number of videos that can be found on multiple pages (e.g. consecutive pages)
                int tolerance = source == PornSource.Pornhub ? 1 : 0;
                Assert.True(items.Count - items.Select(i => i.Id).Distinct().Count() <= tolerance);
                Assert.True(items.Count - items.Select(i => i.Title).Distinct().Count() <= tolerance);
                Assert.True(items.Count - items.Select(i => i.ThumbnailUrl).Distinct().Count() <= tolerance);
            }
            Assert.Equal(items.Select(i => i.Channel.Name).Distinct().Count(),
                         items.Select(i => $"{i.Channel.Id} {i.Channel.Name}").Distinct().Count());
        }

        public static void Equal(PornItemThumb item1, PornItemThumb item2, PornSource source) {
            Assert.NotNull(item1);
            Assert.NotNull(item2);

            Assert.Equal(item1.Id, item2.Id);
            Assert.Equal(item1.Title, item2.Title);
            Assert.Equal(item1.Channel.Id, item2.Channel.Id);
            Assert.Equal(item1.Channel.Name, item2.Channel.Name);
            if (source == PornSource.Pornhub) {
                // The 9th character can change value
                int length = item1.ThumbnailUrl.Length;
                Assert.Equal(length, item2.ThumbnailUrl.Length);
                Assert.Equal(item1.ThumbnailUrl.Substring(0, 8), item2.ThumbnailUrl.Substring(0, 8));
                Assert.Equal(item1.ThumbnailUrl.Substring(9, length - 9), item2.ThumbnailUrl.Substring(9, length - 9));
            }
            else {
                Assert.Equal(item1.ThumbnailUrl, item2.ThumbnailUrl);
            }
        }
    }
}
