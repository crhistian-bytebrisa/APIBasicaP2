using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ItlaTaks.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class Entities2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MateriaId",
                table: "Tareas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tareas_MateriaId",
                table: "Tareas",
                column: "MateriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tareas_Materia_MateriaId",
                table: "Tareas",
                column: "MateriaId",
                principalTable: "Materia",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tareas_Materia_MateriaId",
                table: "Tareas");

            migrationBuilder.DropIndex(
                name: "IX_Tareas_MateriaId",
                table: "Tareas");

            migrationBuilder.DropColumn(
                name: "MateriaId",
                table: "Tareas");
        }
    }
}
