namespace DisasterAllocationResource.Core.Models
{
    public class ResourceTruckTravelTime
    {
        public int Hours { get; set; }

        public ResourceTruck Truck { get; set; } = null!;
        public AffectedArea Area { get; set; } = null!;
    }
}
