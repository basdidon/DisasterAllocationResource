using FastEndpoints;
using System.ComponentModel;

namespace DisasterAllocationResource.Api.Endpoints.ResourceTrucks.GetById
{
    public class Request
    {
        public string TruckId { get; set; } = string.Empty;

        [QueryParam]
        [DefaultValue(true)]
        public bool IncludeAvailableResources { get; set; }
        [QueryParam]
        [DefaultValue(true)]
        public bool IncludeRoutes { get; set; }
    }
}
