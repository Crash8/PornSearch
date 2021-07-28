using System.Collections.Generic;

namespace PornSearch
{
    public class XVideosSearchSource : IPornSearchSource
    {
        public List<PornSexOrientation> GetSexOrientations() {
            return new List<PornSexOrientation> {
                PornSexOrientation.Straight,
                PornSexOrientation.Gay,
                PornSexOrientation.Trans
            };
        }
    }
}
