﻿// <auto-generated />
using System;
using LeonardoSanna_TestWeek4.RepositoryADOEF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LeonardoSanna_TestWeek4.RepositoryADOEF.Migrations
{
    [DbContext(typeof(MasterContext))]
    [Migration("20220520140605_Prima")]
    partial class Prima
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("LeonardoSanna_TestWeek4.Core.Entities.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("NomeCategoria")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Categoria");

                    b.HasKey("Id")
                        .HasName("PK_Categoria");

                    b.ToTable("Categorie");
                });

            modelBuilder.Entity("LeonardoSanna_TestWeek4.Core.Entities.Spesa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Approvato")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<int>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Data")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2022, 5, 20, 16, 6, 5, 35, DateTimeKind.Local).AddTicks(7947));

                    b.Property<string>("Descrizione")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("None");

                    b.Property<decimal>("Importo")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Utente")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id")
                        .HasName("PK_Spesa");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Spese", (string)null);
                });

            modelBuilder.Entity("LeonardoSanna_TestWeek4.Core.Entities.Spesa", b =>
                {
                    b.HasOne("LeonardoSanna_TestWeek4.Core.Entities.Categoria", "Categoria")
                        .WithMany("Spese")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Categoria");

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("LeonardoSanna_TestWeek4.Core.Entities.Categoria", b =>
                {
                    b.Navigation("Spese");
                });
#pragma warning restore 612, 618
        }
    }
}
