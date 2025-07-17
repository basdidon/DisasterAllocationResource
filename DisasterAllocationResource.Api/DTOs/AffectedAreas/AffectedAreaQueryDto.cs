using DisasterAllocationResource.Api.Models;

namespace DisasterAllocationResource.Api.DTOs.AffectedAreas
{
    public class AffectedAreaQueryDto
    {
        public string AreaId { get; set; } = string.Empty;
        public int UrgencyLevel { get; set; }
        public int TimeConstraint { get; set; }

        public IEnumerable<AffectedAreaRequiredResourceDto> RequiredResources { get; set; } = [];

        public static AffectedAreaQueryDto Map(AffectedArea affectedArea) => new()
        {
            AreaId = affectedArea.AreaId,
            UrgencyLevel = affectedArea.UrgencyLevel,
            TimeConstraint = affectedArea.TimeConstraint,
            RequiredResources = affectedArea.RequiredResources.Select(x => AffectedAreaRequiredResourceDto.Map(x))
        };
    }
}
