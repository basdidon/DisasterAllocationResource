using DisasterAllocationResource.Application.Interfaces;
using FastEndpoints;

namespace DisasterAllocationResource.Application.Features.AffectedAreas.Commands
{
    public record AddRequiredResourceCommand(string AreaId, string ResourceId, int RequiredAmount) : ICommand;
    class AddRequiredResourceCommandHandler(IAffectedAreaRepository affectedAreaRepo,IResourceRepository resourceTypeRepo) : CommandHandler<AddRequiredResourceCommand>
    {
        public override async Task ExecuteAsync(AddRequiredResourceCommand command, CancellationToken ct = default)
        {
            var existingArea = await affectedAreaRepo.GetByIdAsync(command.AreaId, ct);
            if (existingArea == null)
            {
                ThrowError(c => c.AreaId, "Affected area does not exist.", statusCode: 404);
            }

            var existingResource = await resourceTypeRepo.GetByIdAsync(command.ResourceId, ct);
            if(existingResource == null) {
                ThrowError(c => c.ResourceId, "Resource does not exist.", statusCode: 404);
            }

            await affectedAreaRepo.AddRequiredResourceAsync(command.AreaId, command.ResourceId, command.RequiredAmount, ct);
        }
    }
}
