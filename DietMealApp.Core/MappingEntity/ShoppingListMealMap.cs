using DietMealApp.Core.Intersections;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietMealApp.Core.MappingEntity
{
    public class ShoppingListMealMap
    {
        public ShoppingListMealMap(EntityTypeBuilder<ShoppingListMeals> entityBuilder)
        {
            entityBuilder
                .HasKey(t => new { t.Id});
            entityBuilder
                .HasOne(t => t.Meal)
                .WithMany(a => a.ShoppingListMeals)
                .HasForeignKey(t => t.MealId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);
            entityBuilder
                .HasOne(t => t.ShoppingList)
                .WithMany(a => a.ShoppingListMeals)
                .HasForeignKey(t => t.ShoppingListId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);
        }
    }
}
