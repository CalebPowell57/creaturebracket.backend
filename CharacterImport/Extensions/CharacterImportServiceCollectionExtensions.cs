using CharacterImport.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DND5E.Service.Extensions
{
    public static class CharacterImportServiceCollectionExtensions
    {
        public static IServiceCollection AddCharacterImportServices(this IServiceCollection services)
        {
            services.AddScoped<DnDBeyondService>();

            return services;
        }
    }
}
