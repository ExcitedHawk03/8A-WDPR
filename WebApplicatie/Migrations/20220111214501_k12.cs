using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplicatie.Migrations
{
    public partial class k12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_chatUsers_AspNetUsers_accountId",
                table: "chatUsers");

            migrationBuilder.RenameColumn(
                name: "accountId",
                table: "chatUsers",
                newName: "AccountId");

            migrationBuilder.RenameIndex(
                name: "IX_chatUsers_accountId",
                table: "chatUsers",
                newName: "IX_chatUsers_AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_chatUsers_AspNetUsers_AccountId",
                table: "chatUsers",
                column: "AccountId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_chatUsers_AspNetUsers_AccountId",
                table: "chatUsers");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "chatUsers",
                newName: "accountId");

            migrationBuilder.RenameIndex(
                name: "IX_chatUsers_AccountId",
                table: "chatUsers",
                newName: "IX_chatUsers_accountId");

            migrationBuilder.AddForeignKey(
                name: "FK_chatUsers_AspNetUsers_accountId",
                table: "chatUsers",
                column: "accountId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
