using DisasterAllocationResource.Application.Interfaces;
using FastEndpoints;

namespace DisasterAllocationResource.Application.Features.ResourceTypes.Commands
{
    public record CreateResourceTypeCommand(string ResourceId) : ICommand;

    public class CreateResourceTypeCommandHandler(IResourceTypeRepository resourceTypeRepo) : CommandHandler<CreateResourceTypeCommand>
    {
        public override async Task ExecuteAsync(CreateResourceTypeCommand command, CancellationToken ct)
        {
            var existResourceType = await resourceTypeRepo.GetById(command.ResourceId, ct);
            if (existResourceType != null)
            {
                ThrowError(c => c.ResourceId, "Resource type name already exists.");
            }

            await resourceTypeRepo.CreateAsync(new() { ResourceId = command.ResourceId }, ct);
        }
    }
}
