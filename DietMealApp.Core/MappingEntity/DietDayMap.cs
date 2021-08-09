using DietMealApp.Core.Entities;
using DietMealApp.Core.Intersections;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietMealApp.Core.MappingEntity
{
    public class DietDayMap
    {
        public DietDayMap(EntityTypeBuilder<DietDay> entityBuilder)
        {
            entityBuilder
                .HasKey(t => new { t.DayId, t.DietId });
            entityBuilder
                .HasOne(t => t.Day)
                .WithMany(a => a.DietDays)
                .HasForeignKey(t => t.DayId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);
            entityBuilder
                .HasOne(t => t.Diet)
                .WithMany(a => a.DietDays)
                .HasForeignKey(t => t.DietId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);
        }
    }
}
