using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using DietMealApp.Core.Interfaces;
using DietMealApp.DataAccessLayer.Repositories;
using DietMealApp.DataAccessLayer.Interfaces;

namespace DietMealApp.DataAccessLayer
{
    public static class PersistenceWithEFRegistration
    {
        public static IServiceCollection AddDietMealAppPersistenceEFServices(this IServiceCollection services, IConfiguration configuration)
        {
            #region DataAccessLayerConfig
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration
                .GetConnectionString("DietMealAppDB")));

            services.AddDbContext<AppUsersDbContext>(options =>
                options.UseSqlServer(configuration
                .GetConnectionString("UsersDietMealDB")));
            #endregion

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IMealRepository, MealRepository>();

            return services;
        }
    }
}
