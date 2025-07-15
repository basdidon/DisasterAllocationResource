using DisasterAllocationResource.Application.Interfaces;
using FastEndpoints;

namespace DisasterAllocationResource.Application.Features.AffectedAreas.Commands
{
    public record UpdateAffectedAreaCommand(string AreaId, int UrgencyLevel, int TimeConstraint) : ICommand<bool>;

    class UpdateAffectedAreaCommandHandler(IAffectedAreaRepository affectedAreaRepo) : ICommandHandler<UpdateAffectedAreaCommand,bool>
    {
        public async Task<bool> ExecuteAsync(UpdateAffectedAreaCommand command, CancellationToken ct)
        {
            return await affectedAreaRepo.UpdateAsync(new()
            {
                AreaId = command.AreaId,
                UrgencyLevel = command.UrgencyLevel,
                TimeConstraint = command.TimeConstraint
            }, ct);
        }
    }
}
