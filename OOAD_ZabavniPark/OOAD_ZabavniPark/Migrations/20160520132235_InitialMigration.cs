using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Migrations.Builders;
using Microsoft.Data.Entity.Migrations.Operations;

namespace OOAD_ZabavniParkMigrations
{
    public partial class InitialMigration : Migration
    {
        public override void Up(MigrationBuilder migration)
        {
            migration.CreateTable(
                name: "Atrakcija",
                columns: table => new
                {
                    AtrakcijaId = table.Column(type: "INTEGER", nullable: false),
                        //.Annotation("Sqlite:Autoincrement", true),
                    Kapacitet = table.Column(type: "INTEGER", nullable: false),
                    Naziv = table.Column(type: "TEXT", nullable: true),
                    Stanje = table.Column(type: "INTEGER", nullable: false),
                    TrajanjeVoznje = table.Column(type: "INTEGER", nullable: false),
                    TrenutniBrojPosjetilaca = table.Column(type: "INTEGER", nullable: false),
                    VrijemeOtvaranja = table.Column(type: "TEXT", nullable: false),
                    VrijemeZatvaranja = table.Column(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atrakcija", x => x.AtrakcijaId);
                });
            migration.CreateTable(
                name: "Posjetilac",
                columns: table => new
                {
                    PosjetilacId = table.Column(type: "INTEGER", nullable: false),
                        //.Annotation("Sqlite:Autoincrement", true),
                    ClanskiBroj = table.Column(type: "INTEGER", nullable: false),
                    DatumRodjenja = table.Column(type: "TEXT", nullable: false),
                    Ime = table.Column(type: "TEXT", nullable: true),
                    Prezime = table.Column(type: "TEXT", nullable: true),
                    Sifra = table.Column(type: "TEXT", nullable: true),
                    Tip = table.Column(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posjetilac", x => x.PosjetilacId);
                });
            migration.CreateTable(
                name: "Radnik",
                columns: table => new
                {
                    RadnikId = table.Column(type: "INTEGER", nullable: false),
                        //.Annotation("Sqlite:Autoincrement", true),
                    Aktivan = table.Column(type: "INTEGER", nullable: true),
                    DatumVrijemeZadnjegPristupa = table.Column(type: "TEXT", nullable: true),
                    Ime = table.Column(type: "TEXT", nullable: true),
                    KorisnickoIme = table.Column(type: "TEXT", nullable: true),
                    KorisnikId = table.Column(type: "INTEGER", nullable: false),
                    Password = table.Column(type: "TEXT", nullable: true),
                    Plata = table.Column(type: "REAL", nullable: false),
                    Prezime = table.Column(type: "TEXT", nullable: true),
                    RadniStaz = table.Column(type: "INTEGER", nullable: false),
                    Sifra = table.Column(type: "TEXT", nullable: true),
                    Tip = table.Column(type: "INTEGER", nullable: false),
                    Username = table.Column(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Radnik", x => x.RadnikId);
                });
        }

        public override void Down(MigrationBuilder migration)
        {
            migration.DropTable("Atrakcija");
            migration.DropTable("Posjetilac");
            migration.DropTable("Radnik");
        }
    }
}
