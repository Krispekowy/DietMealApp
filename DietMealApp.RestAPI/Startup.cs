using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using MediatR;
using System.Reflection;
using DietMealApp.Service.Functions.Query;
using DietMealApp.Core.DTO.Products;
using DietMealApp.Core.Interfaces;
using DietMealApp.DataAccessLayer.Repositories;
using DietMealApp.DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using DietMealApp.Core.Mappings;

namespace DietMealApp.RestAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IRequestHandler<GetProductByIdQuery, ProductDTO>, GetProductByIdQueryHandler>();
            #region MvcConfig
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.AddControllers().AddNewtonsoftJson();
            services.AddRazorPages().AddRazorRuntimeCompilation();
            //services.AddAuthentication().AddCookie(c =>
            //{
            //    c.LoginPath = "/Identity/Account/Login";
            //});
            services.AddAuthorization();
            services.AddMvc().AddDataAnnotationsLocalization().AddViewLocalization();
            #endregion
            #region DataAccessLayerConfig
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(Configuration
                .GetConnectionString("DietMealAppDB")));

            services.AddDbContext<AppUsersDbContext>(options =>
                options.UseSqlServer(Configuration
                .GetConnectionString("UsersDietMealDB")));
            #endregion

            #region AutoMapper
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddSingleton(AutoMapperConfig.RegisterMappings());
            #endregion

            services.AddMediatR(Assembly.GetExecutingAssembly());
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
                app.UseHsts();
            }

            var localizationOptions = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>().Value;
            app.UseRequestLocalization(localizationOptions);
            app.UseStaticFiles();
            app.UseRouting();
            app.UseCors();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("pl-PL"),
                SupportedCultures = new List<CultureInfo> { new CultureInfo("pl-PL") },
                SupportedUICultures = new List<CultureInfo> { new CultureInfo("pl-PL") }
            });


        }
    }
}
