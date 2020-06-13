using System;
using System.Linq;
using Identity.Configuration;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Identity.Data
{
    public class DatabaseInitializer
    {
        public static void Init(IServiceProvider provider)
        {
            // if (!useInMemoryStores)
            // {
            //     provider.GetRequiredService<TaskIdentityDbContext>().Database.Migrate();
            //     provider.GetRequiredService<PersistedGrantDbContext>().Database.Migrate();
            //     provider.GetRequiredService<ConfigurationDbContext>().Database.Migrate();
            // }
            InitializeIdentityServer(provider);
        }

        private static void InitializeIdentityServer(IServiceProvider provider)
        {
            var context = provider.GetRequiredService<ConfigurationDbContext>();
            if (!context.Clients.Any())
            {
                foreach (var client in Config.GetClients())
                {
                    context.Clients.Add(client.ToEntity());
                }
                context.SaveChanges();
            }

            if (!context.IdentityResources.Any())
            {
                foreach (var resource in Config.GetIdentityResources())
                {
                    context.IdentityResources.Add(resource.ToEntity());
                }
                context.SaveChanges();
            }

            if (!context.ApiResources.Any())
            {
                foreach (var resource in Config.GetApis())
                {
                    context.ApiResources.Add(resource.ToEntity());
                }
                context.SaveChanges();
            }
        }

    }
}