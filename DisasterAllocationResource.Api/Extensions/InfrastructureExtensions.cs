using DisasterAllocationResource.Api.Options;
using DisasterAllocationResource.Api.Persistence;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;

namespace DisasterAllocationResource.Api.Extensions
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

            services.AddDbContext<ApplicationDbContext>();
        }

        public static async Task UseInfrastructure(this IApplicationBuilder app)
        {
            await app.EnsureDbCreated<ApplicationDbContext>(true);
        }
    }
}
