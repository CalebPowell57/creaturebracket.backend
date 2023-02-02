using Microsoft.Extensions.DependencyInjection;

namespace Service.Extensions
{
    public static class ServiceServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<BracketService>();

            return services;
        }
    }
}
