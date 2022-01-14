using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplicatie.Migrations
{
    public partial class k13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "typMessage",
                table: "message",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ageGroup",
                table: "chat",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "typMessage",
                table: "message");

            migrationBuilder.DropColumn(
                name: "ageGroup",
                table: "chat");
        }
    }
}
