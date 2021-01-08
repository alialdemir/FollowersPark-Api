using Microsoft.EntityFrameworkCore.Migrations;

namespace FollowersPark.Migrations
{
    public partial class TaskDirectMessageIdOptional : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_DirectMessages_DirectMessageId",
                table: "Tasks");

            migrationBuilder.AlterColumn<int>(
                name: "DirectMessageId",
                table: "Tasks",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_DirectMessages_DirectMessageId",
                table: "Tasks",
                column: "DirectMessageId",
                principalTable: "DirectMessages",
                principalColumn: "DirectMessageId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_DirectMessages_DirectMessageId",
                table: "Tasks");

            migrationBuilder.AlterColumn<int>(
                name: "DirectMessageId",
                table: "Tasks",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_DirectMessages_DirectMessageId",
                table: "Tasks",
                column: "DirectMessageId",
                principalTable: "DirectMessages",
                principalColumn: "DirectMessageId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
