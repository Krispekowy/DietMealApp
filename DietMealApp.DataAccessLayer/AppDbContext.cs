using DietMealApp.Core.Entities;
using DietMealApp.Core.MappingEntity;
using Microsoft.EntityFrameworkCore;
using System;

namespace DietMealApp.DataAccessLayer
{
    public sealed class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Meal> Meals { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<MealProduct> MealProducts { get; set; }
        public DbSet<DietDayMeals> DayDietMeals { get; set; }
        public DbSet<DietDay> DietDays { get; set; }
        public DbSet<Diet> Diets { get; set; }
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
