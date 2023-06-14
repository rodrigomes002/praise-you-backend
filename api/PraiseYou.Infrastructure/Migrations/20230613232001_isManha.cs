using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PraiseYou.Infrastructure.Migrations
{
    public partial class isManha : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isManha",
                table: "EscalaMusica",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isManha",
                table: "EscalaMusica");
        }
    }
}
