using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplicatie.Migrations
{
    public partial class _3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cliënt_hulpverlener_hulpverlenerID",
                table: "cliënt");

            migrationBuilder.DropForeignKey(
                name: "FK_cliënt_ouder_ouderID",
                table: "cliënt");

            migrationBuilder.RenameColumn(
                name: "voorNaam",
                table: "ouder",
                newName: "Voornaam");

            migrationBuilder.RenameColumn(
                name: "tussenVoegsel",
                table: "ouder",
                newName: "Tussenvoegsel");

            migrationBuilder.RenameColumn(
                name: "achterNaam",
                table: "ouder",
                newName: "Achternaam");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "ouder",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "wachtwoord",
                table: "ouder",
                newName: "Telnr");

            migrationBuilder.RenameColumn(
                name: "gebruikersNaam",
                table: "ouder",
                newName: "Geslacht");

            migrationBuilder.RenameColumn(
                name: "voorNaam",
                table: "moderator",
                newName: "Voornaam");

            migrationBuilder.RenameColumn(
                name: "tussenVoegsel",
                table: "moderator",
                newName: "Tussenvoegsel");

            migrationBuilder.RenameColumn(
                name: "achterNaam",
                table: "moderator",
                newName: "Achternaam");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "moderator",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "wachtwoord",
                table: "moderator",
                newName: "Telnr");

            migrationBuilder.RenameColumn(
                name: "gebruikersNaam",
                table: "moderator",
                newName: "Geslacht");

            migrationBuilder.RenameColumn(
                name: "voorNaam",
                table: "hulpverlener",
                newName: "Voornaam");

            migrationBuilder.RenameColumn(
                name: "tussenVoegsel",
                table: "hulpverlener",
                newName: "Tussenvoegsel");

            migrationBuilder.RenameColumn(
                name: "achterNaam",
                table: "hulpverlener",
                newName: "Achternaam");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "hulpverlener",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "wachtwoord",
                table: "hulpverlener",
                newName: "Telnr");

            migrationBuilder.RenameColumn(
                name: "gebruikersNaam",
                table: "hulpverlener",
                newName: "Geslacht");

            migrationBuilder.RenameColumn(
                name: "voorNaam",
                table: "cliënt",
                newName: "Voornaam");

            migrationBuilder.RenameColumn(
                name: "tussenVoegsel",
                table: "cliënt",
                newName: "Tussenvoegsel");

            migrationBuilder.RenameColumn(
                name: "ouderID",
                table: "cliënt",
                newName: "ouderId");

            migrationBuilder.RenameColumn(
                name: "hulpverlenerID",
                table: "cliënt",
                newName: "hulpverlenerId");

            migrationBuilder.RenameColumn(
                name: "achterNaam",
                table: "cliënt",
                newName: "Achternaam");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "cliënt",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "wachtwoord",
                table: "cliënt",
                newName: "Telnr");

            migrationBuilder.RenameColumn(
                name: "gebruikersNaam",
                table: "cliënt",
                newName: "Geslacht");

            migrationBuilder.RenameIndex(
                name: "IX_cliënt_ouderID",
                table: "cliënt",
                newName: "IX_cliënt_ouderId");

            migrationBuilder.RenameIndex(
                name: "IX_cliënt_hulpverlenerID",
                table: "cliënt",
                newName: "IX_cliënt_hulpverlenerId");

            migrationBuilder.AddColumn<string>(
                name: "Adres",
                table: "ouder",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "ouder",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Leeftijd",
                table: "ouder",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Plaats",
                table: "ouder",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Postcode",
                table: "ouder",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Adres",
                table: "moderator",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "moderator",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Leeftijd",
                table: "moderator",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Plaats",
                table: "moderator",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Postcode",
                table: "moderator",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Adres",
                table: "hulpverlener",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "hulpverlener",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Leeftijd",
                table: "hulpverlener",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Plaats",
                table: "hulpverlener",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Postcode",
                table: "hulpverlener",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Adres",
                table: "cliënt",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "cliënt",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Leeftijd",
                table: "cliënt",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Plaats",
                table: "cliënt",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Postcode",
                table: "cliënt",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_cliënt_hulpverlener_hulpverlenerId",
                table: "cliënt",
                column: "hulpverlenerId",
                principalTable: "hulpverlener",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_cliënt_ouder_ouderId",
                table: "cliënt",
                column: "ouderId",
                principalTable: "ouder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cliënt_hulpverlener_hulpverlenerId",
                table: "cliënt");

            migrationBuilder.DropForeignKey(
                name: "FK_cliënt_ouder_ouderId",
                table: "cliënt");

            migrationBuilder.DropColumn(
                name: "Adres",
                table: "ouder");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "ouder");

            migrationBuilder.DropColumn(
                name: "Leeftijd",
                table: "ouder");

            migrationBuilder.DropColumn(
                name: "Plaats",
                table: "ouder");

            migrationBuilder.DropColumn(
                name: "Postcode",
                table: "ouder");

            migrationBuilder.DropColumn(
                name: "Adres",
                table: "moderator");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "moderator");

            migrationBuilder.DropColumn(
                name: "Leeftijd",
                table: "moderator");

            migrationBuilder.DropColumn(
                name: "Plaats",
                table: "moderator");

            migrationBuilder.DropColumn(
                name: "Postcode",
                table: "moderator");

            migrationBuilder.DropColumn(
                name: "Adres",
                table: "hulpverlener");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "hulpverlener");

            migrationBuilder.DropColumn(
                name: "Leeftijd",
                table: "hulpverlener");

            migrationBuilder.DropColumn(
                name: "Plaats",
                table: "hulpverlener");

            migrationBuilder.DropColumn(
                name: "Postcode",
                table: "hulpverlener");

            migrationBuilder.DropColumn(
                name: "Adres",
                table: "cliënt");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "cliënt");

            migrationBuilder.DropColumn(
                name: "Leeftijd",
                table: "cliënt");

            migrationBuilder.DropColumn(
                name: "Plaats",
                table: "cliënt");

            migrationBuilder.DropColumn(
                name: "Postcode",
                table: "cliënt");

            migrationBuilder.RenameColumn(
                name: "Voornaam",
                table: "ouder",
                newName: "voorNaam");

            migrationBuilder.RenameColumn(
                name: "Tussenvoegsel",
                table: "ouder",
                newName: "tussenVoegsel");

            migrationBuilder.RenameColumn(
                name: "Achternaam",
                table: "ouder",
                newName: "achterNaam");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ouder",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Telnr",
                table: "ouder",
                newName: "wachtwoord");

            migrationBuilder.RenameColumn(
                name: "Geslacht",
                table: "ouder",
                newName: "gebruikersNaam");

            migrationBuilder.RenameColumn(
                name: "Voornaam",
                table: "moderator",
                newName: "voorNaam");

            migrationBuilder.RenameColumn(
                name: "Tussenvoegsel",
                table: "moderator",
                newName: "tussenVoegsel");

            migrationBuilder.RenameColumn(
                name: "Achternaam",
                table: "moderator",
                newName: "achterNaam");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "moderator",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Telnr",
                table: "moderator",
                newName: "wachtwoord");

            migrationBuilder.RenameColumn(
                name: "Geslacht",
                table: "moderator",
                newName: "gebruikersNaam");

            migrationBuilder.RenameColumn(
                name: "Voornaam",
                table: "hulpverlener",
                newName: "voorNaam");

            migrationBuilder.RenameColumn(
                name: "Tussenvoegsel",
                table: "hulpverlener",
                newName: "tussenVoegsel");

            migrationBuilder.RenameColumn(
                name: "Achternaam",
                table: "hulpverlener",
                newName: "achterNaam");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "hulpverlener",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Telnr",
                table: "hulpverlener",
                newName: "wachtwoord");

            migrationBuilder.RenameColumn(
                name: "Geslacht",
                table: "hulpverlener",
                newName: "gebruikersNaam");

            migrationBuilder.RenameColumn(
                name: "ouderId",
                table: "cliënt",
                newName: "ouderID");

            migrationBuilder.RenameColumn(
                name: "hulpverlenerId",
                table: "cliënt",
                newName: "hulpverlenerID");

            migrationBuilder.RenameColumn(
                name: "Voornaam",
                table: "cliënt",
                newName: "voorNaam");

            migrationBuilder.RenameColumn(
                name: "Tussenvoegsel",
                table: "cliënt",
                newName: "tussenVoegsel");

            migrationBuilder.RenameColumn(
                name: "Achternaam",
                table: "cliënt",
                newName: "achterNaam");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "cliënt",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Telnr",
                table: "cliënt",
                newName: "wachtwoord");

            migrationBuilder.RenameColumn(
                name: "Geslacht",
                table: "cliënt",
                newName: "gebruikersNaam");

            migrationBuilder.RenameIndex(
                name: "IX_cliënt_ouderId",
                table: "cliënt",
                newName: "IX_cliënt_ouderID");

            migrationBuilder.RenameIndex(
                name: "IX_cliënt_hulpverlenerId",
                table: "cliënt",
                newName: "IX_cliënt_hulpverlenerID");

            migrationBuilder.AddForeignKey(
                name: "FK_cliënt_hulpverlener_hulpverlenerID",
                table: "cliënt",
                column: "hulpverlenerID",
                principalTable: "hulpverlener",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_cliënt_ouder_ouderID",
                table: "cliënt",
                column: "ouderID",
                principalTable: "ouder",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
