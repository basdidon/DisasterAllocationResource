using DisasterAllocationResource.Application.Features.ResourceTypes.Commands;
using DisasterAllocationResource.Core.Options;
using DisasterAllocationResource.Infrastructure.Extensions;
using FastEndpoints;
using FastEndpoints.Swagger;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("ConnectionStrings"));
builder.Services
   .AddFastEndpoints(o => {
       o.IncludeAbstractValidators = true;
       o.Assemblies = [typeof(CreateResourceTypeCommand).Assembly];
   })
   .SwaggerDocument(o =>
   {
       o.MaxEndpointVersion = 1;
       o.DocumentSettings = s =>
       {
           s.DocumentName = "Initial Release";
           s.Title = "Disaster Resource Allocation API";
           s.Version = "v1";
       };
   });

builder.Services.AddInfrastructure();

var app = builder.Build();

await app.UseInfrastructure();

app.UseFastEndpoints(c =>
    {
        c.Endpoints.RoutePrefix = "api";
        c.Versioning.Prefix = "v";
        c.Versioning.PrependToRoute = true;
        c.Versioning.DefaultVersion = 1;
    }).UseSwaggerGen();


app.Run();
