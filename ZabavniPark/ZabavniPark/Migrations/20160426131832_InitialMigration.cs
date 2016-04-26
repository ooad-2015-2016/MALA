using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Migrations.Builders;
using Microsoft.Data.Entity.Migrations.Operations;

namespace ZabavniParkMigrations
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
                       // .Annotation("Sqlite:Autoincrement", true),
                    BrojNaCekanju = table.Column(type: "INTEGER", nullable: false),
                    Cijena = table.Column(type: "REAL", nullable: false),
                    Kapacitet = table.Column(type: "INTEGER", nullable: false),
                    Naziv = table.Column(type: "TEXT", nullable: true),
                    Stanje = table.Column(type: "INTEGER", nullable: false),
                    TrenutniBrojPosjetilaca = table.Column(type: "INTEGER", nullable: false),
                    VrijemeOtvaranja = table.Column(type: "TEXT", nullable: false),
                    VrijemeZatvaranja = table.Column(type: "TEXT", nullable: false),
                    fourSqaureId = table.Column(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atrakcija", x => x.AtrakcijaId);
                });
            migration.CreateTable(
                name: "Osoblje",
                columns: table => new
                {
                    OsobljeId = table.Column(type: "INTEGER", nullable: false),
                        //.Annotation("Sqlite:Autoincrement", true),
                    ime = table.Column(type: "TEXT", nullable: true),
                    password = table.Column(type: "TEXT", nullable: true),
                    prezime = table.Column(type: "TEXT", nullable: true),
                    radniStaz = table.Column(type: "INTEGER", nullable: false),
                    tip = table.Column(type: "INTEGER", nullable: false),
                    username = table.Column(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Osoblje", x => x.OsobljeId);
                });
            migration.CreateTable(
                name: "Posjetilac",
                columns: table => new
                {
                    PosjetilacId = table.Column(type: "INTEGER", nullable: false),
                       // .Annotation("Sqlite:Autoincrement", true),
                    Ime = table.Column(type: "TEXT", nullable: true),
                    Prezime = table.Column(type: "TEXT", nullable: true),
                    tip = table.Column(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posjetilac", x => x.PosjetilacId);
                });
        }

        public override void Down(MigrationBuilder migration)
        {
            migration.DropTable("Atrakcija");
            migration.DropTable("Osoblje");
            migration.DropTable("Posjetilac");
        }
    }
}
