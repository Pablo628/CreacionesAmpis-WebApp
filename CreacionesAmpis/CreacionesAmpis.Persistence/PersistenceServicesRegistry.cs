using CreacionesAmpis.Application.Contracts.Persistence;
using CreacionesAmpis.Application.Contracts.Repositories;
using CreacionesAmpis.Persistence.Entities;
using CreacionesAmpis.Persistence.Repositories;
using CreacionesAmpis.Persistence.Seeding;
using CreacionesAmpis.Persistence.UnitOfWorks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
namespace CreacionesAmpis.Persistence
{
    public static class PersistenceServicesRegistry
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<DataContext>(options => options.UseSqlServer("name=CreacionesAmpisConnectionString"));
            services.AddScoped<IUnitOfWork, EfCoreUnitOfWork>();
            services.AddScoped<ICategoriesRepository, CategoriesRepository>();
            services.AddScoped<IProductsRepository, ProductsRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddTransient<SeedDb>();
            services.AddAuthentication(options => { options.DefaultAuthenticateScheme = IdentityConstants.ApplicationScheme; options.DefaultChallengeScheme = IdentityConstants.ApplicationScheme; options.DefaultSignInScheme = IdentityConstants.ApplicationScheme; }).AddIdentityCookies();
            services.AddIdentityCore<ApplicationUser>(options => { options.Password.RequireDigit = true; options.Password.RequireLowercase = false; options.Password.RequireUppercase = false; options.Password.RequireNonAlphanumeric = false; options.Password.RequiredLength = 4; options.SignIn.RequireConfirmedEmail = false; options.User.RequireUniqueEmail = true; }).AddSignInManager<SignInManager<ApplicationUser>>().AddEntityFrameworkStores<DataContext>().AddDefaultTokenProviders();
            services.ConfigureApplicationCookie(options => { options.Cookie.HttpOnly = true; options.LoginPath = "/Account/Login"; options.LogoutPath = "/Account/Logout"; options.AccessDeniedPath = "/Account/AccessDenied"; options.SlidingExpiration = true; options.ExpireTimeSpan = TimeSpan.FromDays(15); });
            return services;
        }
    }
}
