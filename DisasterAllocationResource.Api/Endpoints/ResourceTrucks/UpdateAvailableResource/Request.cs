namespace DisasterAllocationResource.Api.Endpoints.ResourceTrucks.UpdateAvailableResource
{
    public class Request
    {
        public string TruckId { get; set; } = string.Empty;
        public string ResourceId { get; set; } = string.Empty;
        public int AvailableAmount { get; set; }
    }
}
