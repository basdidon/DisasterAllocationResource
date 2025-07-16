using DisasterAllocationResource.Api.Models;

namespace DisasterAllocationResource.Api.DTOs
{
    public class AffectedAreaRouteDto
    {
        public string AreaId { get; set; } = string.Empty;
        public int TravelTime { get; set; }

        public static AffectedAreaRouteDto Map(string areaId,AreaRoute route)
        {
            if(areaId == route.FromAreaId)
            {
                return new AffectedAreaRouteDto
                {
                    AreaId = route.ToAreaId,
                    TravelTime = route.TravelTime
                };
            }
            else if(areaId == route.ToAreaId)
            {
                return new AffectedAreaRouteDto
                {
                    AreaId = route.FromAreaId,
                    TravelTime = route.TravelTime
                };
            }
            else
            {
                throw new ArgumentException("AreaId does not match either FromAreaId or ToAreaId of the route.");
            }
        }

        public static AffectedAreaRouteDto MapByRoutesFrom(AreaRoute route)
        {
            return new AffectedAreaRouteDto
            {
                AreaId = route.FromAreaId,
                TravelTime = route.TravelTime
            };
        }

        public static AffectedAreaRouteDto MapByRoutesTo(AreaRoute route)
        {
            return new AffectedAreaRouteDto
            {
                AreaId = route.ToAreaId,
                TravelTime = route.TravelTime
            };
        }
    }
}
