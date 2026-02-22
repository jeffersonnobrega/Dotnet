using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atendimento.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ModelagemInicialCompleta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CpfCnpjCliente",
                table: "Tickets");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "NumeroProtocolo",
                table: "Tickets",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataCriacao",
                table: "Tickets",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "AgenteId",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataAlteracao",
                table: "Tickets",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataFechamento",
                table: "Tickets",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Departamentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    CodDepartamento = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Agentes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Matricula = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DepartamentoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agentes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Agentes_Departamentos_DepartamentoId",
                        column: x => x.DepartamentoId,
                        principalTable: "Departamentos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CpfCnpjCliente = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    DepartamentoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clientes_Departamentos_DepartamentoId",
                        column: x => x.DepartamentoId,
                        principalTable: "Departamentos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_AgenteId",
                table: "Tickets",
                column: "AgenteId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ClienteId",
                table: "Tickets",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_NumeroProtocolo",
                table: "Tickets",
                column: "NumeroProtocolo",
                unique: true,
                filter: "[NumeroProtocolo] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Agentes_DepartamentoId",
                table: "Agentes",
                column: "DepartamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_DepartamentoId",
                table: "Clientes",
                column: "DepartamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Departamentos_CodDepartamento",
                table: "Departamentos",
                column: "CodDepartamento",
                unique: true,
                filter: "[CodDepartamento] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Agentes_AgenteId",
                table: "Tickets",
                column: "AgenteId",
                principalTable: "Agentes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Clientes_ClienteId",
                table: "Tickets",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Agentes_AgenteId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Clientes_ClienteId",
                table: "Tickets");

            migrationBuilder.DropTable(
                name: "Agentes");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Departamentos");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_AgenteId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_ClienteId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_NumeroProtocolo",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "AgenteId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "DataAlteracao",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "DataFechamento",
                table: "Tickets");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Tickets",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "NumeroProtocolo",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataCriacao",
                table: "Tickets",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AddColumn<string>(
                name: "CpfCnpjCliente",
                table: "Tickets",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");
        }
    }
}
