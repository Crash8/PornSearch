using System;

namespace PornSearch
{
    public class PornSearch
    {
        public IPornSearchSource GetSource(PornSource source) {
            switch (source) {
                case PornSource.Pornhub: return new PornhubSearchSource();
                case PornSource.XVideos: return new XVideosSearchSource();
                default:                 throw new NotImplementedException();
            }
        }
    }
}
