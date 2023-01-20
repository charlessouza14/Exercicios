using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CRUD.Migrations
{
    public partial class AddClasseCantor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cantor",
                table: "Musicas");

            migrationBuilder.AddColumn<int>(
                name: "CantorId",
                table: "Musicas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Cantor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataDeNascimento = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cantor", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Musicas_CantorId",
                table: "Musicas",
                column: "CantorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Musicas_Cantor_CantorId",
                table: "Musicas",
                column: "CantorId",
                principalTable: "Cantor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Musicas_Cantor_CantorId",
                table: "Musicas");

            migrationBuilder.DropTable(
                name: "Cantor");

            migrationBuilder.DropIndex(
                name: "IX_Musicas_CantorId",
                table: "Musicas");

            migrationBuilder.DropColumn(
                name: "CantorId",
                table: "Musicas");

            migrationBuilder.AddColumn<string>(
                name: "Cantor",
                table: "Musicas",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
