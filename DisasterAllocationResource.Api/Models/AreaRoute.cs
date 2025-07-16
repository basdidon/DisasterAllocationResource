namespace DisasterAllocationResource.Api.Models
{
    public class AreaRoute
    {
        public string FromAreaId { get; set; } = string.Empty;
        public string ToAreaId { get; set; } = string.Empty;
        public int TravelTime { get; set; }

        // navigation properties
        public AffectedArea FromArea { get; set; } = null!;
        public AffectedArea ToArea { get; set; } = null!;
    }
}
