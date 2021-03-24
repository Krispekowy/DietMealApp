using DietMealApp.Core.Entities;
using DietMealApp.Core.MappingEntity;
using Microsoft.EntityFrameworkCore;
using System;

namespace DietMealApp.DataAccessLayer
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new DietDayMap(modelBuilder.Entity<DietDay>());
            new DietDayMealsMap(modelBuilder.Entity<DietDayMeals>());
            new MealMap(modelBuilder.Entity<Meal>());
            new MealProductMap(modelBuilder.Entity<MealProduct>());
            new ProductMap(modelBuilder.Entity<Product>());
        }
    }
}
