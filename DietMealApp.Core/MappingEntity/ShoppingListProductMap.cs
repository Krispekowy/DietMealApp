using DietMealApp.Core.Entities;
using DietMealApp.Core.Intersections;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DietMealApp.Core.MappingEntity
{
    public class ShoppingListProductMap
    {
        public ShoppingListProductMap(EntityTypeBuilder<ShoppingListProduct> entityBuilder)
        {
            entityBuilder
                .HasKey(t => new { t.ProductId, t.ShoppingListId });
            entityBuilder
                .HasOne(t => t.Product)
                .WithMany(a => a.ShoppingListProducts)
                .HasForeignKey(t => t.ProductId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);
            entityBuilder
                .HasOne(t => t.ShoppingList)
                .WithMany(a => a.ShoppingListProducts)
                .HasForeignKey(t => t.ShoppingListId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);
            entityBuilder
                .Property(t => t.Id).ValueGeneratedOnAdd();
        }
    }
}
