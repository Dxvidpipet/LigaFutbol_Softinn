﻿// <auto-generated />
using System;
using LigaFutbolSoftInn.App.Persistencia;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LigaFutbolSoftInn.App.Persistencia.Migrations
{
    [DbContext(typeof(AppContext))]
    [Migration("20210916203813_Inicial")]
    partial class Inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("LigaFutbolSoftInn.App.Dominio.Arbitro", b =>
                {
                    b.Property<int>("IdArbitro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ColegioArbitro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DocumentoArbitro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MunicipioIdMunicipio")
                        .HasColumnType("int");

                    b.Property<string>("NombreArbitro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TelefonoArbitro")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdArbitro");

                    b.HasIndex("MunicipioIdMunicipio");

                    b.ToTable("Abitros");
                });

            modelBuilder.Entity("LigaFutbolSoftInn.App.Dominio.DirTecnico", b =>
                {
                    b.Property<int>("IdDirTecnico")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("DocumentoDirTecnico")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EquipoIdEquipo")
                        .HasColumnType("int");

                    b.Property<string>("NombreDirTecnico")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TelefonoDirTecnico")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdDirTecnico");

                    b.HasIndex("EquipoIdEquipo");

                    b.ToTable("DirTecnicos");
                });

            modelBuilder.Entity("LigaFutbolSoftInn.App.Dominio.Equipo", b =>
                {
                    b.Property<int>("IdEquipo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("MunicipioIdMunicipio")
                        .HasColumnType("int");

                    b.Property<string>("NombreEquipo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdEquipo");

                    b.HasIndex("MunicipioIdMunicipio");

                    b.ToTable("Equipos");
                });

            modelBuilder.Entity("LigaFutbolSoftInn.App.Dominio.Estadio", b =>
                {
                    b.Property<int>("IdEstadio")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("DireccionEstadio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MunicipioIdMunicipio")
                        .HasColumnType("int");

                    b.Property<string>("NombreEstadio")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdEstadio");

                    b.HasIndex("MunicipioIdMunicipio");

                    b.ToTable("Estadios");
                });

            modelBuilder.Entity("LigaFutbolSoftInn.App.Dominio.Jugador", b =>
                {
                    b.Property<int>("IdJugador")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("EquipoIdEquipo")
                        .HasColumnType("int");

                    b.Property<string>("NombreJugador")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumeroJugador")
                        .HasColumnType("int");

                    b.Property<string>("PosicionJugador")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdJugador");

                    b.HasIndex("EquipoIdEquipo");

                    b.ToTable("Jugadores");
                });

            modelBuilder.Entity("LigaFutbolSoftInn.App.Dominio.Municipio", b =>
                {
                    b.Property<int>("IdMunicipio")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("NombreMunicipio")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdMunicipio");

                    b.ToTable("Municipios");
                });

            modelBuilder.Entity("LigaFutbolSoftInn.App.Dominio.Novedad", b =>
                {
                    b.Property<int>("IdNovedad")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("JugadorIdJugador")
                        .HasColumnType("int");

                    b.Property<int>("MinutoPartidoNovedad")
                        .HasColumnType("int");

                    b.Property<int?>("PartidoIdPartido")
                        .HasColumnType("int");

                    b.Property<int>("TipoNovedad")
                        .HasColumnType("int");

                    b.HasKey("IdNovedad");

                    b.HasIndex("JugadorIdJugador");

                    b.HasIndex("PartidoIdPartido");

                    b.ToTable("Novedades");
                });

            modelBuilder.Entity("LigaFutbolSoftInn.App.Dominio.Partido", b =>
                {
                    b.Property<int>("IdPartido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("ArbitroIdArbitro")
                        .HasColumnType("int");

                    b.Property<int?>("EstadioIdEstadio")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaPartido")
                        .HasColumnType("datetime2");

                    b.Property<int>("MarcadorLocal")
                        .HasColumnType("int");

                    b.Property<int>("MarcadorVisitante")
                        .HasColumnType("int");

                    b.Property<int?>("NombreEquipoLocalIdEquipo")
                        .HasColumnType("int");

                    b.Property<int?>("NombreEquipoVisitanteIdEquipo")
                        .HasColumnType("int");

                    b.HasKey("IdPartido");

                    b.HasIndex("ArbitroIdArbitro");

                    b.HasIndex("EstadioIdEstadio");

                    b.HasIndex("NombreEquipoLocalIdEquipo");

                    b.HasIndex("NombreEquipoVisitanteIdEquipo");

                    b.ToTable("Partidos");
                });

            modelBuilder.Entity("LigaFutbolSoftInn.App.Dominio.Arbitro", b =>
                {
                    b.HasOne("LigaFutbolSoftInn.App.Dominio.Municipio", "Municipio")
                        .WithMany()
                        .HasForeignKey("MunicipioIdMunicipio");

                    b.Navigation("Municipio");
                });

            modelBuilder.Entity("LigaFutbolSoftInn.App.Dominio.DirTecnico", b =>
                {
                    b.HasOne("LigaFutbolSoftInn.App.Dominio.Equipo", "Equipo")
                        .WithMany()
                        .HasForeignKey("EquipoIdEquipo");

                    b.Navigation("Equipo");
                });

            modelBuilder.Entity("LigaFutbolSoftInn.App.Dominio.Equipo", b =>
                {
                    b.HasOne("LigaFutbolSoftInn.App.Dominio.Municipio", "Municipio")
                        .WithMany()
                        .HasForeignKey("MunicipioIdMunicipio");

                    b.Navigation("Municipio");
                });

            modelBuilder.Entity("LigaFutbolSoftInn.App.Dominio.Estadio", b =>
                {
                    b.HasOne("LigaFutbolSoftInn.App.Dominio.Municipio", "Municipio")
                        .WithMany()
                        .HasForeignKey("MunicipioIdMunicipio");

                    b.Navigation("Municipio");
                });

            modelBuilder.Entity("LigaFutbolSoftInn.App.Dominio.Jugador", b =>
                {
                    b.HasOne("LigaFutbolSoftInn.App.Dominio.Equipo", "Equipo")
                        .WithMany()
                        .HasForeignKey("EquipoIdEquipo");

                    b.Navigation("Equipo");
                });

            modelBuilder.Entity("LigaFutbolSoftInn.App.Dominio.Novedad", b =>
                {
                    b.HasOne("LigaFutbolSoftInn.App.Dominio.Jugador", "Jugador")
                        .WithMany()
                        .HasForeignKey("JugadorIdJugador");

                    b.HasOne("LigaFutbolSoftInn.App.Dominio.Partido", "Partido")
                        .WithMany()
                        .HasForeignKey("PartidoIdPartido");

                    b.Navigation("Jugador");

                    b.Navigation("Partido");
                });

            modelBuilder.Entity("LigaFutbolSoftInn.App.Dominio.Partido", b =>
                {
                    b.HasOne("LigaFutbolSoftInn.App.Dominio.Arbitro", "Arbitro")
                        .WithMany()
                        .HasForeignKey("ArbitroIdArbitro");

                    b.HasOne("LigaFutbolSoftInn.App.Dominio.Estadio", "Estadio")
                        .WithMany()
                        .HasForeignKey("EstadioIdEstadio");

                    b.HasOne("LigaFutbolSoftInn.App.Dominio.Equipo", "NombreEquipoLocal")
                        .WithMany()
                        .HasForeignKey("NombreEquipoLocalIdEquipo");

                    b.HasOne("LigaFutbolSoftInn.App.Dominio.Equipo", "NombreEquipoVisitante")
                        .WithMany()
                        .HasForeignKey("NombreEquipoVisitanteIdEquipo");

                    b.Navigation("Arbitro");

                    b.Navigation("Estadio");

                    b.Navigation("NombreEquipoLocal");

                    b.Navigation("NombreEquipoVisitante");
                });
#pragma warning restore 612, 618
        }
    }
}