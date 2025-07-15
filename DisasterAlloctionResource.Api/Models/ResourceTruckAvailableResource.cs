namespace DisasterAllocationResource.Api.Models
{
    public class ResourceTruckAvailableResource
    {
        public int AvailableAmount { get; set; }

        // navigate props
        public ResourceTruck Truck { get; set; } = null!;
        public Resource ResourceType { get; set; } = null!;
    }
}
