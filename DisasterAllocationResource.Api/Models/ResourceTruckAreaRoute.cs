namespace DisasterAllocationResource.Api.Models
{
    public class ResourceTruckAreaRoute
    {
        public string TruckId { get; set; } = string.Empty;
        public ResourceTruck Truck { get; set; } = null!;

        public string AreaId { get; set; } = string.Empty;
        public AffectedArea Area { get; set; } = null!;

        public int TravelTime { get; set; }

    }
}
