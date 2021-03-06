using Catalog.Menus.Contracts;
using Catalog.Menus.Dtos;
using Catalog.Menus.Profiles;
using Catalog.Menus.Services;
using Catalog.Menus.Validators;
using Catalog.Repositories.Menus;
using Catalog.Repositories.Menus.Profiles;
using Catalog.Repositories.Menus.Repositories;
using FluentValidation;
using MassTransit;
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
                .AddVaidations()
                .AddMessageBrokers();
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
            return services
                .AddScoped<AbstractValidator<AddMenuDto>, AddMenuValidator>()
                .AddScoped<AbstractValidator<UpdateMenuDto>, UpdateMenuValidator>();
        }

        private static IServiceCollection AddMessageBrokers(this IServiceCollection services)
        {
            return
            services.AddMassTransit(x =>
            {
                x.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(config =>
                {
                    config.UseHealthCheck(provider);
                    config.Host(new Uri("rabbitmq://localhost"), h =>
                    {
                        h.Username("guest");
                        h.Password("guest");
                    });
                }));
            })
            .AddMassTransitHostedService();
        }
    }
}