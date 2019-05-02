using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InkInc.Migrations
{
    public partial class ParlorDetails : Migration
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
                    ParlorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Parlor_ParlorId",
                        column: x => x.ParlorId,
                        principalTable: "Parlor",
                        principalColumn: "ParlorId",
                        onDelete: ReferentialAction.Cascade);
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
                    UserId = table.Column<int>(nullable: false),
                    UserId1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photo_AspNetUsers_UserId1",
                        column: x => x.UserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Parlor",
                columns: new[] { "ParlorId", "City", "CloseTime", "DaysOpen", "Name", "OpenTime", "OwnerId", "PhoneNumber", "State", "StreetAddress" },
                values: new object[] { 1, "Nashville", "6:00 PM", "Monday - Saturday", "Black Dahlia Studios", "9:00 AM", "a1f81af0-5180-4887-b535-8ab6cfd01dcb", "(615)-555-5555", "Tennessee", "1200 Forest Ave" });

            migrationBuilder.InsertData(
                table: "Parlor",
                columns: new[] { "ParlorId", "City", "CloseTime", "DaysOpen", "Name", "OpenTime", "OwnerId", "PhoneNumber", "State", "StreetAddress" },
                values: new object[] { 2, "Nashville", "8:00 PM", "Tuesday - Saturday", "Electric Hand", "10:00 AM", "37c6bf90-023c-4b10-b435-2e61cb4d9151", "(615)-555-5555", "Tennessee", "300 Rainbow Dr" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BaselinePricing", "Biography", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "InstagramHandle", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "ParlorId", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PricePerHour", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "a1f81af0-5180-4887-b535-8ab6cfd01dcb", 0, 50, "I've been a tattoo artist for 10 years. I specialize in portrait pieces, particularly of Jeff Goldblum.", "9f176ece-ce4a-4caf-b778-a2bd56229bfc", "allisonkatecollins@gmail.com", true, "Allison", "@allisonkatecollins", "Collins", false, null, "ALLISONKATECOLLINS@GMAIL.COM", null, 1, "AQAAAAEAACcQAAAAEMtauPuWw8GfJOeIu+oMLlZyxUWjXO3VuaWjMrv+KXhno8zzsktvN+Ywd/bvTnkr1g==", null, false, 40, "3216a62c-4791-43e7-a1de-469b00d40b57", false, null },
                    { "22ac3c15-5125-4216-9c2f-1056565ab1c6", 0, 60, "I am inspired by the energy that bachelorette parties bring to Nashville, so I mostly do wedding themed tattoos.", "8090f9f5-e8f1-45d2-903e-790e88fd638e", "asiacarter@gmail.com", true, "Asia", "@asiacarter", "Carter", false, null, "ASIACARTER@GMAIL.COM", null, 1, "AQAAAAEAACcQAAAAEIMZ3dwF2iZl4JahEltrzBgjWu+BhQXlFqBwyrmTrJDKxzjH7sOG6AG6IdPhFK45Hg==", null, false, 50, "10e5d482-3c2a-4a21-9323-7be15d75c7e1", false, null },
                    { "38ba5fa5-675f-4b92-a74b-f433f3c595c4", 0, 25, "I specialize in black-and-white tattoos of capybaras.", "8c6d2116-31f8-4d3b-b2f8-0c6e4032c073", "brj@gmail.com", true, "Brittany", "@itsbrittany", "Ramos-Janeway", false, null, "BRJ@GMAIL.COM", null, 2, "AQAAAAEAACcQAAAAEFY3zck3tMQLbK5Jqh6tK6YDv1kUtjHV8bY+IGtQ5DaQ6kkVXIE03i4jw6NjSjTf0Q==", null, false, 50, "3ba7c9c0-e334-4939-add7-dbe72584c8a8", false, null },
                    { "37c6bf90-023c-4b10-b435-2e61cb4d9151", 0, 100, "I grew up in Nashville and want to keep the Volunteer tradition alive. Ask me about my Rockytop Special.", "2b75fe06-7e53-4b0f-9a49-662d39eadfe9", "maryremo@gmail.com", true, "Mary", "@sodajerk", "Remo", false, null, "MARYREMO@GMAIL.COM", null, 2, "AQAAAAEAACcQAAAAEC/XTFYgfzDAMYLuf2RAsaVJl689/Xu5IpSxt+gcU4e8BfZjgjVbLc6E/4SZ41HRag==", null, false, 60, "8eee5ef5-608e-467b-968d-69e2d43c4b13", false, null }
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
                name: "IX_Photo_UserId1",
                table: "Photo",
                column: "UserId1");
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
