using CreacionesAmpis.Application.Interfaces;
using CreacionesAmpis.Application.Services;
using CreacionesAmpis.Infrastructure.Persistence;
using CreacionesAmpis.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CreacionesAmpis.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IDapperCreacionesAmpis, DapperCreacionesAmpis>();
            services.AddScoped<IModelPruebaRepository, ModelPruebaRepository>();
            services.AddScoped<IServicePrueba, ServicePrueba>();
            services.AddScoped<IAuthInterface, AuthService>();
            services.AddScoped<IAuthRepository, AuthRepository>();
            return services;
        }
    }
}
