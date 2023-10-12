using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsultaAlumnoEnClaseTarde.Migrations
{
    /// <inheritdoc />
    public partial class RoomInSubject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Quarter",
                table: "Subjects",
                newName: "Room");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Room",
                table: "Subjects",
                newName: "Quarter");
        }
    }
}
