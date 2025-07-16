using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace DisasterAllocationResource.Api.Endpoints.ResourceTrucks.AddAvailableResource
{
    public class Validator : AbstractValidator<Request>
    {
        public Validator()
        {
            RuleFor(x => x.AvailableAmount)
                .GreaterThan(0);
        }
    }
}
