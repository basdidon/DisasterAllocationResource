namespace DisasterAllocationResource.Core.Models
{
    public class AffectedAreaRequiredResource
    {
        public string AreaId { get; set; } = string.Empty;
        public string ResourceId { get; set; } = string.Empty;
        public int RequiredAmount { get; set; }

        // navigate props
        public AffectedArea AffectedArea { get; set; } = null!;
        public ResourceType ResourceType { get; set; } = null!;
    }
}
