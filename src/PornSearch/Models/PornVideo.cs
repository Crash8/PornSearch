using System;
using System.Collections.Generic;

namespace PornSearch
{
    public class PornVideo
    {
        public PornWebsite Website { get; set; }
        public PornSexOrientation SexOrientation { get; set; }
        public bool? IsFreePremium { get; set; }
        public string Id { get; set; }
        public string Title { get; set; }
        public PornIdName Channel { get; set; }
        public string ThumbnailUrl { get; set; }
        public string SmallThumbnailUrl { get; set; }
        public string PageUrl { get; set; }
        public string VideoEmbedUrl { get; set; }
        public TimeSpan Duration { get; set; }
        public List<PornIdName> Categories { get; set; }
        public List<PornIdName> Tags { get; set; }
        public List<PornIdName> Actors { get; set; }
        public int NbViews { get; set; }
        public int NbLikes { get; set; }
        public int NbDislikes { get; set; }
        public DateTime? Date { get; set; }
        public List<PornVideoThumb> RelatedVideos { get; set; }
    }
}
