using Microsoft.EntityFrameworkCore.Migrations;

namespace FollowersPark.Migrations
{
    public partial class TaskHashtags : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Hashtags",
                table: "Tasks",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Hashtags",
                table: "Tasks");
        }
    }
}
