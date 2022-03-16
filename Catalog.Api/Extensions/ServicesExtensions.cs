using Catalog.Menus.Contracts;
using Catalog.Menus.Profiles;
using Catalog.Menus.Services;
using Catalog.Repositories.Menus;
using Catalog.Repositories.Menus.Profiles;
using Catalog.Repositories.Menus.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Api.Extensions
{
    public static class ServicesExtensions
    {
        public static void RegisterDependencies(this IServiceCollection services)
        {
            services
                .AddServices()
                .AddRepositories()
                .AddContexts()
                .AddMappers()
                .AddVaidations();
        }

        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IMenusService, MenusService>();

            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IMenusRepository, MenusRepository>();

            return services;
        }

        private static IServiceCollection AddContexts(this IServiceCollection services)
        {
            services.AddDbContext<MenusDbContext>(x => x.UseInMemoryDatabase("MenuesDb"));

            return services;
        }

        private static IServiceCollection AddMappers(this IServiceCollection services)
        {
            return services
            .AddAutoMapper(
                typeof(MenuApplicationProfile).Assembly,
                typeof(MenuProfile).Assembly
            );
        }

        private static IServiceCollection AddVaidations(this IServiceCollection services)
        {
            return services;
        }
    }
}