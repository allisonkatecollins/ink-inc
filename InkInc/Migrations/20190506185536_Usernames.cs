using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InkInc.Migrations
{
    public partial class Usernames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Parlor",
                columns: table => new
                {
                    ParlorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    StreetAddress = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: false),
                    State = table.Column<string>(nullable: false),
                    OpenTime = table.Column<string>(nullable: false),
                    CloseTime = table.Column<string>(nullable: false),
                    DaysOpen = table.Column<string>(nullable: false),
                    OwnerId = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parlor", x => x.ParlorId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    BaselinePricing = table.Column<int>(nullable: false),
                    PricePerHour = table.Column<int>(nullable: false),
                    InstagramHandle = table.Column<string>(nullable: true),
                    Biography = table.Column<string>(nullable: true),
                    ParlorId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Parlor_ParlorId",
                        column: x => x.ParlorId,
                        principalTable: "Parlor",
                        principalColumn: "ParlorId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Photo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FilePath = table.Column<string>(nullable: true),
                    IsDisplayPhoto = table.Column<bool>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photo_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Parlor",
                columns: new[] { "ParlorId", "City", "CloseTime", "DaysOpen", "Name", "OpenTime", "OwnerId", "PhoneNumber", "State", "StreetAddress" },
                values: new object[] { 1, "Nashville", "6:00 PM", "Monday - Saturday", "Black Dahlia Studios", "9:00 AM", "f19f4d27-e255-4816-a0c2-ccaa04bfe105", "(615)-555-5555", "Tennessee", "1200 Forest Ave" });

            migrationBuilder.InsertData(
                table: "Parlor",
                columns: new[] { "ParlorId", "City", "CloseTime", "DaysOpen", "Name", "OpenTime", "OwnerId", "PhoneNumber", "State", "StreetAddress" },
                values: new object[] { 2, "Nashville", "8:00 PM", "Tuesday - Saturday", "Electric Hand", "10:00 AM", "93d8126a-03d9-4a79-9027-6ea9862c6470", "(615)-555-5555", "Tennessee", "300 Rainbow Dr" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BaselinePricing", "Biography", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "InstagramHandle", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "ParlorId", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PricePerHour", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "f19f4d27-e255-4816-a0c2-ccaa04bfe105", 0, 50, "I've been a tattoo artist for 10 years. I specialize in portrait pieces, particularly of Jeff Goldblum.", "bff132b5-a603-4bb4-b958-aa9a97ba980d", "allisonkatecollins@gmail.com", true, "Allison", "@allisonkatecollins", "Collins", false, null, "ALLISONKATECOLLINS@GMAIL.COM", "ALLISONKATECOLLINS@GMAIL.COM", 1, "AQAAAAEAACcQAAAAEIvz2eruJpQsLfINv9D0BFyU6RCY2YHl9AzhmQcztG4UVvkIe55MF92hlShDcGqz2w==", null, false, 80, "8b9ffa5a-482a-4147-88db-b652f29c0723", false, "allisonkatecollins@gmail.com" },
                    { "13b4a77e-b879-4d91-9642-73ed1b086f75", 0, 60, "I am inspired by the energy that bachelorette parties bring to Nashville, so I mostly do wedding themed tattoos.", "030265bd-9560-4f7e-b24c-50fd24da30ae", "asiacarter@gmail.com", true, "Asia", "@asiacarter", "Carter", false, null, "ASIACARTER@GMAIL.COM", "ASIACARTER@GMAIL.COM", 1, "AQAAAAEAACcQAAAAEIcGFWRBcquNGQzpRZmwbm3FF/dbPBdqKDwLK6sWuClIJq2ORFl8OWRCRYDFUfJawQ==", null, false, 50, "41eeeeb6-073b-4209-8924-575cb04ee0e1", false, "asiacarter@gmail.com" },
                    { "f408803c-e445-4600-b63b-cbce72e8ce56", 0, 25, "I specialize in black-and-white tattoos of capybaras.", "7b746332-0e20-4ece-929a-6ab468af64e6", "brj@gmail.com", true, "Brittany", "@itsbrittany", "Ramos-Janeway", false, null, "BRJ@GMAIL.COM", "BRJ@GMAIL.COM", 2, "AQAAAAEAACcQAAAAEACQtDnW9JfWL1ZXFI3RYci0UfxEGtUeUDGQ/eS3s060aYKhFELnEdIUbZX/K5gwPg==", null, false, 50, "8b3805ff-e50d-4c54-8e17-9f9ff44107a6", false, "brj@gmail.com" },
                    { "93d8126a-03d9-4a79-9027-6ea9862c6470", 0, 100, "I grew up in Nashville and want to keep the Volunteer tradition alive. Ask me about my Rockytop Special.", "527c28a8-11d4-4fd0-b54b-5569eb57d251", "maryremo@gmail.com", true, "Mary", "@sodajerk", "Remo", false, null, "MARYREMO@GMAIL.COM", "MARYREMO@GMAIL.COM", 2, "AQAAAAEAACcQAAAAEDKV8mJXsNeU+TDAGJ301m6BssCWms1mNMn+hksQV8QW3UvdJ3bO9MlsX51rCBWz7Q==", null, false, 60, "b2d3346a-112e-4922-8a3e-20bf1b594a21", false, "maryremo@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "Photo",
                columns: new[] { "Id", "FilePath", "IsDisplayPhoto", "UserId" },
                values: new object[,]
                {
                    { 3, "~/images/jeff1.jpg", false, "f19f4d27-e255-4816-a0c2-ccaa04bfe105" },
                    { 4, "~/images/jeff2.jpg", false, "f19f4d27-e255-4816-a0c2-ccaa04bfe105" },
                    { 9, "~/images/jeff3.jpg", false, "f19f4d27-e255-4816-a0c2-ccaa04bfe105" },
                    { 10, "~/images/jeff4.jpg", false, "f19f4d27-e255-4816-a0c2-ccaa04bfe105" },
                    { 7, "~/images/wedding1.jpg", false, "13b4a77e-b879-4d91-9642-73ed1b086f75" },
                    { 8, "~/images/wedding2.jpg", false, "13b4a77e-b879-4d91-9642-73ed1b086f75" },
                    { 1, "~/images/capybara1.jpg", false, "f408803c-e445-4600-b63b-cbce72e8ce56" },
                    { 2, "~/images/capybara2.jpg", false, "f408803c-e445-4600-b63b-cbce72e8ce56" },
                    { 5, "~/images/tenn1.jpg", false, "93d8126a-03d9-4a79-9027-6ea9862c6470" },
                    { 6, "~/images/tenn2.jpg", false, "93d8126a-03d9-4a79-9027-6ea9862c6470" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ParlorId",
                table: "AspNetUsers",
                column: "ParlorId");

            migrationBuilder.CreateIndex(
                name: "IX_Photo_UserId",
                table: "Photo",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Photo");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Parlor");
        }
    }
}
