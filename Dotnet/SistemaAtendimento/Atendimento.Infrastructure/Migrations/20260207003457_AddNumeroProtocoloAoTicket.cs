using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atendimento.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddNumeroProtocoloAoTicket : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NumeroProtocolo",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumeroProtocolo",
                table: "Tickets");
        }
    }
}
