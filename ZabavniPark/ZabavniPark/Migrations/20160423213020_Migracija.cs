using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Migrations.Builders;
using Microsoft.Data.Entity.Migrations.Operations;

namespace ZabavniParkMigrations
{
    public partial class Initial : Migration
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
                    TrenutniBrojPosjetilaca = table.Column(type: "INTEGER", nullable: false),
                    VrijemeOtvaranja = table.Column(type: "TEXT", nullable: false),
                    VrijemeZatvaranja = table.Column(type: "TEXT", nullable: false),
                    fourSqaureId = table.Column(type: "TEXT", nullable: true),
                    stanje = table.Column(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atrakcija", x => x.AtrakcijaId);
                });
        }

        public override void Down(MigrationBuilder migration)
        {
            migration.DropTable("Atrakcija");
        }
    }
}
