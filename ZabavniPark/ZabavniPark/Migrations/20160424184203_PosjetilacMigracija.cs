using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Migrations.Builders;
using Microsoft.Data.Entity.Migrations.Operations;

namespace ZabavniParkMigrations
{
    public partial class PosjetilacMigracija : Migration
    {
        public override void Up(MigrationBuilder migration)
        {
            migration.CreateTable(
                name: "Posjetilac",
                columns: table => new
                {
                    PosjetilacId = table.Column(type: "INTEGER", nullable: false),
                        //.Annotation("Sqlite:Autoincrement", true),
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
            migration.DropTable("Posjetilac");
        }
    }
}
