using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InkInc.Migrations
{
    public partial class Update : Migration
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
                    Biography = table.Column<string>(maxLength: 500, nullable: true),
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
                values: new object[] { 1, "Nashville", "6:00 PM", "Monday - Saturday", "Black Dahlia Studios", "9:00 AM", "b3eb15c2-60e3-4a75-930e-ce1126778bd9", "(615)-555-5555", "Tennessee", "1200 Forest Ave" });

            migrationBuilder.InsertData(
                table: "Parlor",
                columns: new[] { "ParlorId", "City", "CloseTime", "DaysOpen", "Name", "OpenTime", "OwnerId", "PhoneNumber", "State", "StreetAddress" },
                values: new object[] { 2, "Nashville", "8:00 PM", "Tuesday - Saturday", "Electric Hand", "10:00 AM", "86cb57f5-e366-457b-a8f1-e8c3cb911892", "(615)-555-5555", "Tennessee", "300 Rainbow Dr" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BaselinePricing", "Biography", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "InstagramHandle", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "ParlorId", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PricePerHour", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "b3eb15c2-60e3-4a75-930e-ce1126778bd9", 0, 50, "I've been a tattoo artist for 10 years. I specialize in portrait pieces, particularly of Jeff Goldblum.", "4288c85c-df1d-4cd1-8150-3c7cb0dd5e62", "allisonkatecollins@gmail.com", true, "Allison", "@allisonkatecollins", "Collins", false, null, "ALLISONKATECOLLINS@GMAIL.COM", "ALLISONKATECOLLINS@GMAIL.COM", 1, "AQAAAAEAACcQAAAAEPI4NRigBeXDD4qysoSiwD1URk2ZmAYaRjhjR228nlH+mIdjZtwJRLSEHpTrFJmtfw==", null, false, 80, "91208fb2-f5a9-4c26-823f-d286f608e67d", false, "allisonkatecollins@gmail.com" },
                    { "1cff67a9-286c-444a-92cc-234ea71d700b", 0, 60, "I am inspired by the energy that bachelorette parties bring to Nashville, so I mostly do wedding themed tattoos.", "72ceff71-0ff5-4660-9144-6715931379dd", "asiacarter@gmail.com", true, "Asia", "@asiacarter", "Carter", false, null, "ASIACARTER@GMAIL.COM", "ASIACARTER@GMAIL.COM", 1, "AQAAAAEAACcQAAAAEMpup/BL74qWE8jLoHBpSi40uGkHwaGPKR/TJZujoqPLwyUK4YCIdCSzaXWbFsSBQA==", null, false, 50, "d1cbb227-6b35-46d5-8cef-6ba7306b9ea8", false, "asiacarter@gmail.com" },
                    { "3ead6e01-b4d0-48ef-8ff7-41316de76fcb", 0, 25, "I specialize in black-and-white tattoos of capybaras.", "6b96744e-e340-47e6-96bf-8a094afbe151", "brj@gmail.com", true, "Brittany", "@itsbrittany", "Ramos-Janeway", false, null, "BRJ@GMAIL.COM", "BRJ@GMAIL.COM", 2, "AQAAAAEAACcQAAAAEDuwhiYiRslo9gyt7v87an0JN6AT4hkaXizvypf6eakxz4BT4VCvmYqP45gR1+6K7Q==", null, false, 50, "6e77b084-77ec-4b39-bedf-4ce8b1890de9", false, "brj@gmail.com" },
                    { "86cb57f5-e366-457b-a8f1-e8c3cb911892", 0, 100, "I grew up in Nashville and want to keep the Volunteer tradition alive. Ask me about my Rockytop Special.", "9db07874-13e3-4f3c-b369-a6e6c5610d35", "maryremo@gmail.com", true, "Mary", "@sodajerk", "Remo", false, null, "MARYREMO@GMAIL.COM", "MARYREMO@GMAIL.COM", 2, "AQAAAAEAACcQAAAAENflSSBV3/4b8gBs1b41w0fOw2Ti12u/FZbqrErpkdlzR84UXGecVmOL9N9X13vDqw==", null, false, 60, "6be2bc08-4d07-4201-bc36-bf080a77361e", false, "maryremo@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "Photo",
                columns: new[] { "Id", "FilePath", "IsDisplayPhoto", "UserId" },
                values: new object[,]
                {
                    { 3, "~/images/jeff1.jpg", false, "b3eb15c2-60e3-4a75-930e-ce1126778bd9" },
                    { 4, "~/images/jeff2.jpg", false, "b3eb15c2-60e3-4a75-930e-ce1126778bd9" },
                    { 9, "~/images/jeff3.jpg", false, "b3eb15c2-60e3-4a75-930e-ce1126778bd9" },
                    { 10, "~/images/jeff4.jpg", false, "b3eb15c2-60e3-4a75-930e-ce1126778bd9" },
                    { 7, "~/images/wedding1.jpg", false, "1cff67a9-286c-444a-92cc-234ea71d700b" },
                    { 8, "~/images/wedding2.jpg", false, "1cff67a9-286c-444a-92cc-234ea71d700b" },
                    { 1, "~/images/capybara1.jpg", false, "3ead6e01-b4d0-48ef-8ff7-41316de76fcb" },
                    { 2, "~/images/capybara2.jpg", false, "3ead6e01-b4d0-48ef-8ff7-41316de76fcb" },
                    { 5, "~/images/tenn1.jpg", false, "86cb57f5-e366-457b-a8f1-e8c3cb911892" },
                    { 6, "~/images/tenn2.jpg", false, "86cb57f5-e366-457b-a8f1-e8c3cb911892" }
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
