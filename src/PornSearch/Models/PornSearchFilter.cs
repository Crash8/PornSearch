namespace PornSearch
{
    public class PornSearchFilter
    {
        public PornSexOrientation SexOrientation { get; set; } = PornSexOrientation.Straight;
        public int Page { get; set; } = 1;
        public string Filter { get; set; }
    }
}
