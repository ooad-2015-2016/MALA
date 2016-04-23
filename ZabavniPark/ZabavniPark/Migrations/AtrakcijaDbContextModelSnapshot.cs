using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations.Infrastructure;
using MyApp_OOAD.AtrakcijaBaza.Models;

namespace ZabavniParkMigrations
{
    [ContextType(typeof(AtrakcijaDbContext))]
    partial class AtrakcijaDbContextModelSnapshot : ModelSnapshot
    {
        public override void BuildModel(ModelBuilder builder)
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

                    b.Property<int>("TrenutniBrojPosjetilaca");

                    b.Property<TimeSpan>("VrijemeOtvaranja");

                    b.Property<TimeSpan>("VrijemeZatvaranja");

                    b.Property<string>("fourSqaureId");

                    b.Property<bool>("stanje");

                    b.Key("AtrakcijaId");
                });
        }
    }
}
