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
                name: "Park",
                columns: table => new
                {
                    ParkId = table.Column(type: "INTEGER", nullable: false),
                       // .Annotation("Sqlite:Autoincrement", true),
                    Atrakcija = table.Column(type: "TEXT", nullable: true),
                    BrojRadnika = table.Column(type: "INTEGER", nullable: false),
                    Kapacitet = table.Column(type: "INTEGER", nullable: false),
                    Naziv = table.Column(type: "TEXT", nullable: true),
                    TrenutniBrojPosjetilaca = table.Column(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Park", x => x.ParkId);
                });
        }

        public override void Down(MigrationBuilder migration)
        {
            migration.DropTable("Park");
        }
    }
}
