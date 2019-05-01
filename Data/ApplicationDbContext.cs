using System;
using System.Collections.Generic;
using System.Text;
using InkInc.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InkInc.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<User> User { get; set; }
        public DbSet<Parlor> Parlor { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        User user = new User {
            FirstName = "admin",
            LastName = "admin",
            Email = "admin@admin.com",
            NormalizedEmail = "ADMIN@ADMIN.COM",
            EmailConfirmed = true,
            LockoutEnabled = false,
            SecurityStamp = Guid.NewGuid ().ToString ("D")
        };
        var passwordHash = new PasswordHasher<User> ();
        user.PasswordHash = passwordHash.HashPassword (user, "Admin8*");
        modelBuilder.Entity<User> ().HasData (user);
        
        modelBuilder.Entity<Parlor> ().HasData (
            new Parlor () {
                ParlorId = 1,
                    OwnerId = user.Id,
                    Name = "Black Dahlia Studios",
                    StreetAddress = "1200 Forest Ave",
                    City = "Nashville",
                    State = "Tennessee",
                    OpenTime = "9:00 AM",
                    CloseTime = "6:00 PM",
                    DaysOpen = "Monday - Saturday"
            },
            new Parlor () {
                ParlorId = 2,
                    OwnerId = user.Id,
                    Name = "Electric Hand",
                    StreetAddress = "300 Rainbow Dr",
                    City = "Nashville",
                    State = "Tennessee",
                    OpenTime = "10:00 AM",
                    CloseTime = "8:00 PM",
                    DaysOpen = "Tuesday - Saturday"
            }
        );
        }
    }
}
 