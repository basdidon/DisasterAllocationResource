using FluentValidation;

namespace DisasterAllocationResource.Api.Endpoints.AreaRoutes.Create
{
    public class Validator : AbstractValidator<Request>
    {
        public Validator()
        {
            RuleFor(x => x.TravelTime)
                .GreaterThanOrEqualTo(1);

            RuleFor(x => x.ToAreaId)
                .NotEqual(x => x.FromAreaId)
                .WithMessage("From and To areas must be different.");
        }
    }   
}
