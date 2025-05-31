using PornSearch.Extensions;

namespace PornSearch
{
    internal class XVideosVideoActorThumbParser : IPornVideoThumbParser
    {
        private readonly XVideosJsonSearchActorVideos _root;

        public XVideosVideoActorThumbParser(XVideosJsonSearchActorVideos root) {
            _root = root;
        }

        public bool IsAvailable() {
            return true;
        }

        public PornWebsite Website() {
            return PornWebsite.XVideos;
        }

        public string Id() {
            return _root.eid;
        }

        public string Title() {
            return _root.tf.ToHtmlDecode() ?? "";
        }

        public PornIdName Channel() {
            return new PornIdName {
                Id = _root.pu ?? "",
                Name = _root.pn
            };
        }

        public string ThumbnailUrl() {
            return _root.ip;
        }

        public string PageUrl() {
            return $"https://www.xvideos.com/video.{_root.eid}/_";
        }
    }
}
