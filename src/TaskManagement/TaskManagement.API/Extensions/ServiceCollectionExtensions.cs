using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskManagement.API.Services;

namespace TaskManagement.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
         public static IServiceProvider ConfigureApplicationServices(this IServiceCollection services,
            IConfiguration configuration)
            {
                services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
                services.AddScoped<IUserInfoService, UserInfoService>();
                var containerBuilder = new ContainerBuilder();
                containerBuilder.Populate(services);
                var serviceProvider = new AutofacServiceProvider(containerBuilder.Build());
                return serviceProvider;
            }
    }
}