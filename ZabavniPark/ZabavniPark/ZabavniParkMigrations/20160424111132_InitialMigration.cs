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
            migration.AlterColumn(
                name: "AtrakcijaId",
                table: "Atrakcija",
                type: "INTEGER",
                nullable: false)
                .Annotation("Sqlite:Autoincrement", true);
        }

        public override void Down(MigrationBuilder migration)
        {
            migration.AlterColumn(
                name: "AtrakcijaId",
                table: "Atrakcija",
                type: "INTEGER",
                nullable: false)
                .Annotation("Sqlite:Autoincrement", true);
        }
    }
}
