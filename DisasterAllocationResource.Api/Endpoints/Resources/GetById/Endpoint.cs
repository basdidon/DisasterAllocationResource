using DisasterAllocationResource.Api.Models;
using DisasterAllocationResource.Api.Persistence;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace DisasterAllocationResource.Api.Endpoints.Resources.GetById
{
    public class Endpoint(ApplicationDbContext context) : Endpoint<Request,Resource>
    {
        public override void Configure()
        {
            Get("/resources/{ResourceId}");
        }

        public override async Task HandleAsync(Request req, CancellationToken ct)
        {
            var resource = await context.Resources.AsNoTracking()
                .FirstOrDefaultAsync(x => x.ResourceId == req.ResourceId, ct);

            if (resource == null)
            {
                AddError(x=>x.ResourceId, $"Resource with ID : '{req.ResourceId}' was not found.");
                await SendErrorsAsync(404,ct);
            }
            else
            {
                await SendOkAsync(resource, ct);
            }
        }
    }
}
