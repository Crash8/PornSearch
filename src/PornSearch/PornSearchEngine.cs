using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PornSearch
{
    public class PornSearchEngine : IPornSearch
    {
        private readonly ConcurrentDictionary<PornWebsite, IPornSearchWebsite> _searchWebsites;

        public PornSearchEngine() {
            _searchWebsites = new ConcurrentDictionary<PornWebsite, IPornSearchWebsite>();
        }

        public List<PornSource> GetSources() {
            return (from PornWebsite website in GetAllWebsites()
                    let searchWebsite = GetSearchWebsite(website)
                    select new PornSource {
                        Website = website,
                        SexOrientations = searchWebsite.GetSexOrientations()
                    }).ToList();
        }

        private static Array GetAllWebsites() {
            return Enum.GetValues(typeof(PornWebsite));
        }

        private IPornSearchWebsite GetSearchWebsite(PornWebsite website) {
            return _searchWebsites.GetOrAdd(website, _ => {
                switch (website) {
                    case PornWebsite.Pornhub: return new PornhubSearchWebsite();
                    case PornWebsite.XVideos: return new XVideosSearchWebsite();
                    case PornWebsite.YouPorn: return new YouPornSearchWebsite();
                    default:                  throw new NotImplementedException();
                }
            });
        }

        public async Task<List<PornVideoThumb>> SearchAsync(PornSearchFilter searchFilter) {
            if (searchFilter == null)
                throw new ArgumentNullException(nameof(searchFilter));
            CleanSearchFilter(searchFilter);
            IPornSearchWebsite searchWebsite = GetSearchWebsite(searchFilter.Website);
            return await searchWebsite.SearchAsync(searchFilter);
        }

        private static void CleanSearchFilter(PornSearchFilter searchFilter) {
            searchFilter.Filter = CleanFilterFromSearchFilter(searchFilter.Filter);
        }

        private static string CleanFilterFromSearchFilter(string filter) {
            if (string.IsNullOrWhiteSpace(filter))
                return filter;
            string normalizedString = filter.Normalize(NormalizationForm.FormD);
            StringBuilder stringBuilder = new StringBuilder();
            foreach (char c in normalizedString.Where(IsCharForSearchFilter))
                stringBuilder.Append(c);
            return stringBuilder.ToString().Normalize(NormalizationForm.FormC).ToLower();
        }

        private static bool IsCharForSearchFilter(char character) {
            switch (char.GetUnicodeCategory(character)) {
                case UnicodeCategory.ConnectorPunctuation:
                case UnicodeCategory.DecimalDigitNumber:
                case UnicodeCategory.LowercaseLetter:
                case UnicodeCategory.SpaceSeparator:
                case UnicodeCategory.UppercaseLetter:
                case UnicodeCategory.OtherLetter: return true;
                default: return false;
            }
        }

        public async Task<PornVideo> GetVideoAsync(string url) {
            PornSourceVideo sourceVideo = GetSourceVideo(url);
            if (sourceVideo != null) {
                IPornSearchWebsite searchWebsite = GetSearchWebsite(sourceVideo.Website);
                return await searchWebsite.GetVideoByIdAsync(sourceVideo.Id);
            }
            return null;
        }

        public async Task<PornVideo> GetVideoAsync(PornSourceVideo sourceVideo) {
            if (sourceVideo == null)
                throw new ArgumentNullException(nameof(sourceVideo));
            IPornSearchWebsite searchWebsite = GetSearchWebsite(sourceVideo.Website);
            return await searchWebsite.GetVideoByIdAsync(sourceVideo.Id);
        }

        public PornSourceVideo GetSourceVideo(string url) {
            if (url == null)
                throw new ArgumentNullException(nameof(url));
            url = url.ToLower();
            return (from PornWebsite website in GetAllWebsites()
                    select GetSearchWebsite(website) into searchWebsite
                    select searchWebsite.GetSourceVideo(url)).FirstOrDefault(sourceVideo => sourceVideo != null);
        }

        public async Task<bool> CheckIfCanVideoEmbedInIframeAsync(PornVideo video) {
            if (video == null)
                throw new ArgumentNullException(nameof(video));
            IPornSearchWebsite searchWebsite = GetSearchWebsite(video.Website);
            return await searchWebsite.CheckIfCanVideoEmbedInIframeAsync(video);
        }
    }
}
