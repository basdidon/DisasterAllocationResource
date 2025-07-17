using DisasterAllocationResource.Api.DTOs.AffectedAreas;
using DisasterAllocationResource.Api.Models;

namespace DisasterAllocationResource.Api.DTOs.AffectedAreas.v2
{
    public class AffectedAreaQueryDtoV2
    {
        public string AreaId { get; set; } = string.Empty;
        public int UrgencyLevel { get; set; }
        public int TimeConstraint { get; set; }

        public IEnumerable<AffectedAreaRequiredResourceDto> RequiredResources { get; set; } = [];
        public IEnumerable<AffectedAreaRouteDto> MappedArea { get; set; } = [];

        public static AffectedAreaQueryDtoV2 Map(AffectedArea affectedArea)
        {
            var routesFromDto = affectedArea.RoutesFrom.Select(route => AffectedAreaRouteDto.MapByRoutesFrom(route));
            var routesToDto = affectedArea.RoutesTo.Select(route => AffectedAreaRouteDto.MapByRoutesTo(route));

            return new AffectedAreaQueryDtoV2()
            {
                AreaId = affectedArea.AreaId,
                UrgencyLevel = affectedArea.UrgencyLevel,
                TimeConstraint = affectedArea.TimeConstraint,
                RequiredResources = affectedArea.RequiredResources.Select(x => AffectedAreaRequiredResourceDto.Map(x)),
                MappedArea = [.. routesFromDto, .. routesToDto]
            };
        }
    }
}
