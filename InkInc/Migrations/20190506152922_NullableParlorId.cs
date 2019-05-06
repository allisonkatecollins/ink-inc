using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InkInc.Migrations
{
    public partial class NullableParlorId : Migration
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
                values: new object[] { 1, "Nashville", "6:00 PM", "Monday - Saturday", "Black Dahlia Studios", "9:00 AM", "af53e445-b90a-4935-89f3-cffb8435f249", "(615)-555-5555", "Tennessee", "1200 Forest Ave" });

            migrationBuilder.InsertData(
                table: "Parlor",
                columns: new[] { "ParlorId", "City", "CloseTime", "DaysOpen", "Name", "OpenTime", "OwnerId", "PhoneNumber", "State", "StreetAddress" },
                values: new object[] { 2, "Nashville", "8:00 PM", "Tuesday - Saturday", "Electric Hand", "10:00 AM", "be8dad1f-4124-413e-a613-7076c567cca9", "(615)-555-5555", "Tennessee", "300 Rainbow Dr" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BaselinePricing", "Biography", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "InstagramHandle", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "ParlorId", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PricePerHour", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "af53e445-b90a-4935-89f3-cffb8435f249", 0, 50, "I've been a tattoo artist for 10 years. I specialize in portrait pieces, particularly of Jeff Goldblum.", "cb41151f-7b40-43c2-918f-8d53dea43bf6", "allisonkatecollins@gmail.com", true, "Allison", "@allisonkatecollins", "Collins", false, null, "ALLISONKATECOLLINS@GMAIL.COM", null, 1, "AQAAAAEAACcQAAAAEKl5Kj4/McvuEQtKT1MYCSipDnbpmbyyDGO4wBKPi0ht/nCiYWo8q98kfxspdVduxw==", null, false, 80, "f65a6043-69a2-4858-94fe-6e3097ebcaba", false, null },
                    { "6b9d326a-0cab-4987-b9b8-a40069f1ca99", 0, 60, "I am inspired by the energy that bachelorette parties bring to Nashville, so I mostly do wedding themed tattoos.", "266482ec-0ccb-4a86-b9e4-e7e6868196ce", "asiacarter@gmail.com", true, "Asia", "@asiacarter", "Carter", false, null, "ASIACARTER@GMAIL.COM", null, 1, "AQAAAAEAACcQAAAAEGmvdwsMa4xvr66FeNEK0cUj0nN9/DNC7c98R6+pFpXTeMdYhn8nyqWXdUofAY1bbg==", null, false, 50, "da98a1ee-0c8a-41ca-a814-dbc37622b84a", false, null },
                    { "99a68705-1342-4d78-8e39-ef901709ae03", 0, 25, "I specialize in black-and-white tattoos of capybaras.", "dba0c404-db89-4d5b-a482-4bb2b90fcb9d", "brj@gmail.com", true, "Brittany", "@itsbrittany", "Ramos-Janeway", false, null, "BRJ@GMAIL.COM", null, 2, "AQAAAAEAACcQAAAAEDK/gq3OCGpwQJVTpf7HaooiSfIhANka6L6FTfm70GGL9ljfCqOkod9SouryYbEI3A==", null, false, 50, "4a5b93a5-ded5-4d49-baf1-6c4d935018f6", false, null },
                    { "be8dad1f-4124-413e-a613-7076c567cca9", 0, 100, "I grew up in Nashville and want to keep the Volunteer tradition alive. Ask me about my Rockytop Special.", "a3444fc9-e390-48b0-a8d2-57226a5d40fd", "maryremo@gmail.com", true, "Mary", "@sodajerk", "Remo", false, null, "MARYREMO@GMAIL.COM", null, 2, "AQAAAAEAACcQAAAAEAWC6ru5PVIeibf26XIyD/bzp7fGGC2XwawDC4e+nf8gni9zzyRHFltUH2Aaz9ueDA==", null, false, 60, "25b804e2-11d3-4f0a-aa09-399c8c1dcef0", false, null }
                });

            migrationBuilder.InsertData(
                table: "Photo",
                columns: new[] { "Id", "FilePath", "IsDisplayPhoto", "UserId" },
                values: new object[,]
                {
                    { 3, "~/images/jeff1.jpg", false, "af53e445-b90a-4935-89f3-cffb8435f249" },
                    { 4, "~/images/jeff2.jpg", false, "af53e445-b90a-4935-89f3-cffb8435f249" },
                    { 9, "~/images/jeff3.jpg", false, "af53e445-b90a-4935-89f3-cffb8435f249" },
                    { 10, "~/images/jeff4.jpg", false, "af53e445-b90a-4935-89f3-cffb8435f249" },
                    { 7, "~/images/wedding1.jpg", false, "6b9d326a-0cab-4987-b9b8-a40069f1ca99" },
                    { 8, "~/images/wedding2.jpg", false, "6b9d326a-0cab-4987-b9b8-a40069f1ca99" },
                    { 1, "~/images/capybara1.jpg", false, "99a68705-1342-4d78-8e39-ef901709ae03" },
                    { 2, "~/images/capybara2.jpg", false, "99a68705-1342-4d78-8e39-ef901709ae03" },
                    { 5, "~/images/tenn1.jpg", false, "be8dad1f-4124-413e-a613-7076c567cca9" },
                    { 6, "~/images/tenn2.jpg", false, "be8dad1f-4124-413e-a613-7076c567cca9" }
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
