using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Globalization;
using DietMealApp.DataAccessLayer;
using Microsoft.AspNetCore.Identity;
using DietMealApp.Core.Entities;
using DietMealApp.Service;
using DietMealApp.Core.Interfaces;
using DietMealApp.DataAccessLayer.Repositories;
using MediatR;
using System.Reflection;
using DietMealApp.Service.Functions.Query;
using DietMealApp.Service.Functions.Command;
using DietMealApp.Core.DTO.Products;
using AutoMapper;
using DietMealApp.Core.Mappings;
using DietMealApp.Core.DTO;
using DietMealApp.Core.Services;
using DietMealApp.Application.Functions.Meal.Command.InsertMeal;
using DietMealApp.Core.DTO.Meals;
using DietMealApp.Application.Functions.Meal.Query.GetMealById;
using DietMealApp.Application.Functions.Meal.Command.UpdateMeal;
using DietMealApp.Application.Functions.Meal.Command.DeleteMeal;
using DietMealApp.Application.Functions.DietDay.Query.GetDaysByUser;

namespace DietMealApp
{
    public class Startup
    {
        private readonly List<CultureInfo> _SupportedCultures = new List<CultureInfo>
        {
            //new CultureInfo("en-GB"),
            new CultureInfo("pl-PL")
        };

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            #region CultureAndLocalizationConfig
            services.Configure<RequestLocalizationOptions>(options =>
            {
                options.DefaultRequestCulture = new RequestCulture("pl-PL");
                options.SupportedCultures = _SupportedCultures;
                options.SupportedUICultures = _SupportedCultures;
            });
            services.Configure<FormOptions>(options =>
            {
                options.ValueLengthLimit = int.MaxValue;
                options.MultipartBodyLengthLimit = long.MaxValue; // if don't set default value is: 128 MB
                options.MultipartHeadersLengthLimit = int.MaxValue;
            });
            //services.AddLocalization();
            services.AddLocalization(options => options.ResourcesPath = "");

            #endregion

            #region DependencyInjection
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IMealRepository, MealRepository>();
            services.AddScoped<IDayRepository, DayRepository>();
            services.AddScoped<IDietRepository, DietRepository>();

            services.AddScoped<IRequestHandler<GetAllProductsQuery, List<ProductDTO>>, GetAllProductsQueryHandler>();
            services.AddScoped<IRequestHandler<GetProductByIdQuery, ProductDTO>, GetProductByIdQueryHandler>();
            services.AddScoped<IRequestHandler<GetDaysByUserQuery, List<DayDTO>>, GetDaysByUserQueryHandler>();
            services.AddScoped<IRequestHandler<InsertProductCommand, Unit>, InsertProductCommandHandler> ();
            services.AddScoped<IRequestHandler<DeleteProductCommand, Unit>, DeleteProductCommandHandler> ();
            services.AddScoped<IRequestHandler<UpdateProductCommand, Unit>, UpdateProductCommandHandler>();
            services.AddScoped<IRequestHandler<GetMealsByUserQuery, List<MealDTO>>, GetMealsByUserQueryHandler>();
            services.AddScoped<IRequestHandler<InsertMealCommand, Unit>, InsertMealCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateMealCommand, Unit>, UpdateMealCommandHandler>();
            services.AddScoped<IRequestHandler<GetMealFormByIdQuery, MealFormDTO>, GetMealFormByIdQueryHandler>();
            services.AddScoped<IRequestHandler<DeleteMealCommand, Unit>, DeleteMealCommandHandler>();

            #endregion

            #region RestClientConfig

            ////services.AddHttpClient();
            ////services.AddHttpClient("meta", a =>
            ////{
            ////    a.BaseAddress = new Uri("http://localhost:63494");
            ////});

            //services.AddTransient(i =>
            //    new RestClient(Configuration["ApiLink"])
            //);

            #endregion RestClientConfig

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

            #region Identity
            services.AddIdentity<AppUser, IdentityRole<Guid>>(
                options =>
                {
                    options.SignIn.RequireConfirmedEmail = false;
                    options.SignIn.RequireConfirmedAccount = false;
                    options.User.AllowedUserNameCharacters = "QqWwEeRrTtYyUuIiOoPpLlKkJjHhGgFfDdSsAaZzXxCcVvBbNnMm1234567890-._";
                    options.User.RequireUniqueEmail = true;
                    options.Password.RequireUppercase = true;
                    options.Password.RequireDigit = true;
                    options.Password.RequireLowercase = true;
                    options.Password.RequireNonAlphanumeric = true;
                    options.Password.RequiredLength = 8;
                    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromHours(1);
                    options.Lockout.MaxFailedAccessAttempts = 3;
                })
                .AddUserManager<UserManager<AppUser>>()
                .AddSignInManager<SignInManager<AppUser>>()
                .AddRoleManager<RoleManager<IdentityRole<Guid>>>()
                .AddEntityFrameworkStores<AppUsersDbContext>()
                .AddDefaultTokenProviders()
                .AddDefaultUI();
            #endregion

            #region AutoMapper
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddSingleton(AutoMapperConfig.RegisterMappings());
            #endregion

            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

                options.LoginPath = "/Identity/Account/Login";
                options.AccessDeniedPath = "/Identity/Account/AccessDenied";
                options.SlidingExpiration = true;
            });
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                //app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
                app.UseHttpsRedirection();
                app.UseStatusCodePagesWithRedirects("/Errors/{0}");
                //app.UseBrowserLink();
            }
            var localizationOptions = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>().Value;
            app.UseRequestLocalization(localizationOptions);

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("pl-PL"),
                SupportedCultures = _SupportedCultures,
                SupportedUICultures = _SupportedCultures
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                //.RequireAuthorization();
                endpoints.MapRazorPages();
            });
        }
    }
}
