using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrasladoSeguro.Migrations
{
    /// <inheritdoc />
    public partial class Conductor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Servicios_ServicioIdservicio",
                table: "Clientes");

            migrationBuilder.AlterColumn<int>(
                name: "ServicioIdservicio",
                table: "Clientes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ConductorId",
                table: "Clientes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Conductor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conductor", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_ConductorId",
                table: "Clientes",
                column: "ConductorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Conductor_ConductorId",
                table: "Clientes",
                column: "ConductorId",
                principalTable: "Conductor",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Servicios_ServicioIdservicio",
                table: "Clientes",
                column: "ServicioIdservicio",
                principalTable: "Servicios",
                principalColumn: "Idservicio");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Conductor_ConductorId",
                table: "Clientes");

            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Servicios_ServicioIdservicio",
                table: "Clientes");

            migrationBuilder.DropTable(
                name: "Conductor");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_ConductorId",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "ConductorId",
                table: "Clientes");

            migrationBuilder.AlterColumn<int>(
                name: "ServicioIdservicio",
                table: "Clientes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Servicios_ServicioIdservicio",
                table: "Clientes",
                column: "ServicioIdservicio",
                principalTable: "Servicios",
                principalColumn: "Idservicio",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
