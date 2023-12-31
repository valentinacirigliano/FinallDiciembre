﻿// <auto-generated />
using FinalMVCcore.DataLayer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FinalMVCcore.DataLayer.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231201212900_InitialCatalog")]
    partial class InitialCatalog
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FinalMVCcore.Models.Planta", b =>
                {
                    b.Property<int>("PlantaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlantaId"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("TipoDePlantaId")
                        .HasColumnType("int");

                    b.HasKey("PlantaId");

                    b.ToTable("Plantas");
                });

            modelBuilder.Entity("FinalMVCcore.Models.TipoDePlanta", b =>
                {
                    b.Property<int>("TipoDePlantaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TipoDePlantaId"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("TipoDePlantaId");

                    b.ToTable("TiposDePlantas");
                });
#pragma warning restore 612, 618
        }
    }
}
