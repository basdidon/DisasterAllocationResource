namespace DisasterAllocationResource.Core.Models
{
    public class ResourceTruck
    {
        public string TruckId { get; set; } = string.Empty;
        public ICollection<ResourceTruckAvailableResource> AvailableResources { get; set; } = [];
    }
}
