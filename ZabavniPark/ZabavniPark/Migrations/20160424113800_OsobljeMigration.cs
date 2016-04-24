using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Migrations.Builders;
using Microsoft.Data.Entity.Migrations.Operations;

namespace ZabavniParkMigrations
{
    public partial class OsobljeMigration : Migration
    {
        public override void Up(MigrationBuilder migration)
        {
            migration.CreateTable(
                name: "Osoblje",
                columns: table => new
                {
                    OsobljeId = table.Column(type: "INTEGER", nullable: false),
                      //  .Annotation("Sqlite:Autoincrement", true),
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
        }

        public override void Down(MigrationBuilder migration)
        {
            migration.DropTable("Osoblje");
        }
    }
}
