using CreacionesAmpis.Application.Interfaces;
using CreacionesAmpis.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CreacionesAmpis.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IModelPruebaRepository, ModelPruebaRepository>();
            return services;
        }
    }
}
