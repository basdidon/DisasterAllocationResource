using DisasterAllocationResource.Api.Models;
using DisasterAllocationResource.Api.Persistence;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace DisasterAllocationResource.Api.Endpoints.ResourceTrucks.AddAvailableResource
{
    public class Endpoint(ApplicationDbContext context) : Endpoint<Request>
    {
        public override void Configure()
        {
            Post("/trucks/{TruckId}/available-resources");
        }

        public override async Task HandleAsync(Request req, CancellationToken ct)
        {
            var truck = await context.ResourceTrucks.FirstOrDefaultAsync(x => x.TruckId == req.TruckId, ct);
            if(truck == null)
            {
                AddError(x=>x.TruckId,$"Resource truck with ID : '{req.TruckId}' was not found.");
                await SendErrorsAsync(404,ct);
                return;
            }

            var resource = await context.Resources.FirstOrDefaultAsync(x => x.ResourceId == req.ResourceId, ct);
            if (resource == null)
            {
                AddError(x => x.ResourceId, $"Resource with ID : '{req.ResourceId}' was not found.");
                await SendErrorsAsync(404, ct);
                return;
            }

            ResourceTruckAvailableResource availableResource = new()
            {
                ResourceType = resource,
                AvailableAmount = req.AvailableAmount
            };

            truck.AvailableResources.Add(availableResource);
            await context.SaveChangesAsync(ct);
            await SendOkAsync(ct);
        }
    }
}
