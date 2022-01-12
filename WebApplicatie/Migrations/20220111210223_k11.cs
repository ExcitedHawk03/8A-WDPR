using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplicatie.Migrations
{
    public partial class k11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_chatUsers_AspNetUsers_accountId",
                table: "chatUsers");

            migrationBuilder.DropTable(
                name: "AccountChat");

            migrationBuilder.DropPrimaryKey(
                name: "PK_chatUsers",
                table: "chatUsers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "chatUsers");

            migrationBuilder.AlterColumn<string>(
                name: "accountId",
                table: "chatUsers",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_chatUsers",
                table: "chatUsers",
                columns: new[] { "ChatId", "accountId" });

            migrationBuilder.AddForeignKey(
                name: "FK_chatUsers_AspNetUsers_accountId",
                table: "chatUsers",
                column: "accountId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_chatUsers_AspNetUsers_accountId",
                table: "chatUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_chatUsers",
                table: "chatUsers");

            migrationBuilder.AlterColumn<string>(
                name: "accountId",
                table: "chatUsers",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "chatUsers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_chatUsers",
                table: "chatUsers",
                columns: new[] { "ChatId", "UserId" });

            migrationBuilder.CreateTable(
                name: "AccountChat",
                columns: table => new
                {
                    chatsId = table.Column<int>(type: "INTEGER", nullable: false),
                    usersId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountChat", x => new { x.chatsId, x.usersId });
                    table.ForeignKey(
                        name: "FK_AccountChat_AspNetUsers_usersId",
                        column: x => x.usersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountChat_chat_chatsId",
                        column: x => x.chatsId,
                        principalTable: "chat",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountChat_usersId",
                table: "AccountChat",
                column: "usersId");

            migrationBuilder.AddForeignKey(
                name: "FK_chatUsers_AspNetUsers_accountId",
                table: "chatUsers",
                column: "accountId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
