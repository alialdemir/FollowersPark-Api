using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FollowersPark.Migrations
{
    public partial class CsrfToken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InstagramAccounts",
                columns: table => new
                {
                    InstagramAccountId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    InstagramId = table.Column<string>(maxLength: 255, nullable: false),
                    Username = table.Column<string>(maxLength: 255, nullable: false),
                    Fullname = table.Column<string>(maxLength: 255, nullable: false),
                    CsrfToken = table.Column<string>(maxLength: 255, nullable: false),
                    FollowersCount = table.Column<long>(nullable: false),
                    FollowingCount = table.Column<long>(nullable: false),
                    IsVerified = table.Column<bool>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstagramAccounts", x => x.InstagramAccountId);
                    table.ForeignKey(
                        name: "FK_InstagramAccounts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedDate", "Deleted", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "ModifiedDate", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "a53bc759-f5b2-49fe-b4d3-db96edab5118", 0, "b7e6b263-b296-4ab5-97ea-de6146f11dbb", new DateTime(2021, 1, 10, 15, 6, 47, 812, DateTimeKind.Local).AddTicks(3000), false, "demo@followerspark.com", false, true, null, new DateTime(2021, 1, 10, 15, 6, 47, 812, DateTimeKind.Local).AddTicks(4422), "DEMO@FOLLOWERSPARK.COM", "DEMO@FOLLOWERSPARK.COM", "AQAAAAEAACcQAAAAEEgF9tR64l8xuT16f/zfv51NKZ5BOY+8spB5eJN5KuQ4s5kv74JVsDmPMYsGFcqFEA==", null, false, "WFAXFZOX3UIXREEDBJXNWNMUU2LZB3E4", false, "demo@followerspark.com" });

            migrationBuilder.UpdateData(
                table: "Pricings",
                keyColumn: "PricingId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2021, 1, 10, 15, 6, 47, 808, DateTimeKind.Local).AddTicks(3099));

            migrationBuilder.UpdateData(
                table: "Pricings",
                keyColumn: "PricingId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2021, 1, 10, 15, 6, 47, 811, DateTimeKind.Local).AddTicks(818));

            migrationBuilder.UpdateData(
                table: "Pricings",
                keyColumn: "PricingId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2021, 1, 10, 15, 6, 47, 811, DateTimeKind.Local).AddTicks(1750));

            migrationBuilder.UpdateData(
                table: "Pricings",
                keyColumn: "PricingId",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2021, 1, 10, 15, 6, 47, 811, DateTimeKind.Local).AddTicks(1785));

            migrationBuilder.UpdateData(
                table: "Pricings",
                keyColumn: "PricingId",
                keyValue: 5,
                columns: new[] { "CreatedDate", "SubTitle" },
                values: new object[] { new DateTime(2021, 1, 10, 15, 6, 47, 811, DateTimeKind.Local).AddTicks(1810), "1" });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "AccountsLimit", "CreatedDate", "Deleted", "FinishDate", "ModifiedDate", "PricingId", "UserId" },
                values: new object[] { 1, (byte)255, new DateTime(2021, 1, 10, 15, 6, 47, 812, DateTimeKind.Local).AddTicks(6379), false, new DateTime(2023, 10, 6, 12, 6, 47, 812, DateTimeKind.Utc).AddTicks(7293), null, 5, "a53bc759-f5b2-49fe-b4d3-db96edab5118" });

            migrationBuilder.CreateIndex(
                name: "IX_InstagramAccounts_UserId",
                table: "InstagramAccounts",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InstagramAccounts");

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a53bc759-f5b2-49fe-b4d3-db96edab5118");

            migrationBuilder.UpdateData(
                table: "Pricings",
                keyColumn: "PricingId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2021, 1, 8, 16, 11, 31, 348, DateTimeKind.Local).AddTicks(2454));

            migrationBuilder.UpdateData(
                table: "Pricings",
                keyColumn: "PricingId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2021, 1, 8, 16, 11, 31, 351, DateTimeKind.Local).AddTicks(3966));

            migrationBuilder.UpdateData(
                table: "Pricings",
                keyColumn: "PricingId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2021, 1, 8, 16, 11, 31, 351, DateTimeKind.Local).AddTicks(5031));

            migrationBuilder.UpdateData(
                table: "Pricings",
                keyColumn: "PricingId",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2021, 1, 8, 16, 11, 31, 351, DateTimeKind.Local).AddTicks(5080));

            migrationBuilder.UpdateData(
                table: "Pricings",
                keyColumn: "PricingId",
                keyValue: 5,
                columns: new[] { "CreatedDate", "SubTitle" },
                values: new object[] { new DateTime(2021, 1, 8, 16, 11, 31, 351, DateTimeKind.Local).AddTicks(5112), "Free" });
        }
    }
}
