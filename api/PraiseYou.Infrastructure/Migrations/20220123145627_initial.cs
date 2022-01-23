using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PraiseYou.Infrastructure.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Escalas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataParticipacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataEnsaio = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Escalas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Musicas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Artista = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EscalaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musicas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Musicas_Escalas_EscalaId",
                        column: x => x.EscalaId,
                        principalTable: "Escalas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Musicos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Instrumento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EscalaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musicos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Musicos_Escalas_EscalaId",
                        column: x => x.EscalaId,
                        principalTable: "Escalas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Escalas",
                columns: new[] { "Id", "DataEnsaio", "DataParticipacao" },
                values: new object[] { 1, new DateTime(2022, 1, 23, 11, 56, 27, 334, DateTimeKind.Local).AddTicks(6249), new DateTime(2022, 1, 23, 11, 56, 27, 336, DateTimeKind.Local).AddTicks(5909) });

            migrationBuilder.InsertData(
                table: "Musicas",
                columns: new[] { "Id", "Artista", "EscalaId", "Nome", "Tom" },
                values: new object[] { 1, "Oficina G3", 1, "O Tempo", "C" });

            migrationBuilder.InsertData(
                table: "Musicos",
                columns: new[] { "Id", "EscalaId", "Instrumento", "Nome" },
                values: new object[] { 1, 1, "Guitarra", "Rodrigo" });

            migrationBuilder.CreateIndex(
                name: "IX_Musicas_EscalaId",
                table: "Musicas",
                column: "EscalaId");

            migrationBuilder.CreateIndex(
                name: "IX_Musicos_EscalaId",
                table: "Musicos",
                column: "EscalaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Musicas");

            migrationBuilder.DropTable(
                name: "Musicos");

            migrationBuilder.DropTable(
                name: "Escalas");
        }
    }
}
