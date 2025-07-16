using DisasterAllocationResource.Api.DTOs.AffectedAreas;
using DisasterAllocationResource.Api.Models;
using DisasterAllocationResource.Api.Persistence;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace DisasterAllocationResource.Api.Endpoints.AffectedAreas.Create
{
    public class Endpoint(ApplicationDbContext context) : Endpoint<Request>
    {
        public override void Configure()
        {
            Post("/areas");
            AllowAnonymous();
        }

        public override async Task HandleAsync(Request req, CancellationToken ct)
        {
            var exist = await context.AffectedAreas.AnyAsync(x => x.AreaId == req.AreaId, ct);
            if (exist)
            {
                AddError(x => x.AreaId, $"Affected area with ID : '{req.AreaId}' already existing.");
                await SendErrorsAsync(409, ct);
                return;
            }

            var area = new AffectedArea()
            {
                AreaId = req.AreaId,
                UrgencyLevel = req.UrgencyLevel,
                TimeConstraint = req.TimeConstraint
            };

            await context.AffectedAreas.AddAsync(area, ct);
            await context.SaveChangesAsync(ct);

            await SendCreatedAtAsync<GetById.Endpoint>(
                new { req.AreaId },
                AffectedAreaQueryDto.Map(area),
                cancellation: ct);

        }
    }
}
