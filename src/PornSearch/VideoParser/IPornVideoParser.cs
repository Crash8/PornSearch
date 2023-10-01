using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PornSearch
{
    internal interface IPornVideoParser
    {
        bool IsAvailable();
        PornWebsite Website();
        PornSexOrientation SexOrientation();
        string Id();
        string Title();
        PornIdName Channel();
        string ThumbnailUrl();
        string SmallThumbnailUrl();
        string PageUrl();
        string VideoEmbedUrl();
        TimeSpan Duration();
        List<PornIdName> Categories();
        List<PornIdName> Tags();
        List<PornIdName> Actors();
        int NbViews();
        int? NbLikes();
        int? NbDislikes();
        DateTime Date();
        List<PornVideoThumb> RelatedVideos();
    }
}
