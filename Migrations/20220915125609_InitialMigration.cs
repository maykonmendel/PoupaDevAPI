using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PoupaDevAPI.Migrations
{
    public partial class InitialMigration : Migration
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
                    ValorObjetivo = table.Column<float>(type: "real", nullable: false),
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
                    SaldoAtual = table.Column<float>(type: "real", nullable: false),
                    SaldoAnterior = table.Column<float>(type: "real", nullable: false),
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
                    Valor = table.Column<float>(type: "real", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    DataOperacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EstaDeletado = table.Column<bool>(type: "bit", nullable: false),
                    ContaObjetivoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperacoesFinanceiras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OperacoesFinanceiras_ContasObjetivos_ContaObjetivoId",
                        column: x => x.ContaObjetivoId,
                        principalTable: "ContasObjetivos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContasObjetivos_ObjetivoFinanceiroId",
                table: "ContasObjetivos",
                column: "ObjetivoFinanceiroId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OperacoesFinanceiras_ContaObjetivoId",
                table: "OperacoesFinanceiras",
                column: "ContaObjetivoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OperacoesFinanceiras");

            migrationBuilder.DropTable(
                name: "ContasObjetivos");

            migrationBuilder.DropTable(
                name: "ObjetivosFinanceiros");
        }
    }
}
