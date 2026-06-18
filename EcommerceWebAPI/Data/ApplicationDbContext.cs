using EcommerceWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EcommerceWebAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserRole>()
                .HasKey(ur => new { ur.UserId, ur.RoleId });

            modelBuilder.Entity<UserRole>()
                .HasOne(my => my.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(my => my.UserId);

            modelBuilder.Entity<UserRole>()
                .HasOne(my => my.Role)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(my => my.RoleId);
        }
    }
}
