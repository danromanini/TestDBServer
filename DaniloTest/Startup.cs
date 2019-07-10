using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Infra.IoC;
using System;
using DaniloTest.Models.Mappers;
using Microsoft.AspNetCore.Mvc;
using Test.Domain.Interface;
using Test.Domain.Service;
using Infra.Data.Repositories;

namespace DaniloTest
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(SetSwaggerOptions())
                    .AddMvc()
                    .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddScoped<ILancamentoService, LancamentoService>();
            services.AddScoped<ILancamentoRepository, LancamentoRepository>();

            AutoMapperConfig.RegisterMappings();
        }
                
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            var swaggerBasePath = Configuration.GetValue("SwaggerBasePath", "/Lancamentos");
            app.UseSwagger()
               .UseSwaggerUI(c => c.SwaggerEndpoint($"{swaggerBasePath}/swagger/v1/swagger.json", "Lancamentos V1"))
               .UseHttpsRedirection()               
               .UseMvc();
        }

        private static class AutoMapperConfig
        {
            public static void RegisterMappings() => AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.AddProfile(typeof(ApiToDtoMappingProfile));                                
            });
        }

        private static Action<SwaggerGenOptions> SetSwaggerOptions() =>
        options =>
        {
            options.SwaggerDoc("v1",
            new Info
            {
                Title = "Test Lancamentos - Lancamento Api",
                Version = "v1",
                Description = "API to Credit/Debit Launches",
            });
        };
    }
}
