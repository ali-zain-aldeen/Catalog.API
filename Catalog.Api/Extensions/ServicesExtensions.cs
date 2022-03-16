using Catalog.Menus.Contracts;
using Catalog.Menus.Services;
using Catalog.Repositories.Menus.Repositories;

namespace Catalog.Api.Extensions
{
    public static class ServicesExtensions
    {

        public static void RegisterDependencies(this IServiceCollection services)
        {
            services
                .AddServices()
                .AddRepositories()
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

        private static IServiceCollection AddMappers(this IServiceCollection services)
        {
            return services;
        }

        private static IServiceCollection AddVaidations(this IServiceCollection services)
        {
            return services;
        }
    }
}
