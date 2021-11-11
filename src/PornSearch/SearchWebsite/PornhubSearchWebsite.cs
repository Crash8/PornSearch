using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Jint;

namespace PornSearch
{
    internal class PornhubSearchWebsite : AbstractSearchWebsite
    {
        private string _cookie;

        private const string RegExVideoThumb =
            "<li class=\"pcVideoListItem[\\s\\S]*?data-video-vkey=\"(.*?)\"[\\s\\S]*?<a href=\"(.*?)\""
            + " title=\"(.*?)\"[\\s\\S]*?data-src = \"(.*?)\"[\\s\\S]*?<div class=\"usernameWrap\">"
            + "[\\s\\S]*?<(?:a|span)(?:.*?href=\"(.*?)\")?.*?>(.*?)<";

        public override List<PornSexOrientation> GetSexOrientations() {
            return new List<PornSexOrientation> {
                PornSexOrientation.Straight,
                PornSexOrientation.Gay
            };
        }

        protected override string MakeUrl(PornSearchFilter searchFilter) {
            string url = $"https://www.pornhub.com{(searchFilter.SexOrientation == PornSexOrientation.Gay ? "/gay" : "")}/video";
            if (!string.IsNullOrWhiteSpace(searchFilter.Filter))
                url += "/search";
            List<string> queries = new List<string>();
            if (!string.IsNullOrWhiteSpace(searchFilter.Filter))
                queries.Add("search=" + string.Join("+", searchFilter.Filter.Split(' ').Select(Uri.EscapeDataString)).ToLower());
            if (searchFilter.Page > 1)
                queries.Add("page=" + searchFilter.Page);
            string query = string.Join("&", queries);
            if (!string.IsNullOrEmpty(query))
                url += "?" + query;
            return url;
        }

        protected override async Task<string> GetPageContentAsync(string url) {
            string content = await GetHtmlContentWithCookieAsync(url, _cookie);
            bool hasNeedCookie = content != null && Regex.IsMatch(content, "Loading[.]{3}");
            if (hasNeedCookie) {
                _cookie = GetCookie(content);
                content = await GetPageContentAsync(url);
            }
            return content;
        }

        private static string GetCookie(string content) {
            content = content.Substring(content.IndexOf("function leastFactor", StringComparison.Ordinal));
            content = content.Substring(0, content.IndexOf("//-->", StringComparison.Ordinal));
            content = content.Replace("document.cookie=", "return ");
            return new Engine().Execute(content).GetValue("go").Invoke().ToString();
        }

        protected override string GetContentPaginationInContent(string content) {
            int startIndex = content.IndexOf("<div class=\"pagination3\">", StringComparison.Ordinal);
            if (startIndex > 0) {
                int endIndex = content.IndexOf("</ul>", startIndex, StringComparison.Ordinal);
                return content.Substring(startIndex, endIndex - startIndex);
            }
            return null;
        }

        protected override bool IsNextButtonInContentPagination(string contentPagination) {
            return contentPagination.IndexOf("class=\"page_next\"", StringComparison.Ordinal) > -1;
        }

        protected override int? GetPageActiveInContentPagination(string contentPagination) {
            Match matchPageActive = Regex.Match(contentPagination, "<li class=\"page_current[^<]*[^>]*>([^<]*)</span>");
            return matchPageActive.Success ? (int?)Convert.ToInt32(matchPageActive.Groups[1].Value) : null;
        }

        protected override bool IsContentNotFound(string content) {
            return content.IndexOf("<div class=\"noResultsWrapper\">", StringComparison.Ordinal) > 0;
        }

        protected override List<PornVideoThumb> ExtractVideoThumbs(string content, PornSearchFilter searchFilter) {
            int startIndex = content.IndexOf("<ul id=\"videoSearchResult\"", StringComparison.Ordinal);
            if (startIndex < 0)
                startIndex = content.IndexOf("<ul id=\"videoCategory\"", StringComparison.Ordinal);
            int otherStartIndex = content.IndexOf("<ul ", startIndex + 4, StringComparison.Ordinal);
            int endIndex = content.IndexOf("</ul>", startIndex, StringComparison.Ordinal);
            if (endIndex > otherStartIndex)
                endIndex = content.IndexOf("</ul>", endIndex + 5, StringComparison.Ordinal);
            string contentItems = content.Substring(startIndex, endIndex - startIndex);
            return Regex.Matches(contentItems, RegExVideoThumb)
                        .Cast<Match>()
                        // If the search filter is empty, Channel Id may be empty if the video is not available in your country
                        .Where(m => m.Groups[5].Value != "")
                        .Select(m => new PornVideoThumb {
                                    Website = searchFilter.Website,
                                    SexOrientation = searchFilter.SexOrientation,
                                    Id = m.Groups[1].Value,
                                    Title = HtmlDecode(m.Groups[3].Value),
                                    Channel = new PornIdName {
                                        Id = m.Groups[5].Value,
                                        Name = HtmlDecode(m.Groups[6].Value)
                                    },
                                    ThumbnailUrl = m.Groups[4].Value,
                                    PageUrl = $"https://www.pornhub.com{m.Groups[2].Value}"
                                })
                        .ToList();
        }

        public override PornSourceVideo GetSourceVideo(string url) {
            const string pattern = "^https://[a-z]{2,3}[.]pornhub[.]com/view_video[.]php[?]viewkey=([^\\s]+)$";
            Match match = Regex.Match(url, pattern);
            return !match.Success
                ? null
                : new PornSourceVideo {
                    Id = match.Groups[1].Value,
                    Website = PornWebsite.Pornhub
                };
        }

        protected override string MakeUrlVideo(string videoId) {
            return $"https://www.pornhub.com/view_video.php?viewkey={videoId}";
        }

        protected override bool IsVideoContentNotFound(string content) {
            return content.IndexOf("<div class=\"geoBlocked\">", StringComparison.Ordinal) > 0
                   || content.IndexOf("<section class=\"noVideo\">", StringComparison.Ordinal) > 0;
        }

        protected override PornVideo ExtractVideo(string content) {
            PornVideo video = new PornVideo { Website = PornWebsite.Pornhub };
            FillVideoFromHeaderContent(content, ref video);
            FillVideoFromBodyContent(content, ref video);
            FillVideo_Categories(content, ref video);
            FillVideo_Tags(content, ref video);
            FillVideo_Actors(content, ref video);
            FillVideo_RelatedVideos(content, ref video);
            return video;
        }

        private static void FillVideoFromHeaderContent(string content, ref PornVideo video) {
            const string pattern = "<meta property=\"og:url\" content=\"([^?]*[?]viewkey=([^\"]*))\" />[\\s\\S]*?"
                                   + "<meta property=\"og:title\" content=\"([^\"]*)\" />[\\s\\S]*?"
                                   + "<meta property=\"og:image\" content=\"([^\"]*)\" />[\\s\\S]*?"
                                   + "phOrientationSegment.*?= \"([^\"]*)[\\s\\S]*?" + "ga[(]'set', 'dimension14', '([^']*)";
            Match match = Regex.Match(content, pattern);
            if (match.Success) {
                Enum.TryParse(match.Groups[5].Value, true, out PornSexOrientation sexOrientation);
                video.SexOrientation = sexOrientation;
                video.Id = match.Groups[2].Value;
                video.Title = HtmlDecode(match.Groups[3].Value);
                video.ThumbnailUrl = match.Groups[4].Value;
                video.PageUrl = match.Groups[1].Value;
                video.Date = DateTime.ParseExact(match.Groups[6].Value, "yyyyMMdd", CultureInfo.InvariantCulture);
            }
        }

        private static void FillVideoFromBodyContent(string content, ref PornVideo video) {
            const string pattern = "<img src=\"([^?]*)[?][^\"]*\" class=\"videoElementPoster\"[\\s\\S]*?"
                                   + "<div class=\"ratingInfo\">\\s.*?" + "class=\"count\">([^<]*)[\\s\\S]*?"
                                   + "<span class=\"votesUp\" data-rating=\"([^\"]*)[\\s\\S]*?"
                                   + "<span class=\"votesDown\" data-rating=\"([^\"]*)[\\s\\S]*?"
                                   + "<div class=\"userInfo\">[\\s\\S]*?href=\"([^\"]*).*?>([^<]*)";
            Match match = Regex.Match(content, pattern);
            if (match.Success) {
                video.SmallThumbnailUrl = match.Groups[1].Value;
                video.NbViews = ConvertToInt(match.Groups[2].Value);
                video.NbLikes = ConvertToInt(match.Groups[3].Value);
                video.NbDislikes = ConvertToInt(match.Groups[4].Value);
                video.Channel = new PornIdName {
                    Id = match.Groups[5].Value,
                    Name = HtmlDecode(match.Groups[6].Value)
                };
            }
        }

        private static void FillVideo_Categories(string content, ref PornVideo video) {
            int startIndex = content.IndexOf("<div class=\"categoriesWrapper\">", StringComparison.Ordinal);
            int endIndex = content.IndexOf("</div>", startIndex, StringComparison.Ordinal);
            content = content.Substring(startIndex, endIndex - startIndex);
            MatchCollection matches = Regex.Matches(content, "<a class=\"item\" href=\"([^\"]*)\"[^>]*>([^<]*)");
            video.Categories = matches.Cast<Match>()
                                      .Select(m => new PornIdName {
                                                  Id = m.Groups[1].Value,
                                                  Name = HtmlDecode(m.Groups[2].Value)
                                              })
                                      .ToList();
        }

        private static void FillVideo_Tags(string content, ref PornVideo video) {
            int startIndex = content.IndexOf("<div class=\"tagsWrapper\">", StringComparison.Ordinal);
            if (startIndex < 0)
                return;
            int endIndex = content.IndexOf("</div>", startIndex, StringComparison.Ordinal);
            content = content.Substring(startIndex, endIndex - startIndex);
            MatchCollection matches = Regex.Matches(content, "<a class=\"item\" href=\"([^\"]*)\"[^>]*>([^<]*)");
            video.Tags = matches.Cast<Match>()
                                .Select(m => new PornIdName {
                                            Id = m.Groups[1].Value,
                                            Name = ToTitleCase(HtmlDecode(m.Groups[2].Value))
                                        })
                                .ToList();
        }

        private static void FillVideo_Actors(string content, ref PornVideo video) {
            int startIndex = content.IndexOf("<div class=\"pornstarsWrapper ", StringComparison.Ordinal);
            int endIndex = content.IndexOf("<div id=\"deletePornstarResult\"", startIndex, StringComparison.Ordinal);
            content = content.Substring(startIndex, endIndex - startIndex);
            const string pattern = "data-mxptype=\"Pornstar\"\\s*data-mxptext=\"([^\"]*)\"\\s*.*\\s.*\\s*href=\"([^\"]*)";
            MatchCollection matches = Regex.Matches(content, pattern);
            video.Actors = matches.Cast<Match>()
                                  .Select(m => new PornIdName {
                                              Id = m.Groups[2].Value,
                                              Name = HtmlDecode(m.Groups[1].Value)
                                          })
                                  .ToList();
        }

        private static void FillVideo_RelatedVideos(string content, ref PornVideo video) {
            video.RelatedVideos = new List<PornVideoThumb>();
            FillVideo_RelatedVideos_Right(content, ref video);
            FillVideo_RelatedVideos_Center(content, ref video);
        }

        private static void FillVideo_RelatedVideos_Right(string content, ref PornVideo video) {
            int startIndex = content.IndexOf("<ul id=\"recommendedVideos\"", StringComparison.Ordinal);
            int endIndex = content.IndexOf("</ul>", startIndex, StringComparison.Ordinal);
            string contentItems = content.Substring(startIndex, endIndex - startIndex);
            PornWebsite website = video.Website;
            PornSexOrientation sexOrientation = video.SexOrientation;
            video.RelatedVideos.AddRange(Regex.Matches(contentItems, RegExVideoThumb)
                                              .Cast<Match>()
                                              // Channel Id may be empty if the video is not available in your country
                                              .Where(m => m.Groups[5].Value != "")
                                              .Select(m => new PornVideoThumb {
                                                          Website = website,
                                                          SexOrientation = sexOrientation,
                                                          Id = m.Groups[1].Value,
                                                          Title = HtmlDecode(m.Groups[3].Value),
                                                          Channel = new PornIdName {
                                                              Id = m.Groups[5].Value,
                                                              Name = HtmlDecode(m.Groups[6].Value)
                                                          },
                                                          ThumbnailUrl = m.Groups[4].Value,
                                                          PageUrl = $"https://www.pornhub.com{m.Groups[2].Value}"
                                                      }));
        }

        private static void FillVideo_RelatedVideos_Center(string content, ref PornVideo video) {
            int startIndex = content.IndexOf("<ul id=\"relatedVideosCenter\"", StringComparison.Ordinal);
            int endIndex = content.IndexOf("</ul>", startIndex, StringComparison.Ordinal);
            string contentItems = content.Substring(startIndex, endIndex - startIndex);
            PornWebsite website = video.Website;
            PornSexOrientation sexOrientation = video.SexOrientation;
            video.RelatedVideos.AddRange(Regex.Matches(contentItems, RegExVideoThumb)
                                              .Cast<Match>()
                                              // Channel Id may be empty if the video is not available in your country
                                              .Where(m => m.Groups[5].Value != "")
                                              .Where(m => m.Groups[2].Value != "javascript:void(0)")
                                              .Select(m => new PornVideoThumb {
                                                          Website = website,
                                                          SexOrientation = sexOrientation,
                                                          Id = m.Groups[1].Value,
                                                          Title = HtmlDecode(m.Groups[3].Value),
                                                          Channel = new PornIdName {
                                                              Id = m.Groups[5].Value,
                                                              Name = HtmlDecode(m.Groups[6].Value)
                                                          },
                                                          ThumbnailUrl = m.Groups[4].Value,
                                                          PageUrl = $"https://www.pornhub.com{m.Groups[2].Value}"
                                                      }));
        }
    }
}
