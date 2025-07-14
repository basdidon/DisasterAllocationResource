namespace DisasterAllocationResource.Core.Models
{
    public class ResourceTruckAvailableResource
    {
        public int AvailableAmount { get; set; }

        // navigate props
        public ResourceTruck Truck { get; set; } = null!;
        public ResourceType ResourceType { get; set; } = null!;
    }
}
