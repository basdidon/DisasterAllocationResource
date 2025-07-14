using DisasterAllocationResource.Application.Interfaces;
using DisasterAllocationResource.Core.Options;
using DisasterAllocationResource.Infrastructure.Persistence;
using DisasterAllocationResource.Infrastructure.Persistence.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace DisasterAllocationResource.Infrastructure.Extensions
{
    public static class InfrastructureExtensions
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>((serviceProvider, options) =>
            {
                var settings = serviceProvider.GetRequiredService<IOptions<DatabaseSettings>>().Value;
                options.UseNpgsql(settings.DefaultConnection);
            });

            services.AddScoped<IResourceTypeRepository, ResourceTypeRepository>();
            services.AddDbContext<ApplicationDbContext>();
        }

        public static async Task UseInfrastructure(this IApplicationBuilder app)
        {
            await app.EnsureDbCreated<ApplicationDbContext>(true);
        }
    }
}
