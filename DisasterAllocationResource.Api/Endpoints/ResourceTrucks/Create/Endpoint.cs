using DisasterAllocationResource.Api.Models;
using DisasterAllocationResource.Api.Persistence;
using FastEndpoints;

namespace DisasterAllocationResource.Api.Endpoints.ResourceTrucks.Create
{
    public class Endpoint(ApplicationDbContext context) : Endpoint<Request>
    {
        override public void Configure()
        {
            Post("/trucks");
        }

        public override async Task HandleAsync(Request req, CancellationToken ct)
        {
            var truck = new ResourceTruck() { TruckId = req.TruckId };
            await context.ResourceTrucks.AddAsync(truck, ct);
            await context.SaveChangesAsync(ct);
            await SendCreatedAtAsync<GetById.Endpoint>(
                new { truck.TruckId }, 
                truck, 
                cancellation: ct);
        }
    }
}
