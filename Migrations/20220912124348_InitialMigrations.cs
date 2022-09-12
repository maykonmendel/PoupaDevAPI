using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PoupaDevAPI.Migrations
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
                    ValorObjetivo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EstaDeletado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjetivosFinanceiros", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContasObjetivos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SaldoAtual = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SaldoAnterior = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ObjetivoFinanceiroId = table.Column<int>(type: "int", nullable: false),
                    EstaDeletado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContasObjetivos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContasObjetivos_ObjetivosFinanceiros_ObjetivoFinanceiroId",
                        column: x => x.ObjetivoFinanceiroId,
                        principalTable: "ObjetivosFinanceiros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OperacoesFinanceiras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    DataOperacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ObjetivoFinanceiroId = table.Column<int>(type: "int", nullable: false),
                    EstaDeletado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperacoesFinanceiras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OperacoesFinanceiras_ObjetivosFinanceiros_ObjetivoFinanceiroId",
                        column: x => x.ObjetivoFinanceiroId,
                        principalTable: "ObjetivosFinanceiros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContasObjetivos_ObjetivoFinanceiroId",
                table: "ContasObjetivos",
                column: "ObjetivoFinanceiroId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OperacoesFinanceiras_ObjetivoFinanceiroId",
                table: "OperacoesFinanceiras",
                column: "ObjetivoFinanceiroId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContasObjetivos");

            migrationBuilder.DropTable(
                name: "OperacoesFinanceiras");

            migrationBuilder.DropTable(
                name: "ObjetivosFinanceiros");
        }
    }
}
