using ATSIdentity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ATSIdentity.Data
{
    public class AuthDbContext : IdentityDbContext
    {
        public AuthDbContext(DbContextOptions options) : base(options)
        {
        }
        DbSet<User> myUsers { get; set; }


        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);
        //    SeedRoles(builder);
        //}
        //private void SeedRoles(ModelBuilder builder)
        //{
        //    builder.Entity<IdentityRole>().HasData
        //        (
        //            new IdentityRole() { Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "Admin" },
        //            new IdentityRole() { Name = "User", ConcurrencyStamp = "2", NormalizedName = "User" },
        //            new IdentityRole() { Name = "HR", ConcurrencyStamp = "3", NormalizedName = "HR" }

        //        );

        //}
    }
}
