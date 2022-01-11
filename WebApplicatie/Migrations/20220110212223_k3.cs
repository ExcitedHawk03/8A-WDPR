using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplicatie.Migrations
{
    public partial class k3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_message_chat_chatId",
                table: "message");

            migrationBuilder.RenameColumn(
                name: "chatId",
                table: "message",
                newName: "ChatId");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "message",
                newName: "naam");

            migrationBuilder.RenameIndex(
                name: "IX_message_chatId",
                table: "message",
                newName: "IX_message_ChatId");

            migrationBuilder.AlterColumn<int>(
                name: "ChatId",
                table: "message",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_message_chat_ChatId",
                table: "message",
                column: "ChatId",
                principalTable: "chat",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_message_chat_ChatId",
                table: "message");

            migrationBuilder.RenameColumn(
                name: "ChatId",
                table: "message",
                newName: "chatId");

            migrationBuilder.RenameColumn(
                name: "naam",
                table: "message",
                newName: "name");

            migrationBuilder.RenameIndex(
                name: "IX_message_ChatId",
                table: "message",
                newName: "IX_message_chatId");

            migrationBuilder.AlterColumn<int>(
                name: "chatId",
                table: "message",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_message_chat_chatId",
                table: "message",
                column: "chatId",
                principalTable: "chat",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
