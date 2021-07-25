using System;

namespace PornSearch
{
    public class PornSearch
    {
        public IPornSearchSource GetSource(string source) {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            switch (source.ToLower()) {
                case PornSource.Pornhub: return new PornhubSearchSource();
                case PornSource.XVideo:  return new XVideoSearchSource();
                default:                 throw new ArgumentException($"Value '{source}' not found", nameof(source));
            }
        }
    }
}
