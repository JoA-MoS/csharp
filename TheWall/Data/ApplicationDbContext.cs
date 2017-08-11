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
        public DbSet<Message> Messages { get; set; }
        public DbSet<Comment> Comments { get; set; }
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

            builder.Entity<Comment>()
                .HasOne(c => c.Message)
                .WithMany(m => m.Comments)
                .HasForeignKey(c => c.MessageId)
                .HasConstraintName("ForeignKey_Comment_Message");

            builder.Entity<Comment>()
                .HasOne(c => c.User)
                .WithMany(u => u.Comments)
                .HasForeignKey(c => c.UserId)
                .HasConstraintName("ForeignKey_Comment_User");

            builder.Entity<Message>()
                .HasOne(m => m.User)
                .WithMany(u => u.Messages)
                .HasForeignKey(m => m.UserId)
                .HasConstraintName("ForeignKey_Message_User");

        }
    }
}
