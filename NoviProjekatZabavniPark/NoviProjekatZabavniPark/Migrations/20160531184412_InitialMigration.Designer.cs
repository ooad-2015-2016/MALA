using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations.Infrastructure;
using NoviProjekatZabavniPark.Models;

namespace NoviProjekatZabavniParkMigrations
{
    [ContextType(typeof(ZabavniParkDbContext))]
    partial class InitialMigration
    {
        public override string Id
        {
            get { return "20160531184412_InitialMigration"; }
        }

        public override string ProductVersion
        {
            get { return "7.0.0-beta6-13815"; }
        }

        public override void BuildTargetModel(ModelBuilder builder)
        {
            builder
                .Annotation("ProductVersion", "7.0.0-beta6-13815");

            builder.Entity("NoviProjekatZabavniPark.Models.Atrakcija", b =>
                {
                    b.Property<int>("AtrakcijaId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Kapacitet");

                    b.Property<double>("Latitude");

                    b.Property<double>("Longitude");

                    b.Property<string>("Naziv");

                    b.Property<int>("Stanje");

                    b.Property<int>("TrajanjeVoznje");

                    b.Property<int>("TrenutniBrojPosjetilaca");

                    b.Property<TimeSpan>("VrijemeOtvaranja");

                    b.Property<TimeSpan>("VrijemeZatvaranja");

                    b.Key("AtrakcijaId");
                });

            builder.Entity("NoviProjekatZabavniPark.Models.Karta", b =>
                {
                    b.Property<int>("KartaId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Datum");

                    b.Property<bool>("Iskoristena");

                    b.Property<string>("Kod");

                    b.Property<int?>("PosjetilacPosjetilacId");

                    b.Property<int>("Tip");

                    b.Key("KartaId");
                });

            builder.Entity("NoviProjekatZabavniPark.Models.Posjetilac", b =>
                {
                    b.Property<int>("PosjetilacId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DatumRodjenja");

                    b.Property<string>("EMail");

                    b.Property<string>("Ime");

                    b.Property<string>("KorisnickoIme");

                    b.Property<string>("Prezime");

                    b.Property<string>("Sifra");

                    b.Key("PosjetilacId");
                });

            builder.Entity("NoviProjekatZabavniPark.Models.Radnik", b =>
                {
                    b.Property<int>("RadnikId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Ime");

                    b.Property<string>("KorisnickoIme");

                    b.Property<double>("Plata");

                    b.Property<string>("Prezime");

                    b.Property<int>("RadniStaz");

                    b.Property<string>("Sifra");

                    b.Property<int>("Tip");

                    b.Key("RadnikId");
                });

            builder.Entity("NoviProjekatZabavniPark.Models.Karta", b =>
                {
                    b.Reference("NoviProjekatZabavniPark.Models.Posjetilac")
                        .InverseCollection()
                        .ForeignKey("PosjetilacPosjetilacId");
                });
        }
    }
}
