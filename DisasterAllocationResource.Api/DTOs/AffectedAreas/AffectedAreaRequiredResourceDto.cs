using DisasterAllocationResource.Api.Models;

namespace DisasterAllocationResource.Api.DTOs.AffectedAreas
{
    public class AffectedAreaRequiredResourceDto
    {
        public string ResourceId { get; set; } = string.Empty;
        public int RequiredAmount { get; set; }
        public static AffectedAreaRequiredResourceDto Map(AffectedAreaRequiredResource requiredResource) => new()
        {
            ResourceId = requiredResource.ResourceId,
            RequiredAmount = requiredResource.RequiredAmount
        };
    }
}
