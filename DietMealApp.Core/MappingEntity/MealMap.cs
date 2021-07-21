using DietMealApp.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DietMealApp.Core.MappingEntity
{
    public class MealMap
    {
        public MealMap(EntityTypeBuilder<Meal> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.MealName).IsRequired();
            entityBuilder.Property(t => t.TypeOfMeal).IsRequired();
            entityBuilder.HasMany(t => t.MealProducts);
        }
    }
}
