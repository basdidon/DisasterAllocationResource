using FastEndpoints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterAllocationResource.Application.Features.AffectedAreas.Queries
{
    public record ListAffectedAreasQuery():ICommand;

    public class ListAffectedAreasQueryHandler : ICommandHandler<ListAffectedAreasQuery>
    {
        public Task ExecuteAsync(ListAffectedAreasQuery command, CancellationToken ct)
        {
            throw new NotImplementedException();
        }
    }
}
