using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DietMealApp.Core.Entities;

namespace DietMealApp.Core.MappingEntity
{
    public class ProductMap
    {
        public ProductMap(EntityTypeBuilder<Product> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.ProductName).IsRequired();
            entityBuilder.Property(t => t.Category).IsRequired();
        }
    }
}
