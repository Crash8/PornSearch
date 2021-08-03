using System.Collections.Generic;
using System.Threading.Tasks;

namespace PornSearch
{
    public interface IPornSearchSource
    {
        List<PornSexOrientation> GetSexOrientations();
        Task<List<PornItemThumb>> SearchAsync(PornSearchFilter searchFilter);
    }
}
