using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LigaFutbolSoftInn.App.Persistencia.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Municipios",
                columns: table => new
                {
                    IdMunicipio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreMunicipio = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Municipios", x => x.IdMunicipio);
                });

            migrationBuilder.CreateTable(
                name: "Abitros",
                columns: table => new
                {
                    IdArbitro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreArbitro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocumentoArbitro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelefonoArbitro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ColegioArbitro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MunicipioIdMunicipio = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abitros", x => x.IdArbitro);
                    table.ForeignKey(
                        name: "FK_Abitros_Municipios_MunicipioIdMunicipio",
                        column: x => x.MunicipioIdMunicipio,
                        principalTable: "Municipios",
                        principalColumn: "IdMunicipio",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Equipos",
                columns: table => new
                {
                    IdEquipo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreEquipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MunicipioIdMunicipio = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipos", x => x.IdEquipo);
                    table.ForeignKey(
                        name: "FK_Equipos_Municipios_MunicipioIdMunicipio",
                        column: x => x.MunicipioIdMunicipio,
                        principalTable: "Municipios",
                        principalColumn: "IdMunicipio",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Estadios",
                columns: table => new
                {
                    IdEstadio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreEstadio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DireccionEstadio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MunicipioIdMunicipio = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estadios", x => x.IdEstadio);
                    table.ForeignKey(
                        name: "FK_Estadios_Municipios_MunicipioIdMunicipio",
                        column: x => x.MunicipioIdMunicipio,
                        principalTable: "Municipios",
                        principalColumn: "IdMunicipio",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DirTecnicos",
                columns: table => new
                {
                    IdDirTecnico = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreDirTecnico = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocumentoDirTecnico = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelefonoDirTecnico = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EquipoIdEquipo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DirTecnicos", x => x.IdDirTecnico);
                    table.ForeignKey(
                        name: "FK_DirTecnicos_Equipos_EquipoIdEquipo",
                        column: x => x.EquipoIdEquipo,
                        principalTable: "Equipos",
                        principalColumn: "IdEquipo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Jugadores",
                columns: table => new
                {
                    IdJugador = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreJugador = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroJugador = table.Column<int>(type: "int", nullable: false),
                    PosicionJugador = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EquipoIdEquipo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jugadores", x => x.IdJugador);
                    table.ForeignKey(
                        name: "FK_Jugadores_Equipos_EquipoIdEquipo",
                        column: x => x.EquipoIdEquipo,
                        principalTable: "Equipos",
                        principalColumn: "IdEquipo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Partidos",
                columns: table => new
                {
                    IdPartido = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaPartido = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NombreEquipoLocalIdEquipo = table.Column<int>(type: "int", nullable: true),
                    NombreEquipoVisitanteIdEquipo = table.Column<int>(type: "int", nullable: true),
                    MarcadorLocal = table.Column<int>(type: "int", nullable: false),
                    MarcadorVisitante = table.Column<int>(type: "int", nullable: false),
                    EstadioIdEstadio = table.Column<int>(type: "int", nullable: true),
                    ArbitroIdArbitro = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partidos", x => x.IdPartido);
                    table.ForeignKey(
                        name: "FK_Partidos_Abitros_ArbitroIdArbitro",
                        column: x => x.ArbitroIdArbitro,
                        principalTable: "Abitros",
                        principalColumn: "IdArbitro",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Partidos_Equipos_NombreEquipoLocalIdEquipo",
                        column: x => x.NombreEquipoLocalIdEquipo,
                        principalTable: "Equipos",
                        principalColumn: "IdEquipo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Partidos_Equipos_NombreEquipoVisitanteIdEquipo",
                        column: x => x.NombreEquipoVisitanteIdEquipo,
                        principalTable: "Equipos",
                        principalColumn: "IdEquipo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Partidos_Estadios_EstadioIdEstadio",
                        column: x => x.EstadioIdEstadio,
                        principalTable: "Estadios",
                        principalColumn: "IdEstadio",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Novedades",
                columns: table => new
                {
                    IdNovedad = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoNovedad = table.Column<int>(type: "int", nullable: false),
                    MinutoPartidoNovedad = table.Column<int>(type: "int", nullable: false),
                    JugadorIdJugador = table.Column<int>(type: "int", nullable: true),
                    PartidoIdPartido = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Novedades", x => x.IdNovedad);
                    table.ForeignKey(
                        name: "FK_Novedades_Jugadores_JugadorIdJugador",
                        column: x => x.JugadorIdJugador,
                        principalTable: "Jugadores",
                        principalColumn: "IdJugador",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Novedades_Partidos_PartidoIdPartido",
                        column: x => x.PartidoIdPartido,
                        principalTable: "Partidos",
                        principalColumn: "IdPartido",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Abitros_MunicipioIdMunicipio",
                table: "Abitros",
                column: "MunicipioIdMunicipio");

            migrationBuilder.CreateIndex(
                name: "IX_DirTecnicos_EquipoIdEquipo",
                table: "DirTecnicos",
                column: "EquipoIdEquipo");

            migrationBuilder.CreateIndex(
                name: "IX_Equipos_MunicipioIdMunicipio",
                table: "Equipos",
                column: "MunicipioIdMunicipio");

            migrationBuilder.CreateIndex(
                name: "IX_Estadios_MunicipioIdMunicipio",
                table: "Estadios",
                column: "MunicipioIdMunicipio");

            migrationBuilder.CreateIndex(
                name: "IX_Jugadores_EquipoIdEquipo",
                table: "Jugadores",
                column: "EquipoIdEquipo");

            migrationBuilder.CreateIndex(
                name: "IX_Novedades_JugadorIdJugador",
                table: "Novedades",
                column: "JugadorIdJugador");

            migrationBuilder.CreateIndex(
                name: "IX_Novedades_PartidoIdPartido",
                table: "Novedades",
                column: "PartidoIdPartido");

            migrationBuilder.CreateIndex(
                name: "IX_Partidos_ArbitroIdArbitro",
                table: "Partidos",
                column: "ArbitroIdArbitro");

            migrationBuilder.CreateIndex(
                name: "IX_Partidos_EstadioIdEstadio",
                table: "Partidos",
                column: "EstadioIdEstadio");

            migrationBuilder.CreateIndex(
                name: "IX_Partidos_NombreEquipoLocalIdEquipo",
                table: "Partidos",
                column: "NombreEquipoLocalIdEquipo");

            migrationBuilder.CreateIndex(
                name: "IX_Partidos_NombreEquipoVisitanteIdEquipo",
                table: "Partidos",
                column: "NombreEquipoVisitanteIdEquipo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DirTecnicos");

            migrationBuilder.DropTable(
                name: "Novedades");

            migrationBuilder.DropTable(
                name: "Jugadores");

            migrationBuilder.DropTable(
                name: "Partidos");

            migrationBuilder.DropTable(
                name: "Abitros");

            migrationBuilder.DropTable(
                name: "Equipos");

            migrationBuilder.DropTable(
                name: "Estadios");

            migrationBuilder.DropTable(
                name: "Municipios");
        }
    }
}
