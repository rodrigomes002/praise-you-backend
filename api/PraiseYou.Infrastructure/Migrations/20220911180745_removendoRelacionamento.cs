using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PraiseYou.Infrastructure.Migrations
{
    public partial class removendoRelacionamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Musicas_Escalas_EscalaId",
                table: "Musicas");

            migrationBuilder.DropForeignKey(
                name: "FK_Musicos_Escalas_EscalaId",
                table: "Musicos");

            migrationBuilder.DeleteData(
                table: "Musicas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Musicos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Escalas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AlterColumn<int>(
                name: "EscalaId",
                table: "Musicos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "EscalaId",
                table: "Musicas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Musicas_Escalas_EscalaId",
                table: "Musicas",
                column: "EscalaId",
                principalTable: "Escalas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Musicos_Escalas_EscalaId",
                table: "Musicos",
                column: "EscalaId",
                principalTable: "Escalas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Musicas_Escalas_EscalaId",
                table: "Musicas");

            migrationBuilder.DropForeignKey(
                name: "FK_Musicos_Escalas_EscalaId",
                table: "Musicos");

            migrationBuilder.AlterColumn<int>(
                name: "EscalaId",
                table: "Musicos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EscalaId",
                table: "Musicas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Escalas",
                columns: new[] { "Id", "DataEnsaio", "DataParticipacao" },
                values: new object[] { 1, new DateTime(2022, 1, 23, 12, 27, 15, 801, DateTimeKind.Local).AddTicks(9635), new DateTime(2022, 1, 23, 12, 27, 15, 804, DateTimeKind.Local).AddTicks(690) });

            migrationBuilder.InsertData(
                table: "Musicas",
                columns: new[] { "Id", "Artista", "EscalaId", "Nome", "Tom" },
                values: new object[] { 1, "Oficina G3", 1, "O Tempo", "C" });

            migrationBuilder.InsertData(
                table: "Musicos",
                columns: new[] { "Id", "EscalaId", "Instrumento", "Nome" },
                values: new object[] { 1, 1, "Guitarra", "Rodrigo" });

            migrationBuilder.AddForeignKey(
                name: "FK_Musicas_Escalas_EscalaId",
                table: "Musicas",
                column: "EscalaId",
                principalTable: "Escalas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Musicos_Escalas_EscalaId",
                table: "Musicos",
                column: "EscalaId",
                principalTable: "Escalas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
