using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PraiseYou.Infrastructure.Migrations
{
    public partial class alterandoRelacionamentoEscala : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Musicas_Escalas_EscalaId",
                table: "Musicas");

            migrationBuilder.DropForeignKey(
                name: "FK_Musicos_Escalas_EscalaId",
                table: "Musicos");

            migrationBuilder.DropIndex(
                name: "IX_Musicos_EscalaId",
                table: "Musicos");

            migrationBuilder.DropIndex(
                name: "IX_Musicas_EscalaId",
                table: "Musicas");

            migrationBuilder.DropColumn(
                name: "EscalaId",
                table: "Musicos");

            migrationBuilder.DropColumn(
                name: "EscalaId",
                table: "Musicas");

            migrationBuilder.CreateTable(
                name: "EscalaItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MusicaId = table.Column<int>(type: "int", nullable: true),
                    MusicoId = table.Column<int>(type: "int", nullable: true),
                    EscalaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EscalaItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EscalaItem_Escalas_EscalaId",
                        column: x => x.EscalaId,
                        principalTable: "Escalas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EscalaItem_Musicas_MusicaId",
                        column: x => x.MusicaId,
                        principalTable: "Musicas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EscalaItem_Musicos_MusicoId",
                        column: x => x.MusicoId,
                        principalTable: "Musicos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_EscalaItem_EscalaId",
                table: "EscalaItem",
                column: "EscalaId");

            migrationBuilder.CreateIndex(
                name: "IX_EscalaItem_MusicaId",
                table: "EscalaItem",
                column: "MusicaId");

            migrationBuilder.CreateIndex(
                name: "IX_EscalaItem_MusicoId",
                table: "EscalaItem",
                column: "MusicoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EscalaItem");

            migrationBuilder.AddColumn<int>(
                name: "EscalaId",
                table: "Musicos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EscalaId",
                table: "Musicas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Musicos_EscalaId",
                table: "Musicos",
                column: "EscalaId");

            migrationBuilder.CreateIndex(
                name: "IX_Musicas_EscalaId",
                table: "Musicas",
                column: "EscalaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Musicas_Escalas_EscalaId",
                table: "Musicas",
                column: "EscalaId",
                principalTable: "Escalas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Musicos_Escalas_EscalaId",
                table: "Musicos",
                column: "EscalaId",
                principalTable: "Escalas",
                principalColumn: "Id");
        }
    }
}
