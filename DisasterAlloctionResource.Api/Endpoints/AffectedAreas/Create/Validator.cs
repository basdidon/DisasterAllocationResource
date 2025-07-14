using FluentValidation;

namespace DisasterAllocationResource.Api.Endpoints.AffectedAreas.Create
{
    public class Validator : AbstractValidator<Request>
    {
        public Validator()
        {
            RuleFor(x => x.UrgencyLevel)
                .GreaterThanOrEqualTo(1)
                .LessThanOrEqualTo(5);

            RuleFor(x => x.TimeConstrain)
                .GreaterThanOrEqualTo(0);
        }
    }
}
