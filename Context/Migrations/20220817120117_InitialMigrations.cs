using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PoupaDevAPI.Context.Migrations
{
    public partial class InitialMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ObjetivosFinanceiros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValorObjetivo = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OperacaoFinanceiraId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjetivosFinanceiros", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OperacoesFinanceiras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    DataOperacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperacoesFinanceiras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OperacoesFinanceiras_ObjetivosFinanceiros_Id",
                        column: x => x.Id,
                        principalTable: "ObjetivosFinanceiros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OperacoesFinanceiras");

            migrationBuilder.DropTable(
                name: "ObjetivosFinanceiros");
        }
    }
}
