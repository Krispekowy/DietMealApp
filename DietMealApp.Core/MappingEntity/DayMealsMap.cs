using DietMealApp.Core.Entities;
using DietMealApp.Core.Intersections;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DietMealApp.Core.MappingEntity
{
    public class DayMealsMap
    {
        public DayMealsMap(EntityTypeBuilder<DayMeals> entityBuilder)
        {
            entityBuilder
                .HasKey(t => new { t.DayId, t.MealId });
            entityBuilder
                .HasOne(t => t.Day)
                .WithMany(a => a.DayMeals)
                .HasForeignKey(t => t.DayId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);
            entityBuilder
                .HasOne(t => t.Meal)
                .WithMany(a => a.DayMeals)
                .HasForeignKey(t => t.MealId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);
            entityBuilder
                .Property(t => t.Id).ValueGeneratedOnAdd();
        }
    }
}
