namespace DisasterAllocationResource.Core.Models
{
    public class AreaRoute
    {
        public int TravelTime { get; set; }

        // navigation properties
        public AffectedArea FromArea { get; set; } = null!;
        public AffectedArea ToArea { get; set; } = null!;
    }
}
