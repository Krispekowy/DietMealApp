using DietMealApp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietMealApp.Core.MappingEntity
{
    public class AppUsersMap
    {
        public AppUsersMap(EntityTypeBuilder<AppUser> entityBuilder)
        {
            entityBuilder.HasKey(a => a.Id);
            entityBuilder.Property(e => e.LastEditDate).HasDefaultValueSql("getdate()");
        }
    }
}
