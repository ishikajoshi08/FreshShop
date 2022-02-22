using FreshShop.Data;
using FreshShop.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreshShop
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        private readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<FreshShopContext>(option => option.UseSqlServer(_configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<FreshShopContext>();
            services.AddControllersWithViews();
#if DEBUG
            services.AddRazorPages().AddRazorRuntimeCompilation().AddViewOptions(option => 
            {
                option.HtmlHelperOptions.ClientValidationEnabled = true;
            });
#endif
            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddScoped<ICategoryRepository, CategoryRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapGet("/", async context =>
                //{
                //    await context.Response.WriteAsync("Hello World!");
                //});

                endpoints.MapDefaultControllerRoute();

                //endpoints.MapControllerRoute(
                //    name: "default",
                //    pattern: "FreshShopApp/{controller=Home}")
            });
        }
    }
}
