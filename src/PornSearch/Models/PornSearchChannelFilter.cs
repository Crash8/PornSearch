namespace PornSearch
{
    public class PornSearchChannelFilter
    {
        public PornWebsite Website { get; set; } = PornWebsite.Pornhub;
        public string ChannelId { get; set; }
        public int Page { get; set; } = 1;
    }
}
