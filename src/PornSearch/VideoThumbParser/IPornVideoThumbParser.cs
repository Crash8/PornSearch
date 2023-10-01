namespace PornSearch
{
    internal interface IPornVideoThumbParser
    {
        bool IsAvailable();
        PornWebsite Website();
        string Id();
        string Title();
        PornIdName Channel();
        string ThumbnailUrl();
        string PageUrl();
    }
}
