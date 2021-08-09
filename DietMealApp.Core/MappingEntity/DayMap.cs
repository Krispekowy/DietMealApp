using DietMealApp.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DietMealApp.Core.MappingEntity
{
    public class DayMap
    {
        public DayMap(EntityTypeBuilder<Day> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.Name).IsRequired();
        }
    }
}
