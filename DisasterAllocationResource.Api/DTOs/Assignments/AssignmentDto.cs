namespace DisasterAllocationResource.Api.DTOs.Assignments
{
    public class AssignmentDto
    {
        public string AreaId { get; set; } = string.Empty;
        public string TruckId { get; set; } = string.Empty;
        public int TravelTime { get; set; }
        public IEnumerable<DeliveredResourcesDto> DeliveredResources { get; set; } = [];
    }
}
