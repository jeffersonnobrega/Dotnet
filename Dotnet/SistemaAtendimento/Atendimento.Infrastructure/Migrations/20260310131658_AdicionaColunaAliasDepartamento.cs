using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atendimento.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AdicionaColunaAliasDepartamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Alias",
                table: "Departamentos",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Departamentos_Alias",
                table: "Departamentos",
                column: "Alias",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Departamentos_Alias",
                table: "Departamentos");

            migrationBuilder.DropColumn(
                name: "Alias",
                table: "Departamentos");
        }
    }
}
