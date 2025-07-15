using FastEndpoints;
using FluentValidation;

namespace DisasterAllocationResource.Api.Endpoints.AreaRoutes.Create
{
    public class Request
    {
        public string FromAreaId { get; set; } = string.Empty;
        public string ToAreaId { get; set; } = string.Empty;
        public int TravelTime { get; set; }

    }

    public class Validator : AbstractValidator<Request>
    {
        public Validator()
        {
            RuleFor(x => x.TravelTime)
                .GreaterThanOrEqualTo(1);
        }
    }   

    public class Endpoint:Endpoint<Request>
    {
        public override void Configure()
        {
            Post("/routes/{fromAreaId}/{toAreaId}");
            AllowAnonymous();
        }

        public override Task HandleAsync(Request req, CancellationToken ct)
        {
            return base.HandleAsync(req, ct);
        }
    }
}
