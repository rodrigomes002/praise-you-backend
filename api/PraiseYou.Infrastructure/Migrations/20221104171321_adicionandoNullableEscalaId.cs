using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PraiseYou.Infrastructure.Migrations
{
    public partial class adicionandoNullableEscalaId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Musica_Escala_EscalaId",
                table: "Musica");

            migrationBuilder.DropForeignKey(
                name: "FK_Musico_Escala_EscalaId",
                table: "Musico");

            migrationBuilder.AlterColumn<int>(
                name: "EscalaId",
                table: "Musico",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "EscalaId",
                table: "Musica",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Musica_Escala_EscalaId",
                table: "Musica");

            migrationBuilder.DropForeignKey(
                name: "FK_Musico_Escala_EscalaId",
                table: "Musico");

            migrationBuilder.AlterColumn<int>(
                name: "EscalaId",
                table: "Musico",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EscalaId",
                table: "Musica",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Musica_Escala_EscalaId",
                table: "Musica",
                column: "EscalaId",
                principalTable: "Escala",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Musico_Escala_EscalaId",
                table: "Musico",
                column: "EscalaId",
                principalTable: "Escala",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
