namespace DisasterAllocationResource.Api.Endpoints.ResourceTrucks.UpdateRoute
{
    public class Request
    {
        public string TruckId { get; set; } = string.Empty;
        public string AreaId { get; set; } = string.Empty;
        public int TravelTime { get; set; }
    }
}
