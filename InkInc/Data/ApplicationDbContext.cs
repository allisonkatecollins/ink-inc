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
        base.OnModelCreating(modelBuilder);
        User allison = new User {
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
        allison.PasswordHash = passwordHash.HashPassword (allison, "Admin8*");
        modelBuilder.Entity<User> ().HasData (allison);
        
        User asia = new User {
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
        passwordHash = new PasswordHasher<User> ();
        asia.PasswordHash = passwordHash.HashPassword (asia, "Admin8*");
        modelBuilder.Entity<User> ().HasData (asia);
        
        User brittany = new User {
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
        passwordHash = new PasswordHasher<User> ();
        brittany.PasswordHash = passwordHash.HashPassword (brittany, "Admin8*");
        modelBuilder.Entity<User> ().HasData (brittany);
        
        User mary = new User {
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
        passwordHash = new PasswordHasher<User> ();
        mary.PasswordHash = passwordHash.HashPassword (mary, "Admin8*");
        modelBuilder.Entity<User> ().HasData (mary);
        
        modelBuilder.Entity<Parlor> ().HasData (
            new Parlor () {
                ParlorId = 1,
                    OwnerId = allison.Id,
                    Name = "Black Dahlia Studios",
                    StreetAddress = "1200 Forest Ave",
                    City = "Nashville",
                    State = "Tennessee",
                    OpenTime = "9:00 AM",
                    CloseTime = "6:00 PM",
                    PhoneNumber = "(615)-555-5555",
                    DaysOpen = "Monday - Saturday"
            },
            new Parlor () {
                ParlorId = 2,
                    OwnerId = mary.Id,
                    Name = "Electric Hand",
                    StreetAddress = "300 Rainbow Dr",
                    City = "Nashville",
                    State = "Tennessee",
                    OpenTime = "10:00 AM",
                    CloseTime = "8:00 PM",
                    PhoneNumber = "(615)-555-5555",
                    DaysOpen = "Tuesday - Saturday"
            }
        );

            modelBuilder.Entity<Photo>().HasData(
                new Photo()
                {
                    Id = 1,
                    UserId = brittany.Id,
                    FilePath = "~/images/capybara1.jpg"
                },
                new Photo()
                {
                    Id = 2,
                    UserId = brittany.Id,
                    FilePath = "~/images/capybara2.jpg"
                },
                new Photo()
                {
                    Id = 3,
                    UserId = allison.Id,
                    FilePath = "~/images/jeff1.jpg"
                },
                new Photo()
                {
                    Id = 4,
                    UserId = allison.Id,
                    FilePath = "~/images/jeff2.jpg"
                },
                new Photo()
                {
                    Id = 5,
                    UserId = mary.Id,
                    FilePath = "~/images/tenn1.jpg"
                },
                new Photo()
                {
                    Id = 6,
                    UserId = mary.Id,
                    FilePath = "~/images/tenn2.jpg"
                },
                new Photo()
                {
                    Id = 7,
                    UserId = asia.Id,
                    FilePath = "~/images/wedding1.jpg"
                },
                new Photo()
                {
                    Id = 8,
                    UserId = asia.Id,
                    FilePath = "~/images/wedding2.jpg"
                }
                );
        }
    }
}
 