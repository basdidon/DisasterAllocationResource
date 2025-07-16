using FluentValidation;

namespace DisasterAllocationResource.Api.Endpoints.AffectedAreas.Update
{
    public class Validator : AbstractValidator<Request>
    {
        public Validator()
        {
            RuleFor(x => x.UrgencyLevel)
                .GreaterThanOrEqualTo(1)
                .LessThanOrEqualTo(5);

            RuleFor(x => x.TimeConstraint)
                .GreaterThanOrEqualTo(0);
        }
    }
}
