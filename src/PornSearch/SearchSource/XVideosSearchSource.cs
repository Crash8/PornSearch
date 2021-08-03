using System.Collections.Generic;
using System.Threading.Tasks;

namespace PornSearch
{
    public class XVideosSearchSource : IPornSearchSource
    {
        public List<PornSexOrientation> GetSexOrientations() {
            return new List<PornSexOrientation> {
                PornSexOrientation.Straight,
                PornSexOrientation.Gay,
                PornSexOrientation.Trans
            };
        }

        public Task<List<PornItemThumb>> SearchAsync(PornSearchFilter searchFilter) {
            throw new System.NotImplementedException();
        }
    }
}
