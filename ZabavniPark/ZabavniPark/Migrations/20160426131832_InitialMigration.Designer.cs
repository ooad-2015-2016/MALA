using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations.Infrastructure;
using ZabavniPark.ZabavniPark.Models;

namespace ZabavniParkMigrations
{
    [ContextType(typeof(ZabavniParkDbContext))]
    partial class InitialMigration
    {
        public override string Id
        {
            get { return "20160426131832_InitialMigration"; }
        }

        public override string ProductVersion
        {
            get { return "7.0.0-beta6-13815"; }
        }

        public override void BuildTargetModel(ModelBuilder builder)
        {
            builder
                .Annotation("ProductVersion", "7.0.0-beta6-13815");

            builder.Entity("MyApp_OOAD.AtrakcijaBaza.Models.Atrakcija", b =>
                {
                    b.Property<int>("AtrakcijaId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BrojNaCekanju");

                    b.Property<float>("Cijena");

                    b.Property<int>("Kapacitet");

                    b.Property<string>("Naziv");

                    b.Property<int>("Stanje");

                    b.Property<int>("TrenutniBrojPosjetilaca");

                    b.Property<TimeSpan>("VrijemeOtvaranja");

                    b.Property<TimeSpan>("VrijemeZatvaranja");

                    b.Property<string>("fourSqaureId");

                    b.Key("AtrakcijaId");
                });

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

            builder.Entity("ZabavniPark.ZabavniPark.Models.Posjetilac", b =>
                {
                    b.Property<int>("PosjetilacId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Ime");

                    b.Property<string>("Prezime");

                    b.Property<int>("tip");

                    b.Key("PosjetilacId");
                });
        }
    }
}
