using DND5E.Service.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DND5E.Service.Extensions
{
    public static class DND5EServiceCollectionExtensions
    {
        public static IServiceCollection AddDND5E(this IServiceCollection services)
        {
            services.AddScoped<CharacterService>();
            services.AddScoped<ClassService>();
            services.AddScoped<EquipmentService>();
            services.AddScoped<FeatureService>();
            services.AddScoped<MonsterService>();
            services.AddScoped<RaceService>();
            services.AddScoped<RulesService>();
            services.AddScoped<SpellService>();
            services.AddScoped<SubclassService>();
            services.AddScoped<SubraceService>();
            services.AddScoped<TraitService>();

            return services;
        }
    }
}
