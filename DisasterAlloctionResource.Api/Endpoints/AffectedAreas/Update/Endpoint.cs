using DisasterAllocationResource.Api.Persistence;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace DisasterAllocationResource.Api.Endpoints.AffectedAreas.Update
{
    public class Endpoint(ApplicationDbContext context):Endpoint<Request>
    {
        public override void Configure()
        {
            Put("/areas/{AreaId}");
        }

        public override async Task HandleAsync(Request req, CancellationToken ct)
        {
            int changes = context.AffectedAreas.Where(x => x.AreaId == req.AreaId)
                .ExecuteUpdate(x => x
                    .SetProperty(a => a.UrgencyLevel, req.UrgencyLevel)
                    .SetProperty(a => a.TimeConstraint, req.TimeConstraint));

            if(changes == 0)
            {
                await SendNotFoundAsync(ct);
            }
            else
            {
                await SendNoContentAsync(ct);
            }
        }
    }
}
