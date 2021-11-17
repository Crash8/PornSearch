using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace PornSearch
{
    internal class XVideosSearchWebsite : AbstractSearchWebsite
    {
        private const string RegExVideoThumb =
            "<div.*class=\"thumb-block.*<img.*?data-src=\"(.*?)\".*?<a href=\"(/video([0-9]+).*?)\" title=\"(.*?)\".*"
            + "<a href=\"/[^/]*(.*?)\">" + "<span.*?>(.*?)<";

        public override List<PornSexOrientation> GetSexOrientations() {
            return new List<PornSexOrientation> {
                PornSexOrientation.Straight,
                PornSexOrientation.Gay,
                PornSexOrientation.Trans
            };
        }

        protected override string MakeUrl(PornSearchFilter searchFilter) {
            string url = "https://www.xvideos.com";
            if (string.IsNullOrWhiteSpace(searchFilter.Filter)) {
                switch (searchFilter.SexOrientation) {
                    case PornSexOrientation.Straight: {
                        if (searchFilter.Page > 1)
                            url += "/new";
                        break;
                    }
                    case PornSexOrientation.Gay:
                        url += "/gay";
                        break;
                    case PornSexOrientation.Trans:
                        url += "/shemale";
                        break;
                    default: throw new ArgumentOutOfRangeException();
                }
                if (searchFilter.Page > 1)
                    url += $"/{searchFilter.Page - 1}";
            }
            else {
                string k = string.Join("+", searchFilter.Filter.Split(' ').Select(Uri.EscapeDataString)).ToLower();
                url += $"/?k={k}";
                switch (searchFilter.SexOrientation) {
                    case PornSexOrientation.Straight: {
                        url += "&typef=straight";
                        break;
                    }
                    case PornSexOrientation.Gay:
                        url += "&typef=gay";
                        break;
                    case PornSexOrientation.Trans:
                        url += "&typef=shemale";
                        break;
                    default: throw new ArgumentOutOfRangeException();
                }
                if (searchFilter.Page > 1)
                    url += $"&p={searchFilter.Page - 1}";
            }
            return url;
        }

        protected override bool IsContentNotFound(string content) {
            return content.IndexOf("<div class=\"mozaique", StringComparison.Ordinal) == -1;
        }

        protected override string GetContentPaginationInContent(string content) {
            int startIndex = content.IndexOf("<div class=\"pagination", StringComparison.Ordinal);
            if (startIndex > 0) {
                int endIndex = content.IndexOf("</ul>", startIndex, StringComparison.Ordinal);
                return content.Substring(startIndex, endIndex - startIndex);
            }
            return null;
        }

        protected override bool IsNextButtonInContentPagination(string contentPagination) {
            return contentPagination.IndexOf("class=\"no-page next-page\"", StringComparison.Ordinal) > -1;
        }

        protected override int? GetPageActiveInContentPagination(string contentPagination) {
            Match matchPageActive = Regex.Match(contentPagination, "<a class=\"active\" href=\"\">([^<]*)</a>");
            return Convert.ToInt32(matchPageActive.Groups[1].Value);
        }

        protected override List<PornVideoThumb> ExtractVideoThumbs(string content, PornSearchFilter searchFilter) {
            int startIndex = content.IndexOf("<div class=\"mozaique", StringComparison.Ordinal);
            int endIndex = content.IndexOf("<div id=\"footer", startIndex, StringComparison.Ordinal);
            string contentItems = content.Substring(startIndex, endIndex - startIndex);
            return Regex.Matches(contentItems, RegExVideoThumb)
                        .Cast<Match>()
                        .Select(m => new PornVideoThumb {
                                    Website = searchFilter.Website,
                                    SexOrientation = searchFilter.SexOrientation,
                                    Id = m.Groups[3].Value,
                                    Title = HtmlDecode(m.Groups[4].Value),
                                    Channel = new PornIdName {
                                        Id = m.Groups[5].Value,
                                        Name = HtmlDecode(m.Groups[6].Value)
                                    },
                                    ThumbnailUrl = m.Groups[1].Value.Replace("THUMBNUM", "1"),
                                    PageUrl = $"https://www.xvideos.com{m.Groups[2].Value.Replace("/THUMBNUM", "")}"
                                })
                        .ToList();
        }

        public override PornSourceVideo GetSourceVideo(string url) {
            const string pattern = "^https://www[.]xvideos[.]com/video([0-9]+)/[^\\s]*$";
            Match match = Regex.Match(url, pattern);
            return !match.Success
                ? null
                : new PornSourceVideo {
                    Id = match.Groups[1].Value,
                    Website = PornWebsite.XVideos
                };
        }

        protected override string MakeUrlVideo(string videoId) {
            return $"https://www.xvideos.com/video{videoId}/";
        }

        protected override bool IsVideoContentNotFound(string content) {
            return false;
        }

        protected override PornVideo ExtractVideo(string content) {
            PornVideo video = new PornVideo { Website = PornWebsite.XVideos };
            FillVideoFromHeaderContent(content, ref video);
            FillVideoFromAboveContent(content, ref video);
            FillVideo_Actors(content, ref video);
            FillVideo_Tags(content, ref video);
            FillVideoFromCenterContent(content, ref video);
            FillVideoFromBelowContent(content, ref video);
            FillVideo_RelatedVideos(content, ref video);
            return video;
        }

        private static void FillVideoFromHeaderContent(string content, ref PornVideo video) {
            const string pattern = "<meta property=\"og:title\" content=\"([^\"]*)\" />[\\s\\S]*?"
                                   + "<meta property=\"og:url\" content=\"([^0-9]+([0-9]+)/[^\"]*)\" />[\\s\\S]*?"
                                   + "<meta property=\"og:image\" content=\"([^\"]*)\" />[\\s\\S]*?"
                                   + ",\"page_main_cat\":\"([^\"]*)";
            Match match = Regex.Match(content, pattern);
            if (match.Success) {
                Enum.TryParse(match.Groups[5].Value, true, out PornSexOrientation sexOrientation);
                video.SexOrientation = sexOrientation;
                video.Id = match.Groups[3].Value;
                video.Title = HtmlDecode(match.Groups[1].Value);
                video.SmallThumbnailUrl = match.Groups[4].Value;
                video.PageUrl = match.Groups[2].Value;
            }
        }

        private static void FillVideoFromAboveContent(string content, ref PornVideo video) {
            const string pattern =
                "<a href=\"/[^/]*([^\"]*)\" class=\"[^\"]*?label main uploader-tag hover-name\"><span.*?>([^<]*)";
            Match match = Regex.Match(content, pattern);
            if (match.Success)
                video.Channel = new PornIdName {
                    Id = match.Groups[1].Value,
                    Name = HtmlDecode(match.Groups[2].Value)
                };
        }

        private static void FillVideo_Actors(string content, ref PornVideo video) {
            int startIndex = content.IndexOf("<div class=\"video-metadata ", StringComparison.Ordinal);
            if (startIndex < 0) {
                video.Actors = new List<PornIdName>();
                return;
            }
            int endIndex = content.IndexOf("</div>", startIndex, StringComparison.Ordinal);
            content = content.Substring(startIndex, endIndex - startIndex);
            const string pattern = "<a href=\"([^\"]*)\" class=\"[^\"]*profile hover-name\"><span.*?>([^<]*)";
            MatchCollection matches = Regex.Matches(content, pattern);
            video.Actors = matches.Cast<Match>()
                                  .Select(m => new PornIdName {
                                              Id = m.Groups[1].Value,
                                              Name = HtmlDecode(m.Groups[2].Value)
                                          })
                                  .ToList();
        }

        private static void FillVideo_Tags(string content, ref PornVideo video) {
            int startIndex = content.IndexOf("<div class=\"video-metadata ", StringComparison.Ordinal);
            if (startIndex < 0) {
                video.Tags = new List<PornIdName>();
                return;
            }
            int endIndex = content.IndexOf("</div>", startIndex, StringComparison.Ordinal);
            content = content.Substring(startIndex, endIndex - startIndex);
            MatchCollection matches = Regex.Matches(content, "<a href=\"(/tags/[^\"]*)\".*?>([^<]*)");
            video.Tags = matches.Cast<Match>()
                                .Select(m => new PornIdName {
                                            Id = m.Groups[1].Value,
                                            Name = HtmlDecode(m.Groups[2].Value)
                                        })
                                .ToList();
        }

        private static void FillVideoFromCenterContent(string content, ref PornVideo video) {
            const string pattern = "html5player[.]setThumbUrl169[(]'([^']*)";
            Match match = Regex.Match(content, pattern);
            if (match.Success)
                video.ThumbnailUrl = match.Groups[1].Value;
        }

        private static void FillVideoFromBelowContent(string content, ref PornVideo video) {
            const string pattern = "<div id=\"v-views\".*?<strong.*?>([^<]*).*?" + "<span class=\"rating-good-nbr\">([^<]*).*?"
                                                                                 + "<span class=\"rating-bad-nbr\">([^<]*)";
            Match match = Regex.Match(content, pattern);
            if (match.Success) {
                video.NbViews = ConvertToInt(match.Groups[1].Value);
                video.NbLikes = ConvertToInt(match.Groups[2].Value);
                video.NbDislikes = ConvertToInt(match.Groups[3].Value);
            }
        }

        private static void FillVideo_RelatedVideos(string content, ref PornVideo video) {
            int startIndex = content.IndexOf("<script>var video_related=", StringComparison.Ordinal);
            if (startIndex < 0) {
                video.RelatedVideos = new List<PornVideoThumb>();
                return;
            }
            int endIndex = content.IndexOf("</script>", startIndex, StringComparison.Ordinal);
            string contentItems = content.Substring(startIndex, endIndex - startIndex);
            PornWebsite website = video.Website;
            PornSexOrientation sexOrientation = video.SexOrientation;
            const string pattern = "{\"id\":([^,]*).*?,\"u\":\"([^\"]*)\".*?,\"i\":\"([^\"]*)\".*?,\"tf\":\"([^\"]*)\".*?"
                                   + ",\"pn\":\"([^\"]*)\".*?,\"pu\":\"\\\\/[^/]*([^\"]*)";
            video.RelatedVideos = Regex.Matches(contentItems, pattern)
                                       .Cast<Match>()
                                       .Select(m => new PornVideoThumb {
                                                   Website = website,
                                                   SexOrientation = sexOrientation,
                                                   Id = m.Groups[1].Value,
                                                   Title = HtmlDecode(m.Groups[4].Value),
                                                   Channel = new PornIdName {
                                                       Id = m.Groups[6].Value.Replace("\\/", "/"),
                                                       Name = HtmlDecode(m.Groups[5].Value)
                                                   },
                                                   ThumbnailUrl = m.Groups[3].Value.Replace("\\/", "/"),
                                                   PageUrl = $"https://www.xvideos.com{m.Groups[2].Value.Replace("\\/", "/")}"
                                               })
                                       .ToList();
        }
    }
}
