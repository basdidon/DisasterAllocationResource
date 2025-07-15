using DisasterAllocationResource.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterAllocationResource.Application.Features.AffectedAreas.DTOs
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

    public class AffectedAreaRequiredResourceDto
    {
        public string ResourceId { get; set; } = string.Empty;
        public int RequiredAmount { get; set; }
        public static AffectedAreaRequiredResourceDto Map(AffectedAreaRequiredResource requiredResource) => new()
        {
            ResourceId = requiredResource.ResourceType.ResourceId,
            RequiredAmount = requiredResource.RequiredAmount
        };
    }
}
