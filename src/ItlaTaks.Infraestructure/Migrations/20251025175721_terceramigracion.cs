using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ItlaTaks.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class terceramigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MateriaModelProfesorModel");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MateriaModelProfesorModel",
                columns: table => new
                {
                    MateriasId = table.Column<int>(type: "int", nullable: false),
                    ProfesoresId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MateriaModelProfesorModel", x => new { x.MateriasId, x.ProfesoresId });
                    table.ForeignKey(
                        name: "FK_MateriaModelProfesorModel_Materias_MateriasId",
                        column: x => x.MateriasId,
                        principalTable: "Materias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MateriaModelProfesorModel_Profesores_ProfesoresId",
                        column: x => x.ProfesoresId,
                        principalTable: "Profesores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MateriaModelProfesorModel_ProfesoresId",
                table: "MateriaModelProfesorModel",
                column: "ProfesoresId");
        }
    }
}
