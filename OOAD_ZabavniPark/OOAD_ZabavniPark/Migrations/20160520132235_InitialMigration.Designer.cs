using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations.Infrastructure;
using OOADZabavniPark.Models;

namespace OOAD_ZabavniParkMigrations
{
    [ContextType(typeof(ZabavniParkDbContext))]
    partial class InitialMigration
    {
        public override string Id
        {
            get { return "20160520132235_InitialMigration"; }
        }

        public override string ProductVersion
        {
            get { return "7.0.0-beta6-13815"; }
        }

        public override void BuildTargetModel(ModelBuilder builder)
        {
            builder
                .Annotation("ProductVersion", "7.0.0-beta6-13815");

            builder.Entity("OOAD_ZabavniPark.Models.Atrakcija", b =>
                {
                    b.Property<int>("AtrakcijaId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Kapacitet");

                    b.Property<string>("Naziv");

                    b.Property<int>("Stanje");

                    b.Property<int>("TrajanjeVoznje");

                    b.Property<int>("TrenutniBrojPosjetilaca");

                    b.Property<TimeSpan>("VrijemeOtvaranja");

                    b.Property<TimeSpan>("VrijemeZatvaranja");

                    b.Key("AtrakcijaId");
                });

            builder.Entity("OOAD_ZabavniPark.Models.Posjetilac", b =>
                {
                    b.Property<int>("PosjetilacId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ClanskiBroj");

                    b.Property<DateTime>("DatumRodjenja");

                    b.Property<string>("Ime");

                    b.Property<string>("Prezime");

                    b.Property<string>("Sifra");

                    b.Property<int>("Tip");

                    b.Key("PosjetilacId");
                });

            builder.Entity("OOAD_ZabavniPark.Models.Radnik", b =>
                {
                    b.Property<int>("RadnikId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool?>("Aktivan");

                    b.Property<DateTime?>("DatumVrijemeZadnjegPristupa");

                    b.Property<string>("Ime");

                    b.Property<string>("KorisnickoIme");

                    b.Property<int>("KorisnikId");

                    b.Property<string>("Password");

                    b.Property<double>("Plata");

                    b.Property<string>("Prezime");

                    b.Property<int>("RadniStaz");

                    b.Property<string>("Sifra");

                    b.Property<int>("Tip");

                    b.Property<string>("Username");

                    b.Key("RadnikId");
                });
        }
    }
}
