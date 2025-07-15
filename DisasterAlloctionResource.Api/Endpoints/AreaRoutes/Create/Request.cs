namespace DisasterAllocationResource.Api.Endpoints.AreaRoutes.Create
{
    public class Request
    {
        public string FromAreaId { get; set; } = string.Empty;
        public string ToAreaId { get; set; } = string.Empty;
        public int TravelTime { get; set; }

    }
}
