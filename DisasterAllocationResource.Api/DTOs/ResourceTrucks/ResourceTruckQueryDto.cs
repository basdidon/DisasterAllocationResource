using DisasterAllocationResource.Api.Models;

namespace DisasterAllocationResource.Api.DTOs.ResourceTrucks
{
    public class ResourceTruckQueryDto
    {
        public string TruckId { get; set; } = string.Empty;
        public IEnumerable<ResourceTruckAvailableResourceDto> AvailableResources { get; set; } = [];
        public IEnumerable<ResourceTruckAreaRouteDto> AreaRoutes { get; set; } = [];

        public static ResourceTruckQueryDto Map(ResourceTruck truck) => new()
        {
            TruckId = truck.TruckId,
            AvailableResources = truck.AvailableResources.Select(x => new ResourceTruckAvailableResourceDto
            {
                ResourceId = x.ResourceId,
                AvailableAmount = x.AvailableAmount
            }),
            AreaRoutes = truck.Routes.Select(x => new ResourceTruckAreaRouteDto
            {
                AreaId = x.AreaId,
                TravelTime = x.TravelTime
            })
        };
    }
}
