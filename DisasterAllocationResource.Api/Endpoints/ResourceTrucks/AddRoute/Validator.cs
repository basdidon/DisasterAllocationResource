using FluentValidation;

namespace DisasterAllocationResource.Api.Endpoints.ResourceTrucks.AddRoute
{
    public class Validator : AbstractValidator<Request>
    {
        public Validator()
        {
            RuleFor(x => x.TravelTime)
                .GreaterThan(0);
        }
    }
}
