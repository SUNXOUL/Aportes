﻿// <auto-generated />
using System;
using Aportes.Server.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Aportes.Server.Migrations
{
    [DbContext(typeof(Contexto))]
    partial class ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.3");

            modelBuilder.Entity("Aportes.Shared.Models.Aporte", b =>
                {
                    b.Property<int>("AporteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Concepto")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<float>("Monto")
                        .HasColumnType("REAL");

                    b.Property<int>("PersonaId")
                        .HasColumnType("INTEGER");

                    b.HasKey("AporteId");

                    b.ToTable("Aportes");
                });

            modelBuilder.Entity("Aportes.Shared.Models.AportesDetalle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("AporteId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PersonaId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Tipo")
                        .HasColumnType("INTEGER");

                    b.Property<float>("Valor")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("AporteId");

                    b.HasIndex("PersonaId");

                    b.ToTable("AportesDetalle");
                });

            modelBuilder.Entity("Aportes.Shared.Models.Persona", b =>
                {
                    b.Property<int>("PersonaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double?>("Aporte")
                        .HasColumnType("REAL");

                    b.Property<string>("Celular")
                        .HasColumnType("TEXT");

                    b.Property<string>("Direccion")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("F_Nacimiento")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefono")
                        .HasColumnType("TEXT");

                    b.HasKey("PersonaId");

                    b.ToTable("Personas");
                });

            modelBuilder.Entity("Aportes.Shared.Models.TiposAportes", b =>
                {
                    b.Property<int>("TipoAporteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<float>("Logrado")
                        .HasColumnType("REAL");

                    b.Property<float>("Meta")
                        .HasColumnType("REAL");

                    b.HasKey("TipoAporteId");

                    b.ToTable("TiposAportes");
                });

            modelBuilder.Entity("Aportes.Shared.Models.AportesDetalle", b =>
                {
                    b.HasOne("Aportes.Shared.Models.Aporte", null)
                        .WithMany("DetalleAporte")
                        .HasForeignKey("AporteId");

                    b.HasOne("Aportes.Shared.Models.Persona", "persona")
                        .WithMany()
                        .HasForeignKey("PersonaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("persona");
                });

            modelBuilder.Entity("Aportes.Shared.Models.Aporte", b =>
                {
                    b.Navigation("DetalleAporte");
                });
#pragma warning restore 612, 618
        }
    }
}
