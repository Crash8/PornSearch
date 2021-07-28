using System.Collections.Generic;

namespace PornSearch
{
    public class PornhubSearchSource : IPornSearchSource
    {
        public List<PornSexOrientation> GetSexOrientations() {
            return new List<PornSexOrientation> {
                PornSexOrientation.Straight,
                PornSexOrientation.Gay
            };
        }
    }
}
