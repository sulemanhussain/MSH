using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MSH.Entities.AppDBContext;
using MSH.Entities.Business;
using MSH.Entities.Repository;
using System;

namespace MSH
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
            services.AddSingleton<IConfiguration>(Configuration);

            services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ApplicationDBContext")));

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddDefaultUI()
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<ApplicationDBContext>();

            services.AddTransient<IQuery, QueryRepository>();

            services.AddAuthentication()
                .AddGoogle(options =>
                {
                    //IConfigurationSection googleAuthSection = Configuration.GetSection("GoogleAutheKey");
                    options.ClientId = "226408491023-98ljmh4fkfadef4eaiegqkcbq5i8f659.apps.googleusercontent.com";
                    options.ClientSecret = "8JSR9LRh9Sw-7PQKDdkgtwrV";
                })
                .AddFacebook(options =>
                {
                    options.ClientId = "381186896887774";
                    options.ClientSecret = "a62f39afd523068074d14c2a5d91a0c9";
                })
                .AddMicrosoftAccount(options =>
                {
                    options.ClientId = "3ee380be-e126-4a93-89d6-ecd55beb605f";
                    options.ClientSecret = "2Yv48dqp_by0isqujKZu-2Q5.l7~BTxTLf";
                });
                //.AddTwitter(options =>
                //{
                //    options.ConsumerKey = "jhkjhkhjkhjk";
                //    options.ConsumerSecret = "ghfgttertsdfgdf";
                //    options.RetrieveUserDetails = true;
                //});

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(10);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
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

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSession();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();

                endpoints.MapControllerRoute(
                    name: "getData",
                    pattern: "{controller}/{action}/{guid?}",
                    defaults: null,
                    constraints: new { id = "[A-Z0-9]{8}-([A-Z0-9]{4}-){3}[A-Z0-9]{12}" });

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}