using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Diagnostics;
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
            
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .ConfigureWarnings(warnings =>
                    warnings.Throw(RelationalEventId.MultipleCollectionIncludeWarning));

            options.UseSqlServer(options => options.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery));
            AppDbContext dbContext = new AppDbContext(options
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
