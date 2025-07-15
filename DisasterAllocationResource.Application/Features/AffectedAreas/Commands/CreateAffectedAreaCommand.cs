using DisasterAllocationResource.Application.Interfaces;
using FastEndpoints;

namespace DisasterAllocationResource.Application.Features.AffectedAreas.Commands
{
    public record CreateAffectedAreaCommand(string AreaId, int UrgencyLevel, int TimeConstraint) : ICommand;

    internal class CreateAffectedAreaCommandHandler(IAffectedAreaRepository affectedAreaRepo) : CommandHandler<CreateAffectedAreaCommand>
    {
        public override async Task ExecuteAsync(CreateAffectedAreaCommand command, CancellationToken ct = default)
        {
            var existingArea = await affectedAreaRepo.GetByIdAsync(command.AreaId, ct);
            if (existingArea != null)
            {
                ThrowError(c => c.AreaId, "Affected area already exists.", statusCode:409);
            }

            await affectedAreaRepo.CreateAsync(new()
            {
                AreaId = command.AreaId,
                UrgencyLevel = command.UrgencyLevel,
                TimeConstraint = command.TimeConstraint
            }, ct);
        }
    }
}
