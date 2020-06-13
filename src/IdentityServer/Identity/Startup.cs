using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Identity.Configuration;
using Identity.Data;
using Identity.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Identity
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<TaskIdentityDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("TaskIdentityDB")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<TaskIdentityDbContext>()
                .AddDefaultTokenProviders();

           // var builder = services.AddIdentityServer(options =>
           //     {
           //         options.Events.RaiseErrorEvents = true;
           //         options.Events.RaiseInformationEvents = true;
           //         options.Events.RaiseFailureEvents = true;
           //         options.Events.RaiseSuccessEvents = true;
           //     })
           //     //.AddInMemoryIdentityResources(Config.Ids)
           //     //.AddInMemoryApiResources(Config.Apis)
           //     //.AddInMemoryClients(Config.Clients)
           //     .AddAspNetIdentity<ApplicationUser>();

           // //not recommended for production - you need to store your key material somewhere secure

           //builder.AddDeveloperSigningCredential();
           services.AddIdentityServer(options =>
           {
               options.Events.RaiseErrorEvents = true;
               options.Events.RaiseInformationEvents = true;
               options.Events.RaiseFailureEvents = true;
               options.Events.RaiseSuccessEvents = true;
           })// this adds the config data from DB (clients, resources)
        //    .AddInMemoryApiResources(Config.GetApis())
        //    .AddInMemoryClients(Config.GetClients())
        //    .AddInMemoryIdentityResources(Config.GetIdentityResources())
        .AddDeveloperSigningCredential()
           .AddConfigurationStore(options =>
           {
               options.ConfigureDbContext = opt =>
               {
                   //if (useInMemoryStores)
                   //{
                   //    opt.UseInMemoryDatabase("IdentityServerDb");
                   //}
                   //else
                   //{
                   //    opt.UseSqlServer(Configuration.GetConnectionString("TaskIdentityDB"));
                   //}
                   opt.UseSqlServer(Configuration.GetConnectionString("TaskIdentityDB"), 
                       optionsBuilder =>
                           optionsBuilder.MigrationsAssembly(typeof(Startup).Assembly.GetName().Name));
               };
           })
            // this adds the operational data from DB (codes, tokens, consents)
           .AddOperationalStore(options =>
           {
               options.ConfigureDbContext = opt =>
               {
                   //if (useInMemoryStores)
                   //{
                   //    opt.UseInMemoryDatabase("IdentityServerDb");
                   //}
                   //else
                   //{
                   //    opt.UseSqlServer(Configuration.GetConnectionString("TaskIdentityDB"));
                   //}
                   opt.UseSqlServer(Configuration.GetConnectionString("TaskIdentityDB"),
                       optionsBuilder =>
                           optionsBuilder.MigrationsAssembly(typeof(Startup).Assembly.GetName().Name));
               };

               // this enables automatic token cleanup. this is optional.
               options.EnableTokenCleanup = true;
           })
           .AddAspNetIdentity<ApplicationUser>();
           services.AddAuthentication();
           services.AddCors();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseIdentityServer();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
