using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Model.Mapping;

namespace Service.Extensions
{
    public static class ModelServiceCollectionExtensions
    {
        public static IServiceCollection AddMapper(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            services.AddSingleton(mapperConfig.CreateMapper());

            return services;
        }
    }
}
