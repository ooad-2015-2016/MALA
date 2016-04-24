using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations.Infrastructure;
using ZabavniPark.ZabavniPark.Models;

namespace ZabavniParkMigrations
{
    [ContextType(typeof(PosjetilacDbContext))]
    partial class PosjetilacMigracija
    {
        public override string Id
        {
            get { return "20160424184203_PosjetilacMigracija"; }
        }

        public override string ProductVersion
        {
            get { return "7.0.0-beta6-13815"; }
        }

        public override void BuildTargetModel(ModelBuilder builder)
        {
            builder
                .Annotation("ProductVersion", "7.0.0-beta6-13815");

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
