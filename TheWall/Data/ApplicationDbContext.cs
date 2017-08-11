using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TheWall.Models;
using System.Data.SqlTypes;

namespace TheWall.Data
{

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {


            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);


            // This was needed when using 8.0.8-* but switching to 7.0.7 does not require them.
            // builder.Entity<IdentityRole>().Property(i => i.NormalizedName).HasColumnType("varchar(256)");
            // builder.Entity<ApplicationUser>().Property(i => i.NormalizedEmail).HasColumnType("varchar(256)");
            // builder.Entity<ApplicationUser>().Property(i => i.NormalizedUserName).HasColumnType("varchar(256)");
        }
    }
}
