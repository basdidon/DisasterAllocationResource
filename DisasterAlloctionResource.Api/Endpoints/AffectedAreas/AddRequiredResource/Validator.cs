using FluentValidation;

namespace DisasterAllocationResource.Api.Endpoints.AffectedAreas.AddRequiredResource
{
    public class Validator : AbstractValidator<Request>
    {
        public Validator()
        {
            RuleFor(x => x.RequiredAmount)
                .GreaterThanOrEqualTo(1);
        }
    }
}
