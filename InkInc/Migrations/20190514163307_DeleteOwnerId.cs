using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InkInc.Migrations
{
    public partial class DeleteOwnerId : Migration
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
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BaselinePricing", "Biography", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "InstagramHandle", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "ParlorId", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PricePerHour", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "0402a486-a1f7-4eaf-96ef-66dc25142242", 0, 100, "I grew up in Nashville and want to keep the Volunteer tradition alive. Ask me about my Rockytop Special.", "16fe4bb9-b6bf-49e4-89ae-ae9781ba95a4", "maryremo@gmail.com", true, "Mary", "@sodajerk", "Remo", false, null, "MARYREMO@GMAIL.COM", "MARYREMO@GMAIL.COM", null, "AQAAAAEAACcQAAAAEBti2SvSxwycc8QiOz+FiCqgwu0RELqdXbbteZm3aSbHGGLCb5UDtxk4nOk22pFGbg==", null, false, 60, "fcb926f1-2c5d-4372-8df3-0a9b9c33d7c6", false, "maryremo@gmail.com" });

            migrationBuilder.InsertData(
                table: "Parlor",
                columns: new[] { "ParlorId", "City", "CloseTime", "DaysOpen", "Name", "OpenTime", "PhoneNumber", "State", "StreetAddress" },
                values: new object[] { 2, "Nashville", "8:00 PM", "Tuesday - Saturday", "Electric Hand", "10:00 AM", "(615)-555-5555", "Tennessee", "300 Rainbow Dr" });

            migrationBuilder.InsertData(
                table: "Parlor",
                columns: new[] { "ParlorId", "City", "CloseTime", "DaysOpen", "Name", "OpenTime", "PhoneNumber", "State", "StreetAddress" },
                values: new object[] { 1, "Atlanta", "6:00 PM", "Monday - Saturday", "Black Dahlia Studios", "9:00 AM", "(615)-555-5555", "Georgia", "1200 Forest Ave" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BaselinePricing", "Biography", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "InstagramHandle", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "ParlorId", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PricePerHour", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "9eb5a457-17b0-4f58-b76d-6f3448575733", 0, 50, "I've been a tattoo artist for 10 years. I specialize in portrait pieces, particularly of Jeff Goldblum.", "182192f3-4c66-4c73-b9d9-d1605fb23e2d", "allisonkatecollins@gmail.com", true, "Allison", "@allisonkatecollins", "Collins", false, null, "ALLISONKATECOLLINS@GMAIL.COM", "ALLISONKATECOLLINS@GMAIL.COM", 1, "AQAAAAEAACcQAAAAEM9RTf0ucc/4Gox8oeJFfdCPcR2yDTXudrs2WBzyolT23fVcAMZKnUYEbYmK/sfXwA==", null, false, 80, "7749e9db-9f06-47e5-9a7a-08f7d75d6a71", false, "allisonkatecollins@gmail.com" },
                    { "d5067774-8cf5-44c1-acba-cdf79c125414", 0, 60, "I am inspired by the energy that bachelorette parties bring to Nashville, so I mostly do wedding themed tattoos.", "e88d8834-25d0-4e78-9172-01d34fb014f8", "asiacarter@gmail.com", true, "Asia", "@asiacarter", "Carter", false, null, "ASIACARTER@GMAIL.COM", "ASIACARTER@GMAIL.COM", 1, "AQAAAAEAACcQAAAAEOluouyIA5otG9ORFcfjflzdF4nWrdvO229ZJsQkF+tzU1oiNNQD4qbDLd21rxypYw==", null, false, 50, "67a7c04f-1f09-4bf5-8f11-07c6160b28e4", false, "asiacarter@gmail.com" },
                    { "5661114f-a785-4d5c-8ee8-20eb6366190c", 0, 25, "I specialize in black-and-white tattoos of capybaras.", "dc5b2a5f-658d-44c5-8ea9-650cf89a2bed", "brj@gmail.com", true, "Brittany", "@itsbrittany", "Ramos-Janeway", false, null, "BRJ@GMAIL.COM", "BRJ@GMAIL.COM", 2, "AQAAAAEAACcQAAAAEBHqg/DH4O3ydOfFKgBRobkdc4TKVSGLGdOi6NlFY4tPHajzPQP22KdYvavc9gD7dA==", null, false, 50, "f0ce7a14-719d-4390-8ddf-0ecf6937ae81", false, "brj@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "Photo",
                columns: new[] { "Id", "FilePath", "IsDisplayPhoto", "UserId" },
                values: new object[,]
                {
                    { 5, "~/images/tenn1.jpg", false, "0402a486-a1f7-4eaf-96ef-66dc25142242" },
                    { 6, "~/images/tenn2.jpg", false, "0402a486-a1f7-4eaf-96ef-66dc25142242" }
                });

            migrationBuilder.InsertData(
                table: "Photo",
                columns: new[] { "Id", "FilePath", "IsDisplayPhoto", "UserId" },
                values: new object[,]
                {
                    { 3, "~/images/jeff1.jpg", false, "9eb5a457-17b0-4f58-b76d-6f3448575733" },
                    { 4, "~/images/jeff2.jpg", false, "9eb5a457-17b0-4f58-b76d-6f3448575733" },
                    { 9, "~/images/jeff3.jpg", false, "9eb5a457-17b0-4f58-b76d-6f3448575733" },
                    { 10, "~/images/jeff4.jpg", false, "9eb5a457-17b0-4f58-b76d-6f3448575733" },
                    { 7, "~/images/wedding1.jpg", false, "d5067774-8cf5-44c1-acba-cdf79c125414" },
                    { 8, "~/images/wedding2.jpg", false, "d5067774-8cf5-44c1-acba-cdf79c125414" },
                    { 1, "~/images/capybara1.jpg", false, "5661114f-a785-4d5c-8ee8-20eb6366190c" },
                    { 2, "~/images/capybara2.jpg", false, "5661114f-a785-4d5c-8ee8-20eb6366190c" }
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
