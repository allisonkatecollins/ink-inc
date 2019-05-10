﻿// <auto-generated />
using System;
using InkInc.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace InkInc.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("InkInc.Models.Parlor", b =>
                {
                    b.Property<int>("ParlorId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .IsRequired();

                    b.Property<string>("CloseTime")
                        .IsRequired();

                    b.Property<string>("DaysOpen")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("OpenTime")
                        .IsRequired();

                    b.Property<string>("OwnerId")
                        .IsRequired();

                    b.Property<string>("PhoneNumber");

                    b.Property<string>("State")
                        .IsRequired();

                    b.Property<string>("StreetAddress")
                        .IsRequired();

                    b.HasKey("ParlorId");

                    b.ToTable("Parlor");

                    b.HasData(
                        new
                        {
                            ParlorId = 1,
                            City = "Nashville",
                            CloseTime = "6:00 PM",
                            DaysOpen = "Monday - Saturday",
                            Name = "Black Dahlia Studios",
                            OpenTime = "9:00 AM",
                            OwnerId = "b3eb15c2-60e3-4a75-930e-ce1126778bd9",
                            PhoneNumber = "(615)-555-5555",
                            State = "Tennessee",
                            StreetAddress = "1200 Forest Ave"
                        },
                        new
                        {
                            ParlorId = 2,
                            City = "Nashville",
                            CloseTime = "8:00 PM",
                            DaysOpen = "Tuesday - Saturday",
                            Name = "Electric Hand",
                            OpenTime = "10:00 AM",
                            OwnerId = "86cb57f5-e366-457b-a8f1-e8c3cb911892",
                            PhoneNumber = "(615)-555-5555",
                            State = "Tennessee",
                            StreetAddress = "300 Rainbow Dr"
                        });
                });

            modelBuilder.Entity("InkInc.Models.Photo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FilePath");

                    b.Property<bool>("IsDisplayPhoto");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Photo");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FilePath = "~/images/capybara1.jpg",
                            IsDisplayPhoto = false,
                            UserId = "3ead6e01-b4d0-48ef-8ff7-41316de76fcb"
                        },
                        new
                        {
                            Id = 2,
                            FilePath = "~/images/capybara2.jpg",
                            IsDisplayPhoto = false,
                            UserId = "3ead6e01-b4d0-48ef-8ff7-41316de76fcb"
                        },
                        new
                        {
                            Id = 3,
                            FilePath = "~/images/jeff1.jpg",
                            IsDisplayPhoto = false,
                            UserId = "b3eb15c2-60e3-4a75-930e-ce1126778bd9"
                        },
                        new
                        {
                            Id = 4,
                            FilePath = "~/images/jeff2.jpg",
                            IsDisplayPhoto = false,
                            UserId = "b3eb15c2-60e3-4a75-930e-ce1126778bd9"
                        },
                        new
                        {
                            Id = 5,
                            FilePath = "~/images/tenn1.jpg",
                            IsDisplayPhoto = false,
                            UserId = "86cb57f5-e366-457b-a8f1-e8c3cb911892"
                        },
                        new
                        {
                            Id = 6,
                            FilePath = "~/images/tenn2.jpg",
                            IsDisplayPhoto = false,
                            UserId = "86cb57f5-e366-457b-a8f1-e8c3cb911892"
                        },
                        new
                        {
                            Id = 7,
                            FilePath = "~/images/wedding1.jpg",
                            IsDisplayPhoto = false,
                            UserId = "1cff67a9-286c-444a-92cc-234ea71d700b"
                        },
                        new
                        {
                            Id = 8,
                            FilePath = "~/images/wedding2.jpg",
                            IsDisplayPhoto = false,
                            UserId = "1cff67a9-286c-444a-92cc-234ea71d700b"
                        },
                        new
                        {
                            Id = 9,
                            FilePath = "~/images/jeff3.jpg",
                            IsDisplayPhoto = false,
                            UserId = "b3eb15c2-60e3-4a75-930e-ce1126778bd9"
                        },
                        new
                        {
                            Id = 10,
                            FilePath = "~/images/jeff4.jpg",
                            IsDisplayPhoto = false,
                            UserId = "b3eb15c2-60e3-4a75-930e-ce1126778bd9"
                        });
                });

            modelBuilder.Entity("InkInc.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<int>("BaselinePricing");

                    b.Property<string>("Biography")
                        .HasMaxLength(500);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("InstagramHandle");

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<int?>("ParlorId");

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<int>("PricePerHour");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex("ParlorId");

                    b.ToTable("AspNetUsers");

                    b.HasData(
                        new
                        {
                            Id = "b3eb15c2-60e3-4a75-930e-ce1126778bd9",
                            AccessFailedCount = 0,
                            BaselinePricing = 50,
                            Biography = "I've been a tattoo artist for 10 years. I specialize in portrait pieces, particularly of Jeff Goldblum.",
                            ConcurrencyStamp = "4288c85c-df1d-4cd1-8150-3c7cb0dd5e62",
                            Email = "allisonkatecollins@gmail.com",
                            EmailConfirmed = true,
                            FirstName = "Allison",
                            InstagramHandle = "@allisonkatecollins",
                            LastName = "Collins",
                            LockoutEnabled = false,
                            NormalizedEmail = "ALLISONKATECOLLINS@GMAIL.COM",
                            NormalizedUserName = "ALLISONKATECOLLINS@GMAIL.COM",
                            ParlorId = 1,
                            PasswordHash = "AQAAAAEAACcQAAAAEPI4NRigBeXDD4qysoSiwD1URk2ZmAYaRjhjR228nlH+mIdjZtwJRLSEHpTrFJmtfw==",
                            PhoneNumberConfirmed = false,
                            PricePerHour = 80,
                            SecurityStamp = "91208fb2-f5a9-4c26-823f-d286f608e67d",
                            TwoFactorEnabled = false,
                            UserName = "allisonkatecollins@gmail.com"
                        },
                        new
                        {
                            Id = "1cff67a9-286c-444a-92cc-234ea71d700b",
                            AccessFailedCount = 0,
                            BaselinePricing = 60,
                            Biography = "I am inspired by the energy that bachelorette parties bring to Nashville, so I mostly do wedding themed tattoos.",
                            ConcurrencyStamp = "72ceff71-0ff5-4660-9144-6715931379dd",
                            Email = "asiacarter@gmail.com",
                            EmailConfirmed = true,
                            FirstName = "Asia",
                            InstagramHandle = "@asiacarter",
                            LastName = "Carter",
                            LockoutEnabled = false,
                            NormalizedEmail = "ASIACARTER@GMAIL.COM",
                            NormalizedUserName = "ASIACARTER@GMAIL.COM",
                            ParlorId = 1,
                            PasswordHash = "AQAAAAEAACcQAAAAEMpup/BL74qWE8jLoHBpSi40uGkHwaGPKR/TJZujoqPLwyUK4YCIdCSzaXWbFsSBQA==",
                            PhoneNumberConfirmed = false,
                            PricePerHour = 50,
                            SecurityStamp = "d1cbb227-6b35-46d5-8cef-6ba7306b9ea8",
                            TwoFactorEnabled = false,
                            UserName = "asiacarter@gmail.com"
                        },
                        new
                        {
                            Id = "3ead6e01-b4d0-48ef-8ff7-41316de76fcb",
                            AccessFailedCount = 0,
                            BaselinePricing = 25,
                            Biography = "I specialize in black-and-white tattoos of capybaras.",
                            ConcurrencyStamp = "6b96744e-e340-47e6-96bf-8a094afbe151",
                            Email = "brj@gmail.com",
                            EmailConfirmed = true,
                            FirstName = "Brittany",
                            InstagramHandle = "@itsbrittany",
                            LastName = "Ramos-Janeway",
                            LockoutEnabled = false,
                            NormalizedEmail = "BRJ@GMAIL.COM",
                            NormalizedUserName = "BRJ@GMAIL.COM",
                            ParlorId = 2,
                            PasswordHash = "AQAAAAEAACcQAAAAEDuwhiYiRslo9gyt7v87an0JN6AT4hkaXizvypf6eakxz4BT4VCvmYqP45gR1+6K7Q==",
                            PhoneNumberConfirmed = false,
                            PricePerHour = 50,
                            SecurityStamp = "6e77b084-77ec-4b39-bedf-4ce8b1890de9",
                            TwoFactorEnabled = false,
                            UserName = "brj@gmail.com"
                        },
                        new
                        {
                            Id = "86cb57f5-e366-457b-a8f1-e8c3cb911892",
                            AccessFailedCount = 0,
                            BaselinePricing = 100,
                            Biography = "I grew up in Nashville and want to keep the Volunteer tradition alive. Ask me about my Rockytop Special.",
                            ConcurrencyStamp = "9db07874-13e3-4f3c-b369-a6e6c5610d35",
                            Email = "maryremo@gmail.com",
                            EmailConfirmed = true,
                            FirstName = "Mary",
                            InstagramHandle = "@sodajerk",
                            LastName = "Remo",
                            LockoutEnabled = false,
                            NormalizedEmail = "MARYREMO@GMAIL.COM",
                            NormalizedUserName = "MARYREMO@GMAIL.COM",
                            ParlorId = 2,
                            PasswordHash = "AQAAAAEAACcQAAAAENflSSBV3/4b8gBs1b41w0fOw2Ti12u/FZbqrErpkdlzR84UXGecVmOL9N9X13vDqw==",
                            PhoneNumberConfirmed = false,
                            PricePerHour = 60,
                            SecurityStamp = "6be2bc08-4d07-4201-bc36-bf080a77361e",
                            TwoFactorEnabled = false,
                            UserName = "maryremo@gmail.com"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("InkInc.Models.Photo", b =>
                {
                    b.HasOne("InkInc.Models.User")
                        .WithMany("Photos")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("InkInc.Models.User", b =>
                {
                    b.HasOne("InkInc.Models.Parlor", "Parlor")
                        .WithMany("Users")
                        .HasForeignKey("ParlorId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("InkInc.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("InkInc.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("InkInc.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("InkInc.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
