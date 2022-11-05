using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PraiseYou.Infrastructure.Migrations
{
    public partial class criandoTabelaDeRelacionamentoEscala : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Musica_Escala_EscalaId",
                table: "Musica");

            migrationBuilder.DropForeignKey(
                name: "FK_Musico_Escala_EscalaId",
                table: "Musico");

            migrationBuilder.DropIndex(
                name: "IX_Musico_EscalaId",
                table: "Musico");

            migrationBuilder.DropIndex(
                name: "IX_Musica_EscalaId",
                table: "Musica");

            migrationBuilder.DropColumn(
                name: "EscalaId",
                table: "Musico");

            migrationBuilder.DropColumn(
                name: "EscalaId",
                table: "Musica");

            migrationBuilder.CreateTable(
                name: "EscalaMusica",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Artista = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EscalaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EscalaMusica", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EscalaMusica_Escala_EscalaId",
                        column: x => x.EscalaId,
                        principalTable: "Escala",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EscalaMusico",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Instrumento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EscalaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EscalaMusico", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EscalaMusico_Escala_EscalaId",
                        column: x => x.EscalaId,
                        principalTable: "Escala",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_EscalaMusica_EscalaId",
                table: "EscalaMusica",
                column: "EscalaId");

            migrationBuilder.CreateIndex(
                name: "IX_EscalaMusico_EscalaId",
                table: "EscalaMusico",
                column: "EscalaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EscalaMusica");

            migrationBuilder.DropTable(
                name: "EscalaMusico");

            migrationBuilder.AddColumn<int>(
                name: "EscalaId",
                table: "Musico",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EscalaId",
                table: "Musica",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Musico_EscalaId",
                table: "Musico",
                column: "EscalaId");

            migrationBuilder.CreateIndex(
                name: "IX_Musica_EscalaId",
                table: "Musica",
                column: "EscalaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Musica_Escala_EscalaId",
                table: "Musica",
                column: "EscalaId",
                principalTable: "Escala",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Musico_Escala_EscalaId",
                table: "Musico",
                column: "EscalaId",
                principalTable: "Escala",
                principalColumn: "Id");
        }
    }
}
