using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietMealApp.DataAccessLayer.DbContextsFactory
{
    internal class AppUsersDbContextFactory : IDesignTimeDbContextFactory<AppUsersDbContext>
    {
        public AppUsersDbContext CreateDbContext(string[] args)
        {
            AppUsersDbContext dbContext = new AppUsersDbContext(new DbContextOptionsBuilder<AppUsersDbContext>()
                .UseSqlServer(
                    new ConfigurationBuilder()
                        .AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), $"appsettings.json"))
                        .Build()
                        .GetConnectionString("UsersDietMealDB")
                ).Options);

            return dbContext;
        }
    }
}
