using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Migrations.Builders;
using Microsoft.Data.Entity.Migrations.Operations;

namespace NoviProjekatZabavniParkMigrations
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
                    Latitude = table.Column(type: "REAL", nullable: false),
                    Longitude = table.Column(type: "REAL", nullable: false),
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
                    DatumRodjenja = table.Column(type: "TEXT", nullable: false),
                    EMail = table.Column(type: "TEXT", nullable: true),
                    Ime = table.Column(type: "TEXT", nullable: true),
                    KorisnickoIme = table.Column(type: "TEXT", nullable: true),
                    Prezime = table.Column(type: "TEXT", nullable: true),
                    Sifra = table.Column(type: "TEXT", nullable: true)
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
                    Ime = table.Column(type: "TEXT", nullable: true),
                    KorisnickoIme = table.Column(type: "TEXT", nullable: true),
                    Plata = table.Column(type: "REAL", nullable: false),
                    Prezime = table.Column(type: "TEXT", nullable: true),
                    RadniStaz = table.Column(type: "INTEGER", nullable: false),
                    Sifra = table.Column(type: "TEXT", nullable: true),
                    Tip = table.Column(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Radnik", x => x.RadnikId);
                });
            migration.CreateTable(
                name: "Karta",
                columns: table => new
                {
                    KartaId = table.Column(type: "INTEGER", nullable: false),
                       // .Annotation("Sqlite:Autoincrement", true),
                    Datum = table.Column(type: "TEXT", nullable: false),
                    Iskoristena = table.Column(type: "INTEGER", nullable: false),
                    Kod = table.Column(type: "TEXT", nullable: true),
                    PosjetilacPosjetilacId = table.Column(type: "INTEGER", nullable: true),
                    Tip = table.Column(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Karta", x => x.KartaId);
                    table.ForeignKey(
                        name: "FK_Karta_Posjetilac_PosjetilacPosjetilacId",
                        columns: x => x.PosjetilacPosjetilacId,
                        referencedTable: "Posjetilac",
                        referencedColumn: "PosjetilacId");
                });
        }

        public override void Down(MigrationBuilder migration)
        {
            migration.DropTable("Atrakcija");
            migration.DropTable("Karta");
            migration.DropTable("Radnik");
            migration.DropTable("Posjetilac");
        }
    }
}
