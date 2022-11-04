using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PraiseYou.Infrastructure.Migrations
{
    public partial class alterandoNomeDasTabelas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EscalaItem_Escalas_EscalaId",
                table: "EscalaItem");

            migrationBuilder.DropForeignKey(
                name: "FK_EscalaItem_Musicas_MusicaId",
                table: "EscalaItem");

            migrationBuilder.DropForeignKey(
                name: "FK_EscalaItem_Musicos_MusicoId",
                table: "EscalaItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Musicos",
                table: "Musicos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Musicas",
                table: "Musicas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Escalas",
                table: "Escalas");

            migrationBuilder.RenameTable(
                name: "Musicos",
                newName: "Musico");

            migrationBuilder.RenameTable(
                name: "Musicas",
                newName: "Musica");

            migrationBuilder.RenameTable(
                name: "Escalas",
                newName: "Escala");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Musico",
                table: "Musico",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Musica",
                table: "Musica",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Escala",
                table: "Escala",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EscalaItem_Escala_EscalaId",
                table: "EscalaItem",
                column: "EscalaId",
                principalTable: "Escala",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EscalaItem_Musica_MusicaId",
                table: "EscalaItem",
                column: "MusicaId",
                principalTable: "Musica",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EscalaItem_Musico_MusicoId",
                table: "EscalaItem",
                column: "MusicoId",
                principalTable: "Musico",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EscalaItem_Escala_EscalaId",
                table: "EscalaItem");

            migrationBuilder.DropForeignKey(
                name: "FK_EscalaItem_Musica_MusicaId",
                table: "EscalaItem");

            migrationBuilder.DropForeignKey(
                name: "FK_EscalaItem_Musico_MusicoId",
                table: "EscalaItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Musico",
                table: "Musico");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Musica",
                table: "Musica");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Escala",
                table: "Escala");

            migrationBuilder.RenameTable(
                name: "Musico",
                newName: "Musicos");

            migrationBuilder.RenameTable(
                name: "Musica",
                newName: "Musicas");

            migrationBuilder.RenameTable(
                name: "Escala",
                newName: "Escalas");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Musicos",
                table: "Musicos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Musicas",
                table: "Musicas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Escalas",
                table: "Escalas",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EscalaItem_Escalas_EscalaId",
                table: "EscalaItem",
                column: "EscalaId",
                principalTable: "Escalas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EscalaItem_Musicas_MusicaId",
                table: "EscalaItem",
                column: "MusicaId",
                principalTable: "Musicas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EscalaItem_Musicos_MusicoId",
                table: "EscalaItem",
                column: "MusicoId",
                principalTable: "Musicos",
                principalColumn: "Id");
        }
    }
}
