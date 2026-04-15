using CreacionesAmpis.Application.Commands.Products;
using CreacionesAmpis.Application.Interfaces;
using CreacionesAmpis.Application.Queries.Products;
using Microsoft.Extensions.DependencyInjection;
using CreacionesAmpis.Application.Commands.Categories;
using CreacionesAmpis.Application.Queries.Categories;

namespace CreacionesAmpis.Application.DependencyInjection;

public static class ApplicationServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IProductCommands, ProductCommands>();
        services.AddScoped<IProductQueries, ProductQueries>();
        services.AddScoped<ICategoryCommands, CategoryCommands>();
        services.AddScoped<ICategoryQueries, CategoryQueries>();

        return services;
    }
}