using FluentValidation;

namespace DisasterAllocationResource.Api.Endpoints.AffectedAreas.UpdateRequiredResource
{
    public class Validator : AbstractValidator<Request>
    {
        public Validator()
        {
            RuleFor(x => x.RequiredAmount)
                .GreaterThanOrEqualTo(0);
        }
    }
}
