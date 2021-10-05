using Microsoft.EntityFrameworkCore.Migrations;

namespace LigaFutbolSoftInn.App.Persistencia.Migrations
{
    public partial class Inicial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Abitros_Municipios_MunicipioIdMunicipio",
                table: "Abitros");

            migrationBuilder.DropForeignKey(
                name: "FK_Partidos_Abitros_ArbitroIdArbitro",
                table: "Partidos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Abitros",
                table: "Abitros");

            migrationBuilder.DropIndex(
                name: "IX_Abitros_MunicipioIdMunicipio",
                table: "Abitros");

            migrationBuilder.DropColumn(
                name: "MunicipioIdMunicipio",
                table: "Abitros");

            migrationBuilder.RenameTable(
                name: "Abitros",
                newName: "Arbitros");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Arbitros",
                table: "Arbitros",
                column: "IdArbitro");

            migrationBuilder.AddForeignKey(
                name: "FK_Partidos_Arbitros_ArbitroIdArbitro",
                table: "Partidos",
                column: "ArbitroIdArbitro",
                principalTable: "Arbitros",
                principalColumn: "IdArbitro",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Partidos_Arbitros_ArbitroIdArbitro",
                table: "Partidos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Arbitros",
                table: "Arbitros");

            migrationBuilder.RenameTable(
                name: "Arbitros",
                newName: "Abitros");

            migrationBuilder.AddColumn<int>(
                name: "MunicipioIdMunicipio",
                table: "Abitros",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Abitros",
                table: "Abitros",
                column: "IdArbitro");

            migrationBuilder.CreateIndex(
                name: "IX_Abitros_MunicipioIdMunicipio",
                table: "Abitros",
                column: "MunicipioIdMunicipio");

            migrationBuilder.AddForeignKey(
                name: "FK_Abitros_Municipios_MunicipioIdMunicipio",
                table: "Abitros",
                column: "MunicipioIdMunicipio",
                principalTable: "Municipios",
                principalColumn: "IdMunicipio",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Partidos_Abitros_ArbitroIdArbitro",
                table: "Partidos",
                column: "ArbitroIdArbitro",
                principalTable: "Abitros",
                principalColumn: "IdArbitro",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
