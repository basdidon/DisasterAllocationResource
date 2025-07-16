using FastEndpoints;
using System.ComponentModel;

namespace DisasterAllocationResource.Api.Endpoints.AffectedAreas.GetById.v2
{
    public class Request
    {
        public string AreaId { get; set; } = string.Empty;

        [QueryParam]
        [DefaultValue(true)]
        public bool IncludeRequiredResources { get; set; }

        [QueryParam]
        [DefaultValue(true)]
        public bool IncludeMappedArea { get; set; }
    }
}
