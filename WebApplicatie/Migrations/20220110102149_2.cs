using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplicatie.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "hulpverlener",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    chatNummer = table.Column<int>(type: "INTEGER", nullable: false),
                    voorNaam = table.Column<string>(type: "TEXT", nullable: false),
                    tussenVoegsel = table.Column<string>(type: "TEXT", nullable: true),
                    achterNaam = table.Column<string>(type: "TEXT", nullable: false),
                    gebruikersNaam = table.Column<string>(type: "TEXT", nullable: true),
                    wachtwoord = table.Column<string>(type: "TEXT", nullable: true),
                    typAccount = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hulpverlener", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "moderator",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    voorNaam = table.Column<string>(type: "TEXT", nullable: false),
                    tussenVoegsel = table.Column<string>(type: "TEXT", nullable: true),
                    achterNaam = table.Column<string>(type: "TEXT", nullable: false),
                    gebruikersNaam = table.Column<string>(type: "TEXT", nullable: true),
                    wachtwoord = table.Column<string>(type: "TEXT", nullable: true),
                    typAccount = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_moderator", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ouder",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    voorNaam = table.Column<string>(type: "TEXT", nullable: false),
                    tussenVoegsel = table.Column<string>(type: "TEXT", nullable: true),
                    achterNaam = table.Column<string>(type: "TEXT", nullable: false),
                    gebruikersNaam = table.Column<string>(type: "TEXT", nullable: true),
                    wachtwoord = table.Column<string>(type: "TEXT", nullable: true),
                    typAccount = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ouder", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "cliënt",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ouderID = table.Column<int>(type: "INTEGER", nullable: true),
                    hulpverlenerID = table.Column<int>(type: "INTEGER", nullable: true),
                    voorNaam = table.Column<string>(type: "TEXT", nullable: false),
                    tussenVoegsel = table.Column<string>(type: "TEXT", nullable: true),
                    achterNaam = table.Column<string>(type: "TEXT", nullable: false),
                    gebruikersNaam = table.Column<string>(type: "TEXT", nullable: true),
                    wachtwoord = table.Column<string>(type: "TEXT", nullable: true),
                    typAccount = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cliënt", x => x.ID);
                    table.ForeignKey(
                        name: "FK_cliënt_hulpverlener_hulpverlenerID",
                        column: x => x.hulpverlenerID,
                        principalTable: "hulpverlener",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_cliënt_ouder_ouderID",
                        column: x => x.ouderID,
                        principalTable: "ouder",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cliënt_hulpverlenerID",
                table: "cliënt",
                column: "hulpverlenerID");

            migrationBuilder.CreateIndex(
                name: "IX_cliënt_ouderID",
                table: "cliënt",
                column: "ouderID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cliënt");

            migrationBuilder.DropTable(
                name: "moderator");

            migrationBuilder.DropTable(
                name: "hulpverlener");

            migrationBuilder.DropTable(
                name: "ouder");
        }
    }
}
