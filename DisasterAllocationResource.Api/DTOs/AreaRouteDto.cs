using DisasterAllocationResource.Api.Models;

namespace DisasterAllocationResource.Api.DTOs
{
    public class AreaRouteDto
    {
        public string FromAreaId { get; set; } = string.Empty;
        public string ToAreaId { get; set; } = string.Empty;

        public int TravelTime { get; set; }

        public static AreaRouteDto Map(AreaRoute route) => new()
        {
            FromAreaId = route.FromAreaId,
            ToAreaId = route.ToAreaId,
            TravelTime = route.TravelTime,
        };
    }
}
