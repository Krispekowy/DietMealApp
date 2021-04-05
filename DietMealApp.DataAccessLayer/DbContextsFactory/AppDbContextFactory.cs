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
    internal class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            AppDbContext dbContext = new AppDbContext(new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlServer(
                    new ConfigurationBuilder()
                        .AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), $"appsettings.json"))
                        .Build()
                        .GetConnectionString("DietMealAppDB")
                ).Options);

            return dbContext;
        }
    }
}
