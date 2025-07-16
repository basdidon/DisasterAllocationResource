using FastEndpoints;
using System.ComponentModel;

namespace DisasterAllocationResource.Api.Endpoints.AffectedAreas.List.v2
{
    public class Request
    {
        [QueryParam]
        [DefaultValue(true)]
        public bool IncludeRequiredResources { get; set; }

        [QueryParam]
        [DefaultValue(true)]
        public bool IncludeMappedArea { get; set; }
    }
}
