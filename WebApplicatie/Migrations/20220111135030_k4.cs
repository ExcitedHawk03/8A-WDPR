using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplicatie.Migrations
{
    public partial class k4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cliënt");

            migrationBuilder.DropTable(
                name: "moderator");

            migrationBuilder.DropTable(
                name: "hulpverlener");

            migrationBuilder.DropTable(
                name: "ouder");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AspNetUsers",
                type: "TEXT",
                maxLength: 256,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Achternaam",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Adres",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Geslacht",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Leeftijd",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Plaats",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Postcode",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Telnr",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tussenvoegsel",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Voornaam",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "chatNummer",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "hulpverlenerId",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ouderId",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "typAccount",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_hulpverlenerId",
                table: "AspNetUsers",
                column: "hulpverlenerId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ouderId",
                table: "AspNetUsers",
                column: "ouderId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_hulpverlenerId",
                table: "AspNetUsers",
                column: "hulpverlenerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_ouderId",
                table: "AspNetUsers",
                column: "ouderId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_hulpverlenerId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_ouderId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_hulpverlenerId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ouderId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Achternaam",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Adres",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Geslacht",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Leeftijd",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Plaats",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Postcode",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Telnr",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Tussenvoegsel",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Voornaam",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "chatNummer",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "hulpverlenerId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ouderId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "typAccount",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AspNetUsers",
                type: "TEXT",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 256);

            migrationBuilder.CreateTable(
                name: "hulpverlener",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Achternaam = table.Column<string>(type: "TEXT", nullable: false),
                    Adres = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Geslacht = table.Column<string>(type: "TEXT", nullable: true),
                    Leeftijd = table.Column<int>(type: "INTEGER", nullable: false),
                    Plaats = table.Column<string>(type: "TEXT", nullable: false),
                    Postcode = table.Column<string>(type: "TEXT", nullable: false),
                    Telnr = table.Column<string>(type: "TEXT", nullable: true),
                    Tussenvoegsel = table.Column<string>(type: "TEXT", nullable: true),
                    Voornaam = table.Column<string>(type: "TEXT", nullable: false),
                    chatNummer = table.Column<int>(type: "INTEGER", nullable: false),
                    typAccount = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hulpverlener", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "moderator",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Achternaam = table.Column<string>(type: "TEXT", nullable: false),
                    Adres = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Geslacht = table.Column<string>(type: "TEXT", nullable: true),
                    Leeftijd = table.Column<int>(type: "INTEGER", nullable: false),
                    Plaats = table.Column<string>(type: "TEXT", nullable: false),
                    Postcode = table.Column<string>(type: "TEXT", nullable: false),
                    Telnr = table.Column<string>(type: "TEXT", nullable: true),
                    Tussenvoegsel = table.Column<string>(type: "TEXT", nullable: true),
                    Voornaam = table.Column<string>(type: "TEXT", nullable: false),
                    typAccount = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_moderator", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ouder",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Achternaam = table.Column<string>(type: "TEXT", nullable: false),
                    Adres = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Geslacht = table.Column<string>(type: "TEXT", nullable: true),
                    Leeftijd = table.Column<int>(type: "INTEGER", nullable: false),
                    Plaats = table.Column<string>(type: "TEXT", nullable: false),
                    Postcode = table.Column<string>(type: "TEXT", nullable: false),
                    Telnr = table.Column<string>(type: "TEXT", nullable: true),
                    Tussenvoegsel = table.Column<string>(type: "TEXT", nullable: true),
                    Voornaam = table.Column<string>(type: "TEXT", nullable: false),
                    typAccount = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ouder", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "cliënt",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Achternaam = table.Column<string>(type: "TEXT", nullable: false),
                    Adres = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Geslacht = table.Column<string>(type: "TEXT", nullable: true),
                    Leeftijd = table.Column<int>(type: "INTEGER", nullable: false),
                    Plaats = table.Column<string>(type: "TEXT", nullable: false),
                    Postcode = table.Column<string>(type: "TEXT", nullable: false),
                    Telnr = table.Column<string>(type: "TEXT", nullable: true),
                    Tussenvoegsel = table.Column<string>(type: "TEXT", nullable: true),
                    Voornaam = table.Column<string>(type: "TEXT", nullable: false),
                    hulpverlenerId = table.Column<int>(type: "INTEGER", nullable: true),
                    ouderId = table.Column<int>(type: "INTEGER", nullable: true),
                    typAccount = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cliënt", x => x.Id);
                    table.ForeignKey(
                        name: "FK_cliënt_hulpverlener_hulpverlenerId",
                        column: x => x.hulpverlenerId,
                        principalTable: "hulpverlener",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_cliënt_ouder_ouderId",
                        column: x => x.ouderId,
                        principalTable: "ouder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cliënt_hulpverlenerId",
                table: "cliënt",
                column: "hulpverlenerId");

            migrationBuilder.CreateIndex(
                name: "IX_cliënt_ouderId",
                table: "cliënt",
                column: "ouderId");
        }
    }
}
