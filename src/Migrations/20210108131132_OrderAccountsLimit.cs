using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FollowersPark.Migrations
{
    public partial class OrderAccountsLimit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Pricings",
                type: "decimal(18,4)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<byte>(
                name: "AccountsLimit",
                table: "Orders",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<DateTime>(
                name: "FinishDate",
                table: "Orders",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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

            migrationBuilder.InsertData(
                table: "Pricings",
                columns: new[] { "PricingId", "CreatedDate", "Currency", "Deleted", "IsActive", "IsBestSeller", "ModifiedDate", "Price", "SubTitle", "Title" },
                values: new object[] { 5, new DateTime(2021, 1, 8, 16, 11, 31, 351, DateTimeKind.Local).AddTicks(5112), "₺", false, false, false, null, 0m, "Free", "Free" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Pricings",
                keyColumn: "PricingId",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "AccountsLimit",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "FinishDate",
                table: "Orders");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Pricings",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)");

            migrationBuilder.UpdateData(
                table: "Pricings",
                keyColumn: "PricingId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2021, 1, 3, 4, 14, 9, 326, DateTimeKind.Local).AddTicks(9757));

            migrationBuilder.UpdateData(
                table: "Pricings",
                keyColumn: "PricingId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2021, 1, 3, 4, 14, 9, 329, DateTimeKind.Local).AddTicks(7692));

            migrationBuilder.UpdateData(
                table: "Pricings",
                keyColumn: "PricingId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2021, 1, 3, 4, 14, 9, 329, DateTimeKind.Local).AddTicks(8654));

            migrationBuilder.UpdateData(
                table: "Pricings",
                keyColumn: "PricingId",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2021, 1, 3, 4, 14, 9, 329, DateTimeKind.Local).AddTicks(8690));
        }
    }
}
