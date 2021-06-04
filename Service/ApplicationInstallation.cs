using DietMealApp.Core.Mappings;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DietMealApp.Application
{
    public static class ApplicationInstallation
    {
        public static IServiceCollection AddDietMealApp(this IServiceCollection services)
        {
            #region AutoMapper
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddSingleton(AutoMapperConfig.RegisterMappings());
            #endregion

            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
