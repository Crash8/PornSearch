using System.Collections.Generic;
using System.Threading.Tasks;

namespace PornSearch
{
    public interface IPornSearch
    {
        List<PornSource> GetSources();
        Task<List<PornVideoThumb>> SearchAsync(PornSearchFilter searchFilter);
        Task<PornVideo> GetVideoAsync(string url);
        Task<PornVideo> GetVideoAsync(PornSourceVideo sourceVideo);
        PornSourceVideo GetSourceVideo(string url);
        Task<bool> CheckIfCanVideoEmbedInIframeAsync(PornVideo video);
    }
}
