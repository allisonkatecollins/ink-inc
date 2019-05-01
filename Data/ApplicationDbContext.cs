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
        public DbSet<Photo> Photo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        User user = new User {
            FirstName = "Allison",
            LastName = "Collins",
            Email = "allisonkatecollins@gmail.com",
            NormalizedEmail = "ALLISONKATECOLLINS@GMAIL.COM",
            BaselinePricing = 50,
            PricePerHour = 40,
            InstagramHandle = "@allisonkatecollins",
            Biography = "I've been a tattoo artist for 10 years. I specialize in portrait pieces, particularly of Jeff Goldblum.",
            ParlorId = 1,
            EmailConfirmed = true,
            LockoutEnabled = false,
            SecurityStamp = Guid.NewGuid ().ToString ("D")
        };
        var passwordHash = new PasswordHasher<User> ();
        user.PasswordHash = passwordHash.HashPassword (user, "Admin8*");
        modelBuilder.Entity<User> ().HasData (user);
        
        User user = new User {
            FirstName = "Asia",
            LastName = "Carter",
            Email = "asiacarter@gmail.com",
            NormalizedEmail = "ASIACARTER@GMAIL.COM",
            BaselinePricing = 60,
            PricePerHour = 50,
            InstagramHandle = "@asiacarter",
            Biography = "I am inspired by the energy that bachelorette parties bring to Nashville, so I mostly do wedding themed tattoos.",
            ParlorId = 1,
            EmailConfirmed = true,
            LockoutEnabled = false,
            SecurityStamp = Guid.NewGuid ().ToString ("D")
        };
        var passwordHash = new PasswordHasher<User> ();
        user.PasswordHash = passwordHash.HashPassword (user, "Admin8*");
        modelBuilder.Entity<User> ().HasData (user);
        
        User user = new User {
            FirstName = "Brittany",
            LastName = "Ramos-Janeway",
            Email = "brj@gmail.com",
            NormalizedEmail = "BRJ@GMAIL.COM",
            BaselinePricing = 25,
            PricePerHour = 50,
            InstagramHandle = "@itsbrittany",
            Biography = "I specialize in black-and-white tattoos of capybaras.",
            ParlorId = 2,
            EmailConfirmed = true,
            LockoutEnabled = false,
            SecurityStamp = Guid.NewGuid ().ToString ("D")
        };
        var passwordHash = new PasswordHasher<User> ();
        user.PasswordHash = passwordHash.HashPassword (user, "Admin8*");
        modelBuilder.Entity<User> ().HasData (user);
        
        User user = new User {
            FirstName = "Mary",
            LastName = "Remo",
            Email = "maryremo@gmail.com",
            NormalizedEmail = "MARYREMO@GMAIL.COM",
            BaselinePricing = 100,
            PricePerHour = 60,
            InstagramHandle = "@sodajerk",
            Biography = "I grew up in Nashville and want to keep the Volunteer tradition alive. Ask me about my Rockytop Special.",
            ParlorId = 2,
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
 