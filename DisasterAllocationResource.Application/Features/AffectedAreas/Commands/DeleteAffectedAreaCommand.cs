using DisasterAllocationResource.Application.Interfaces;
using FastEndpoints;

namespace DisasterAllocationResource.Application.Features.AffectedAreas.Commands
{
    public record DeleteAffectedAreaCommand(string AreaId) : ICommand;

    class DeleteAffectedAreaCommandHandler(IAffectedAreaRepository affectedAreaRepo) : CommandHandler<DeleteAffectedAreaCommand>
    {
        public override async Task ExecuteAsync(DeleteAffectedAreaCommand command, CancellationToken ct = default)
        {
            await affectedAreaRepo.DeleteAsync(command.AreaId, ct);
        }
    }


}
