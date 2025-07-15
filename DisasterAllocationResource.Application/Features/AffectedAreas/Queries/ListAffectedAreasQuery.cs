using DisasterAllocationResource.Application.Features.AffectedAreas.DTOs;
using DisasterAllocationResource.Application.Interfaces;
using FastEndpoints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterAllocationResource.Application.Features.AffectedAreas.Queries
{
    public record ListAffectedAreasQuery():ICommand<IEnumerable<AffectedAreaQueryDto>>;

    internal class ListAffectedAreasQueryHandler(IAffectedAreaRepository affectedAreaRepo) : ICommandHandler<ListAffectedAreasQuery, IEnumerable<AffectedAreaQueryDto>>
    {
        public async Task<IEnumerable<AffectedAreaQueryDto>> ExecuteAsync(ListAffectedAreasQuery command, CancellationToken ct)
        {
            var areas = await affectedAreaRepo.GetAllAsync(ct);
            return areas.Select(x => AffectedAreaQueryDto.Map(x));
        }
    }
}
