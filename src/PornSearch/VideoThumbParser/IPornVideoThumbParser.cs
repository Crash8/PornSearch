namespace PornSearch
{
    internal interface IPornVideoThumbParser
    {
        bool IsAvailable();
        PornWebsite Website();
        bool? IsFreePremium();
        string Id();
        string Title();
        PornIdName Channel();
        string ThumbnailUrl();
        string PageUrl();
    }
}
