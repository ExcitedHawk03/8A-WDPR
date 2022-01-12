using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplicatie.Migrations
{
    public partial class k8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "chatUsers",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ChatId = table.Column<int>(type: "INTEGER", nullable: false),
                    accountId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chatUsers", x => new { x.ChatId, x.UserId });
                    table.ForeignKey(
                        name: "FK_chatUsers_AspNetUsers_accountId",
                        column: x => x.accountId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_chatUsers_chat_ChatId",
                        column: x => x.ChatId,
                        principalTable: "chat",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_chatUsers_accountId",
                table: "chatUsers",
                column: "accountId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "chatUsers");
        }
    }
}
