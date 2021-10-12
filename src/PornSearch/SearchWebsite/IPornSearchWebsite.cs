using System.Collections.Generic;
using System.Threading.Tasks;

namespace PornSearch
{
    internal interface IPornSearchWebsite
    {
        List<PornSexOrientation> GetSexOrientations();
        Task<List<PornVideoThumb>> SearchAsync(PornSearchFilter searchFilter);
    }
}
