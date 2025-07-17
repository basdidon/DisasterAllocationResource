using FastEndpoints;
using System.ComponentModel;

namespace DisasterAllocationResource.Api.Endpoints.ResourceTrucks.List
{
    public class Request
    {
        [QueryParam]
        [DefaultValue(true)]
        public bool IncludeAvailableResources { get; set; }
        [QueryParam]
        [DefaultValue(true)]
        public bool IncludeRoutes { get; set; }
    }
}
