using FluentValidation;

namespace DisasterAllocationResource.Api.Endpoints.AreaRoutes.Create
{
    public class Validator : AbstractValidator<Request>
    {
        public Validator()
        {
            RuleFor(x => x.TravelTime)
                .GreaterThanOrEqualTo(1);
        }
    }   
}
