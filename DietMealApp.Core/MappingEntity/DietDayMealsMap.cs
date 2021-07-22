using DietMealApp.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DietMealApp.Core.MappingEntity
{
    public class DietDayMealsMap
    {
        public DietDayMealsMap(EntityTypeBuilder<DietDayMeals> entityBuilder)
        {
            entityBuilder
                .HasKey(t => new { t.DietDayId, t.MealId });
            entityBuilder
                .HasOne(t => t.DayDiet)
                .WithMany(a => a.DietDayMeals)
                .HasForeignKey(t => t.DietDayId);
            entityBuilder
                .HasOne(t => t.Meal)
                .WithMany(a => a.DietDayMeals)
                .HasForeignKey(t => t.MealId);
        }
    }
}
