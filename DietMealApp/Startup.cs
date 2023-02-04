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
using MediatR;
using System.Reflection;
using DietMealApp.Core.Mappings;
using DietMealApp.WebClient.Extensions;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.Cookies;
using DietMealApp.Application.Commons.Settings;
using DietMealApp.Application.Commons.Services;
using DietMealApp.Application.Commons.Services.FileManager;
using Microsoft.AspNetCore.Authentication;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;

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

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DietMealApp API", Version = "v1" });
            });

            #region DependencyInjection
            services.AddRepositoriesServices();
            services.AddHandlersServices();
            services.AddSingleton<IFileManager>(a => new FileManager(
              Configuration["FileManager:Host"],
              Configuration["FileManager:User"],
              Configuration["FileManager:Password"],
              a.GetService<IWebHostEnvironment>()));
            services.AddSingleton<IMailService, MailService>();
            services.AddSingleton<IPdfGenerator, PdfGenerator>();
            services.AddTransient<IDeviceDetector, Application.Commons.Services.DeviceDetector>();
            #endregion

            #region MvcConfig
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.AddControllers().AddNewtonsoftJson();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddCookie(options =>
                {
                    options.LoginPath = "/Account/Login";
                    options.LogoutPath = "/Account/Logout";
                    options.ClaimsIssuer = JwtBearerDefaults.AuthenticationScheme;
                })

            // Adding Jwt Bearer
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = Configuration["JWT:ValidAudience"],
                    ValidIssuer = Configuration["JWT:ValidIssuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Secret"]))
                };
            });
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
            services.AddIdentity<AppUser, IdentityRole<Guid>>()
                .AddUserManager<UserManager<AppUser>>()
                .AddSignInManager<SignInManager<AppUser>>()
                .AddRoleManager<RoleManager<IdentityRole<Guid>>>()
                .AddEntityFrameworkStores<AppUsersDbContext>()
                .AddDefaultTokenProviders();
            //.AddDefaultUI();
            #endregion

            services.ConfigureApplicationCookie(options =>
            {
                options.Events.OnRedirectToLogin = context =>
                {
                    context.Response.StatusCode = 401;

                    return Task.CompletedTask;
                };
            });

            #region AutoMapper
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddSingleton(AutoMapperConfig.RegisterMappings());
            #endregion

            services.AddMediatR(Assembly.GetExecutingAssembly());

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
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
                app.UseStatusCodePagesWithRedirects("/Errors/{0}");
            }
            var localizationOptions = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>().Value;

            app.UseSwagger();
            app.UseSwaggerUI();

            //app.UseHttpsRedirection();

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

            app.UseStatusCodePages();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                    name: "error",
                    pattern: "error/{statusCode}",
                    defaults: new { controller = "Error", action = "HandleError" });
            });
        }
    }
}
