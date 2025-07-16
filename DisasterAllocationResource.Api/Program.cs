using DisasterAllocationResource.Api.Extensions;
using DisasterAllocationResource.Api.Options;
using DisasterAllocationResource.Api.Persistence;
using FastEndpoints;
using FastEndpoints.Swagger;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("ConnectionStrings"));

builder.Services.AddDbContext<ApplicationDbContext>((serviceProvider, options) =>
{
    var settings = serviceProvider.GetRequiredService<IOptions<DatabaseSettings>>().Value;
    options.UseNpgsql(settings.DefaultConnection);
});

builder.Services.AddStackExchangeRedisCache((options) =>
{
    var connection = builder.Configuration.GetConnectionString("Redis");
    options.Configuration = connection;
});

builder.Services
   .AddFastEndpoints(o =>
   {
       o.IncludeAbstractValidators = true;
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
   }).SwaggerDocument(o =>
   {
       o.MaxEndpointVersion = 2;
       o.DocumentSettings = s =>
       {
           s.DocumentName = "V2";
           s.Title = "Disaster Resource Allocation API";
           s.Version = "v2";
       };
   });

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwaggerGen();
    await app.EnsureDbCreated<ApplicationDbContext>();
}

app.UseFastEndpoints(c =>
    {
        c.Endpoints.Configurator = ep =>
        {
            ep.AllowAnonymous();  // Globally allow anonymous access
        };
        c.Endpoints.RoutePrefix = "api";
        c.Versioning.Prefix = "v";
        c.Versioning.PrependToRoute = true;
        c.Versioning.DefaultVersion = 1;
    }).UseSwaggerGen();


app.Run();
