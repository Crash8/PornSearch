using System.Collections.Generic;
using System.Threading.Tasks;

namespace PornSearch
{
    internal interface IPornSearchWebsite
    {
        List<PornSexOrientation> GetSexOrientations();
        Task<List<PornVideoThumb>> SearchAsync(PornSearchFilter searchFilter, bool useWebProxy);
        Task<List<PornVideoChannelThumb>> SearchChannelAsync(PornSearchChannelFilter searchChannelFilter, bool useWebProxy);
        Task<List<PornVideoActorThumb>> SearchActorAsync(PornSearchActorFilter searchActorFilter, bool useWebProxy);
        PornSourceVideo GetSourceVideo(string url);
        Task<PornVideo> GetVideoByIdAsync(string videoId, bool useWebProxy);
        Task<bool> CheckIfCanVideoEmbedInIframeAsync(PornVideo video, bool useWebProxy);
        string MakeUrlVideo(string videoId);
    }
}
