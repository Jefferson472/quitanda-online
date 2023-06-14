using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace quitanda_online.Migrations
{
    /// <inheritdoc />
    public partial class MigrationsPendentes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Logradouro = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Numero = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
                    Complemento = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Bairro = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Cidade = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Estado = table.Column<string>(type: "TEXT", maxLength: 2, nullable: false),
                    CEP = table.Column<string>(type: "TEXT", maxLength: 11, nullable: false),
                    Referencia = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DataHoraPedido = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ValorTotal = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Situacao = table.Column<int>(type: "INTEGER", nullable: false),
                    IdCliente = table.Column<int>(type: "INTEGER", nullable: false),
                    EnderecoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pedidos_Endereco_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "Endereco",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItensPedidos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Quantidade = table.Column<float>(type: "REAL", nullable: false),
                    ValorUnitario = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    IdPedido = table.Column<int>(type: "INTEGER", nullable: false),
                    IdProduto = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItensPedidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItensPedidos_Pedidos_IdPedido",
                        column: x => x.IdPedido,
                        principalTable: "Pedidos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItensPedidos_Product_IdProduto",
                        column: x => x.IdProduto,
                        principalTable: "Product",
                        principalColumn: "IdProduct",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItensPedidos_IdPedido",
                table: "ItensPedidos",
                column: "IdPedido");

            migrationBuilder.CreateIndex(
                name: "IX_ItensPedidos_IdProduto",
                table: "ItensPedidos",
                column: "IdProduto");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_EnderecoId",
                table: "Pedidos",
                column: "EnderecoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItensPedidos");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "Endereco");
        }
    }
}
