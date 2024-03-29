﻿using DietMealApp.Core.Entities;
using DietMealApp.Core.Intersections;
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
        public DbSet<DayMeals> DayMeals { get; set; }
        public DbSet<DietDay> DietDays { get; set; }
        public DbSet<Day> Days { get; set; }
        public DbSet<Diet> Diets { get; set; }
        public DbSet<ShoppingList> ShoppingList { get; set; }
        public DbSet<ShoppingListProduct> ShoppingListProducts { get; set;}
        public DbSet<ShoppingListMeals> ShoppingListMeals { get; set; }
        public DbSet<ShoppingListDays> ShoppingListDays { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            new DayMap(modelBuilder.Entity<Day>());
            new DayMealsMap(modelBuilder.Entity<DayMeals>());
            new DietDayMap(modelBuilder.Entity<DietDay>());
            new DietMap(modelBuilder.Entity<Diet>());
            new MealMap(modelBuilder.Entity<Meal>());
            new MealProductMap(modelBuilder.Entity<MealProduct>());
            new ProductMap(modelBuilder.Entity<Product>());

            new ShoppingListMap(modelBuilder.Entity<ShoppingList>());
            new ShoppingListDayMap(modelBuilder.Entity<ShoppingListDays>());
            new ShoppingListMealMap(modelBuilder.Entity<ShoppingListMeals>());
            new ShoppingListProductMap(modelBuilder.Entity<ShoppingListProduct>());
        }
    }
}
