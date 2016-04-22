using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations.Infrastructure;
using MyApp_OOAD.ParkBaza.Models;

namespace ZabavniParkMigrations
{
    [ContextType(typeof(ParkDbContext))]
    partial class InitialMigration
    {
        public override string Id
        {
            get { return "20160422141912_InitialMigration"; }
        }

        public override string ProductVersion
        {
            get { return "7.0.0-beta6-13815"; }
        }

        public override void BuildTargetModel(ModelBuilder builder)
        {
            builder
                .Annotation("ProductVersion", "7.0.0-beta6-13815");

            builder.Entity("MyApp_OOAD.ParkBaza.Models.Park", b =>
                {
                    b.Property<int>("ParkId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Atrakcija");

                    b.Property<int>("BrojRadnika");

                    b.Property<int>("Kapacitet");

                    b.Property<string>("Naziv");

                    b.Property<int>("TrenutniBrojPosjetilaca");

                    b.Key("ParkId");
                });
        }
    }
}
