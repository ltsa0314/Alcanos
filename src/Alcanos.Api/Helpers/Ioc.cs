
using AutoMapper;
using Alcanos.Api.Helpers.AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Alcanos.Domain.Repositories;
using Alcanos.Infraestructure.Repositories;
using Microsoft.OpenApi.Models;
using System;
using Microsoft.EntityFrameworkCore;
using Alcanos.Infraestructure;
using Microsoft.Extensions.Configuration;

namespace Alcanos.Api.Helpers
{
    public static class Ioc
    {

        public static void AddAlcanosDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SeguridadDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("AlcanosDb")));
        }
        public static void AddAlcanosRegistrationHttpContext(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }
        public static void AddAlcanosCors(this IServiceCollection services)
        {
            services.AddCors(c =>
            {
                c.AddPolicy("AllowAnyOrigin", options => options.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod());
            });
        }
        public static void AddAlcanosRepositories(this IServiceCollection services)
        {
            services.AddTransient<IOpcionRepository, OpcionRepository>();
            services.AddTransient<IRolOpcionRepository, RolOpcionRepository>();
            services.AddTransient<IRolRepository, RolRepository>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            services.AddTransient<IUsuarioRolRepository, UsuarioRolRepository>();
        }
        public static void AddAlcanosAutoMapperSetup(this IServiceCollection services)
        {
            services.AddAutoMapper(AutoMapperConfig.RegisterMappings());
        }
        public static void AddAlcanosSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(config =>
            {
                config.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Alcanos.Api",
                    Version = "v1",
                    Contact = new OpenApiContact()
                    {
                        Email = "ltsa0314@gmail.com",
                        Name = "Leidy Tatiana Sanchez Arevalo"
                    },
                });
            });
        }

    }
}
