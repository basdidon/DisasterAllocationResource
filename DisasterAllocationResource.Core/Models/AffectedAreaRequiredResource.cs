namespace DisasterAllocationResource.Core.Models
{
    public class AffectedAreaRequiredResource
    {
        public int RequiredAmount { get; set; }

        // navigate props
        public AffectedArea AffectedArea { get; set; } = null!;
        public ResourceType ResourceType { get; set; } = null!;
    }
}
