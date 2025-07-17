namespace DisasterAllocationResource.Api.Models
{
    public class AffectedAreaRequiredResource
    {
        public string AreaId { get; set; } = string.Empty;
        public AffectedArea AffectedArea { get; set; } = null!;

        public string ResourceId { get; set; } = string.Empty;
        public Resource ResourceType { get; set; } = null!;
        
        public int RequiredAmount { get; set; }
    }
}
