namespace DisasterAllocationResource.Api.Models
{
    public class ResourceTruckAvailableResource
    {
        public string TruckId { get; set; } = string.Empty;
        public ResourceTruck Truck { get; set; } = null!;

        public string ResourceId { get; set; } = string.Empty;
        public Resource ResourceType { get; set; } = null!;

        public int AvailableAmount { get; set; }
    }
}
