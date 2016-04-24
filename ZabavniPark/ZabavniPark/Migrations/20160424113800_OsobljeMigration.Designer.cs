using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations.Infrastructure;
using MyApp_OOAD.AtrakcijaBaza.Models;

namespace ZabavniParkMigrations
{
    [ContextType(typeof(OsobljeDbContext))]
    partial class OsobljeMigration
    {
        public override string Id
        {
            get { return "20160424113800_OsobljeMigration"; }
        }

        public override string ProductVersion
        {
            get { return "7.0.0-beta6-13815"; }
        }

        public override void BuildTargetModel(ModelBuilder builder)
        {
            builder
                .Annotation("ProductVersion", "7.0.0-beta6-13815");

            builder.Entity("MyApp_OOAD.ParkBaza.Models.Osoblje", b =>
                {
                    b.Property<int>("OsobljeId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ime");

                    b.Property<string>("password");

                    b.Property<string>("prezime");

                    b.Property<int>("radniStaz");

                    b.Property<int>("tip");

                    b.Property<string>("username");

                    b.Key("OsobljeId");
                });
        }
    }
}
