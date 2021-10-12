using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
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
            IPornSearchWebsite searchWebsite = GetSearchWebsite(searchFilter.Website);
            return await searchWebsite.SearchAsync(searchFilter);
        }
    }
}
