namespace DisasterAllocationResource.Api.Endpoints.AffectedAreas.Create
{
    public class Request
    {
        public string AreaId { get; set; } = string.Empty;
        public int UrgencyLevel { get; set; }
        public int TimeConstraint { get; set; }
        public RequiredResourceDto[] RequiredResources { get; set; } = [];
    }

    public class RequiredResourceDto
    {
        public string ResourceId { get; set; } = string.Empty;
        public int RequiredAmount { get; set; } 
    }
}
