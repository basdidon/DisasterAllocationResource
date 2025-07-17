using FluentValidation;

namespace DisasterAllocationResource.Api.Endpoints.Resources.Create
{
    public class Request
    {
        public string ResourceId { get; set; } = string.Empty;
    }

    public class Validator: AbstractValidator<Request>
    {
        public Validator()
        {
            RuleFor(x=>x.ResourceId)
                .NotEmpty()
                .WithMessage("Resource ID cannot be empty.");
        }
    }
}
