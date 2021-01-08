using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FollowersPark.Migrations
{
    public partial class AddTablePricingAndOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pricings",
                columns: table => new
                {
                    PricingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    Title = table.Column<string>(maxLength: 50, nullable: true),
                    SubTitle = table.Column<string>(maxLength: 50, nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    Currency = table.Column<string>(maxLength: 3, nullable: true),
                    IsBestSeller = table.Column<bool>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pricings", x => x.PricingId);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    PricingId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_Pricings_PricingId",
                        column: x => x.PricingId,
                        principalTable: "Pricings",
                        principalColumn: "PricingId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Pricings",
                columns: new[] { "PricingId", "CreatedDate", "Currency", "Deleted", "IsActive", "IsBestSeller", "ModifiedDate", "Price", "SubTitle", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 1, 3, 4, 14, 9, 326, DateTimeKind.Local).AddTicks(9757), "₺", false, true, false, null, 30.00m, "1", "Individual" },
                    { 2, new DateTime(2021, 1, 3, 4, 14, 9, 329, DateTimeKind.Local).AddTicks(7692), "₺", false, true, true, null, 51.00m, "2", "Duo" },
                    { 3, new DateTime(2021, 1, 3, 4, 14, 9, 329, DateTimeKind.Local).AddTicks(8654), "₺", false, true, false, null, 75.00m, "3", "Triple" },
                    { 4, new DateTime(2021, 1, 3, 4, 14, 9, 329, DateTimeKind.Local).AddTicks(8690), "₺", false, true, false, null, 120.00m, "5", "Quintette" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PricingId",
                table: "Orders",
                column: "PricingId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Pricings");
        }
    }
}
