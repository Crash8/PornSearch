namespace PornSearch
{
    public class PornSearchFilter
    {
        public PornWebsite Website { get; set; } = PornWebsite.Pornhub;
        public PornSexOrientation SexOrientation { get; set; } = PornSexOrientation.Straight;
        public int Page { get; set; } = 1;
        public string Filter { get; set; }
    }
}
