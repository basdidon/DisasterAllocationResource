using DisasterAllocationResource.Api.Models;
using DisasterAllocationResource.Api.Persistence;
using FastEndpoints;

namespace DisasterAllocationResource.Api.Endpoints.ResourceTrucks.AddRoute
{

    public class Endpoint(ApplicationDbContext context) : Endpoint<Request>
    {
        public override void Configure()
        {
            Post("/trucks/{TruckId}/routes");
        }

        public override async Task HandleAsync(Request req, CancellationToken ct)
        {
            var truck = context.ResourceTrucks.FirstOrDefault(x => x.TruckId == req.TruckId);
            if (truck == null)
            {
                AddError(x => x.TruckId, $"Resource truck with ID : '{req.TruckId}' was not found.");
                await SendErrorsAsync(404, ct);
                return;
            }

            var area = context.AffectedAreas.FirstOrDefault(x => x.AreaId == req.AreaId);
            if (area == null)
            {
                AddError(x => x.AreaId, $"Affected area with ID : '{req.AreaId}' was not found.");
                await SendErrorsAsync(404, ct);
                return;
            }

            ResourceTruckAreaRoute route = new()
            {
                Area = area,
                TravelTime = req.TravelTime,
            };
            truck.Routes.Add(route);
            await context.SaveChangesAsync(ct);

            await SendOkAsync(ct);
        }
    }
}
