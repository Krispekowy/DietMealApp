using DietMealApp.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietMealApp.Core.MappingEntity
{
    public class ShoppingListMap
    {
        public ShoppingListMap(EntityTypeBuilder<ShoppingList> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.HasMany(x => x.ShoppingListDays);
            entityBuilder.HasMany(x => x.ShoppingListMeals);
            entityBuilder.HasMany(x => x.ShoppingListProducts);
        }
    }
}
