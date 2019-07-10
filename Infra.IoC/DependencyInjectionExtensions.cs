using Infra.Data.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Test.Domain.Interface;
using Test.Domain.Service;

namespace Infra.IoC
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {         
            return services.ConfigureRepositories()
                           .ConfigureDomainServices();
        }

        private static IServiceCollection ConfigureDomainServices(this IServiceCollection services)
        {
            services.AddScoped<ILancamentoService, LancamentoService>();
            
            return services;
        }

        private static IServiceCollection ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<ILancamentoRepository, LancamentoRepository>();
            
            return services;
        }

        public static T GetRequiredService<T>() => ServiceProvider.GetRequiredService<T>();

    }
}
