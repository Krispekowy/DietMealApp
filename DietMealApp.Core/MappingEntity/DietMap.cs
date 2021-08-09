using DietMealApp.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietMealApp.Core.MappingEntity
{
    public class DietMap
    {
        public DietMap(EntityTypeBuilder<Diet> entityBuilder)
        {
            entityBuilder
                .HasKey(t => t.Id);
            entityBuilder
                .HasMany(t => t.DietDays);
        }
    }
}
