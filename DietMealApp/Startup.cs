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
using DietMealApp.Core.Interfaces;
using DietMealApp.DataAccessLayer.Repositories;
using MediatR;
using System.Reflection;
using DietMealApp.Service.Functions.Query;
using DietMealApp.Service.Functions.Command;
using DietMealApp.Core.DTO.Products;
using DietMealApp.Core.Mappings;
using DietMealApp.Core.DTO;
using DietMealApp.Application.Functions.Meal.Command.InsertMeal;
using DietMealApp.Core.DTO.Meals;
using DietMealApp.Application.Functions.Meal.Query.GetMealById;
using DietMealApp.Application.Functions.Meal.Command.UpdateMeal;
using DietMealApp.Application.Functions.Meal.Command.DeleteMeal;
using DietMealApp.Application.Functions.DietDay.Query.GetDaysByUser;
using DietMealApp.Core.DTO.Days;
using DietMealApp.Application.Functions.Meal.Query.GetMealsByType;
using Microsoft.AspNetCore.Mvc.Rendering;
using DietMealApp.Application.Functions.Meal.Query.GetMealsBySearch;
using DietMealApp.Application.Functions.Product.Query.GetProductsBySearch;
using DietMealApp.Application.Functions.Day.Command.InsertDay;
using DietMealApp.Application.Functions.Day.Command.DeleteDay;
using DietMealApp.Application.Functions.Day.Query.GetDayById;
using DietMealApp.Application.Functions.Diet.Query.GetDietsByUser;
using DietMealApp.Application.Functions.Diet.Command;
using DietMealApp.Application.Functions.Day.Command.UpdateDay;
using DietMealApp.Application.Functions.Shopping.Query;
using Microsoft.AspNetCore.Authentication.Cookies;
using DietMealApp.Application.Commons.Settings;
using DietMealApp.Application.Commons.Services;
using DietMealApp.Application.Commons.Services.FileManager;
using DietMealApp.Application.Functions.Day.Query.GetDaysByIds;
using DietMealApp.Core.DTO.Menu;
using DietMealApp.Application.Functions.Menu.Query.GetMenuForm;
using DietMealApp.Application.Functions.Menu.Query.GetMenuForWeek;
using DietMealApp.Core.ViewModels;
using DietMealApp.Application.Functions.Shopping.Query.GetShoppingListById;
using DietMealApp.Application.Functions.Shopping.Query.GetAllShoppingLists;
using DietMealApp.Application.Functions.Shopping.Query.GetShoppingListBySearch;
using DietMealApp.Application.Functions.Shopping.Command.DeleteShoppingList;
using DietMealApp.Application.Functions.Shopping.Command.InsertShoppingList;
using DietMealApp.Application.Functions.Shopping.Command.UpdateShoppingList;

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
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
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

            services.Configure<MailSettings>(Configuration.GetSection("MailSettings"));

            #region DependencyInjection
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IMealRepository, MealRepository>();
            services.AddScoped<IDayRepository, DayRepository>();
            services.AddScoped<IDietRepository, DietRepository>();

            services.AddScoped<IRequestHandler<GetAllProductsQuery, List<ProductDTO>>, GetAllProductsQueryHandler>();
            services.AddScoped<IRequestHandler<GetDietsByUserQuery, List<DietDTO>>, GetDietsByUserQueryHandler>();
            services.AddScoped<IRequestHandler<GetProductByIdQuery, ProductDTO>, GetProductByIdQueryHandler>();
            services.AddScoped<IRequestHandler<GetDaysByUserQuery, List<DayDTO>>, GetDaysByUserQueryHandler>();
            services.AddScoped<IRequestHandler<InsertProductCommand, Unit>, InsertProductCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteProductCommand, Unit>, DeleteProductCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateProductCommand, Unit>, UpdateProductCommandHandler>();
            services.AddScoped<IRequestHandler<GetMealsByUserQuery, List<MealDTO>>, GetMealsByUserQueryHandler>();
            services.AddScoped<IRequestHandler<InsertMealCommand, Unit>, InsertMealCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateMealCommand, Unit>, UpdateMealCommandHandler>();
            services.AddScoped<IRequestHandler<GetMealFormByIdQuery, MealFormDTO>, GetMealFormByIdQueryHandler>();
            services.AddScoped<IRequestHandler<DeleteMealCommand, Unit>, DeleteMealCommandHandler>();
            services.AddScoped<IRequestHandler<GetMealsByTypeQuery, SelectList>, GetMealsByTypeQueryHandler>();
            services.AddScoped<IRequestHandler<GetMealsBySearchQuery, SelectList>, GetMealsBySearchQueryHandler>();
            services.AddScoped<IRequestHandler<GetProductsBySearchQuery, SelectList>, GetProductsBySearchQueryHandler>();
            services.AddScoped<IRequestHandler<InsertDayCommand, Unit>, InsertDayCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteDayCommand, Unit>, DeleteDayCommandHandler>();
            services.AddScoped<IRequestHandler<GetDayFormDTOByIdQuery, DayFormDTO>, GetDayFormDTOByIdQueryHandler>();
            services.AddScoped<IRequestHandler<GetDayByIdQuery, Day>, GetDayByIdQueryHandler>();
            services.AddScoped<IRequestHandler<InsertDietCommand, Unit>, InsertDietCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateDayCommand, Unit>, UpdateDayCommandHandler>();
            services.AddScoped<IRequestHandler<GetShoppingListQuery, List<ProductsToBuyDTO>>, GetShoppingListQueryHandler>();
            services.AddScoped<IRequestHandler<GetDaysByIdsQuery, List<DayDTO>>, GetDaysByIdsQueryHandler>();
            services.AddScoped<IRequestHandler<GetMenuFormQuery, List<MenuDTO>>, GetMenuFormQueryHandler>();
            services.AddScoped<IRequestHandler<GetMenuForWeekQuery, List<MenuWeeklyViewModel>>, GetMenuForWeekQueryHandler>();
            services.AddScoped<IRequestHandler<GetShoppingListByIdQuery, ShoppingListDTO>, GetShoppingListByIdQueryHandler>();
            services.AddScoped<IRequestHandler<GetShoppingListsQuery, List<ShoppingListDTO>>, GetShoppingListsQueryHandler>();
            services.AddScoped<IRequestHandler<GetShoppingListBySearchQuery, List<ShoppingListDTO>>, GetShoppingListBySearchQueryHandler>();
            services.AddScoped<IRequestHandler<DeleteShoppingListCommand, Unit>, DeleteShoppingListCommandHandler>();
            services.AddScoped<IRequestHandler<InsertShoppingListCommand, Unit>, InsertShoppingListCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateShoppingListCommand, Unit>, UpdateShoppingListCommandHandler>();
            services.AddSingleton<IFileManager>(a => new FileManager(
              Configuration["FileManager:Host"],
              Configuration["FileManager:User"],
              Configuration["FileManager:Password"],
              a.GetService<IWebHostEnvironment>()));
            services.AddSingleton<IMailService, MailService>();
            services.AddSingleton<IPdfGenerator, PdfGenerator>();
            #endregion

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
                    options.SignIn.RequireConfirmedEmail = true;
                    options.SignIn.RequireConfirmedAccount = true;
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
                options.Cookie.Name = "MealAppCookie";
                options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;

                options.LoginPath = "/Identity/Account/Login";
                options.AccessDeniedPath = "/Identity/Account/AccessDenied";
                options.SlidingExpiration = true;
            });
            services.AddControllersWithViews();

            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin());
            });


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
