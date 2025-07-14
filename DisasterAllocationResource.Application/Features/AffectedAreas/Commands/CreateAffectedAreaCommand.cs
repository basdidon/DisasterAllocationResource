using FastEndpoints;

namespace DisasterAllocationResource.Application.Features.AffectedAreas.Commands
{
    public record CreateAffectedAreaCommand(string AreaId, int UrgencyLevel, int TimeConstraint) : ICommand;

    internal class CreateAffectedAreaCommandHandler : ICommandHandler<CreateAffectedAreaCommand>
    {
        public Task ExecuteAsync(CreateAffectedAreaCommand command, CancellationToken ct)
        {
            throw new NotImplementedException();
        }
    }
}
