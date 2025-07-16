using FluentValidation;

namespace DisasterAllocationResource.Api.Endpoints.ResourceTrucks.Create
{
    public class Validator : AbstractValidator<Request>
    {
        public Validator()
        {
            RuleFor(x => x.TruckId)
                .NotEmpty()
                .WithMessage("TruckId is required.");
        }
    }
}
