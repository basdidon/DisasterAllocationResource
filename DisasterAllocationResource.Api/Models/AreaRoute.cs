namespace DisasterAllocationResource.Api.Models
{
    public class AreaRoute
    {
        public string FromAreaId { get; set; } = string.Empty;
        public AffectedArea FromArea { get; set; } = null!;

        public string ToAreaId { get; set; } = string.Empty;
        public AffectedArea ToArea { get; set; } = null!;
        
        public int TravelTime { get; set; }
    }
}
