using DietMealApp.Core.Entities;
using DietMealApp.Core.Intersections;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DietMealApp.Core.MappingEntity
{
    public class MealProductMap
    {
        public MealProductMap(EntityTypeBuilder<MealProduct> entityBuilder)
        {
            entityBuilder
                .HasKey(t => new { t.MealId, t.ProductId });
            entityBuilder
                .HasOne(t => t.Meal)
                .WithMany(a => a.MealProducts)
                .HasForeignKey(t => t.MealId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);
            entityBuilder
                .HasOne(t => t.Product)
                .WithMany(a => a.MealProducts)
                .HasForeignKey(t => t.ProductId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);
            entityBuilder
                .Property(t => t.Id).ValueGeneratedOnAdd();
        }
    }
}
