using DietMealApp.Core.Entities;
using DietMealApp.Core.MappingEntity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietMealApp.DataAccessLayer
{
    public sealed class AppUsersDbContext : IdentityDbContext<AppUser, IdentityRole<Guid>, Guid>
    {
        public AppUsersDbContext(DbContextOptions<AppUsersDbContext> options)
            : base(options)
        {
        }
        public DbSet<AppUser> AppUsers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new AppUsersMap(modelBuilder.Entity<AppUser>());
        }
        
    }
}
