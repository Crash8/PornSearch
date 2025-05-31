namespace PornSearch
{
    public class PornSearchActorFilter
    {
        public PornWebsite Website { get; set; } = PornWebsite.Pornhub;
        public string ActorId { get; set; }
        public int Page { get; set; } = 1;
    }
}
