using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplicatie.Migrations
{
    public partial class k16 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "aangemeldeHulpverlener",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "aangemeldeHulpverlener",
                table: "AspNetUsers");
        }
    }
}
