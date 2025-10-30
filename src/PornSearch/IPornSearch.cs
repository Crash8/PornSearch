using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace PornSearch
{
    public interface IPornSearch
    {
        void SetHttpClientWebProxy(IWebProxy webProxy);
        List<PornSource> GetSources();
        Task<List<PornVideoThumb>> SearchAsync(PornSearchFilter searchFilter, bool useWebProxy = false);
        Task<List<PornVideoChannelThumb>> SearchChannelAsync(PornSearchChannelFilter searchChannelFilter, bool useWebProxy = false);
        Task<List<PornVideoActorThumb>> SearchActorAsync(PornSearchActorFilter searchActorFilter, bool useWebProxy = false);
        Task<PornVideo> GetVideoAsync(string url, bool useWebProxy = false);
        Task<PornVideo> GetVideoAsync(PornSourceVideo sourceVideo, bool useWebProxy = false);
        PornSourceVideo GetSourceVideo(string url);
        Task<bool> CheckIfCanVideoEmbedInIframeAsync(PornVideo video, bool useWebProxy = false);
        string GetPageUrl(PornSourceVideo sourceVideo);
    }
}
