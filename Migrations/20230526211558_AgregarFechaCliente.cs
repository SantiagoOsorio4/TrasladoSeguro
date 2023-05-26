using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrasladoSeguro.Migrations
{
    /// <inheritdoc />
    public partial class AgregarFechaCliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Fecha",
                table: "Clientes",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fecha",
                table: "Clientes");
        }
    }
}
