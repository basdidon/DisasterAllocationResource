namespace DisasterAllocationResource.Api.Models
{
    public class AffectedArea
    {
        public string AreaId { get; set; } = string.Empty;
        public int UrgencyLevel { get; set; } // 1 - 5
        public int TimeConstraint { get; set; }  // Hours within which resources must be delivered.

        public ICollection<AffectedAreaRequiredResource> RequiredResources { get; set; } = [];
        public ICollection<AffectedArea> MappedArea { get; set; } = [];

    }
}
