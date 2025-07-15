namespace DisasterAllocationResource.Api.Endpoints.AffectedAreas.RemoveRequiredResource
{
    public class Request
    {
        public string AreaId { get; set; } = string.Empty;
        public string ResourceId { get; set; } = string.Empty;
    }
}