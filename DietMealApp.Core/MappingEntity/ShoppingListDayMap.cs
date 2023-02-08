using DietMealApp.Core.Intersections;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietMealApp.Core.MappingEntity
{
    public class ShoppingListDayMap
    {
        public ShoppingListDayMap(EntityTypeBuilder<ShoppingListDays> entityBuilder)
        {
            entityBuilder
                .HasKey(t => new { t.DayId, t.ShoppingListId });
            entityBuilder
                .HasOne(t => t.Day)
                .WithMany(a => a.ShoppingListDays)
                .HasForeignKey(t => t.DayId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);
            entityBuilder
                .HasOne(t => t.ShoppingList)
                .WithMany(a => a.ShoppingListDays)
                .HasForeignKey(t => t.ShoppingListId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);
        }
    }
}
