namespace DisasterAllocationResource.Api.Endpoints.AffectedAreas.UpdateRequiredResource
{
    public record Request
    {
        public string AreaId { get; set; } = string.Empty;
        public string ResourceId { get; set; } = string.Empty;
        public int RequiredAmount { get; set; }
    }
}
