using System.Collections.Generic;
using System.Threading.Tasks;

namespace PornSearch
{
    internal interface IPornSearchWebsite
    {
        List<PornSexOrientation> GetSexOrientations();
        Task<List<PornVideoThumb>> SearchAsync(PornSearchFilter searchFilter);
        PornSourceVideo GetSourceVideo(string url);
        Task<PornVideo> GetVideoByIdAsync(string videoId);
        Task<bool> CheckIfCanVideoEmbedInIframeAsync(PornVideo video);
    }
}
