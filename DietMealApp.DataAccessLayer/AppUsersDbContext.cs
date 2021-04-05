using DietMealApp.Core.Entities;
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
    }
}
