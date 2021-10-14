using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PornSearch
{
    public class PornSearch
    {
        private readonly ConcurrentDictionary<PornWebsite, IPornSearchWebsite> _searchWebsites;

        public PornSearch() {
            _searchWebsites = new ConcurrentDictionary<PornWebsite, IPornSearchWebsite>();
        }

        public List<PornSource> GetSources() {
            return (from PornWebsite website in Enum.GetValues(typeof(PornWebsite))
                    let searchWebsite = GetSearchWebsite(website)
                    select new PornSource {
                        Website = website,
                        SexOrientations = searchWebsite.GetSexOrientations()
                    }).ToList();
        }

        private IPornSearchWebsite GetSearchWebsite(PornWebsite website) {
            return _searchWebsites.GetOrAdd(website, _ => {
                switch (website) {
                    case PornWebsite.Pornhub: return new PornhubSearchWebsite();
                    case PornWebsite.XVideos: return new XVideosSearchWebsite();
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
                case UnicodeCategory.UppercaseLetter: return true;
                default: return false;
            }
        }
    }
}
