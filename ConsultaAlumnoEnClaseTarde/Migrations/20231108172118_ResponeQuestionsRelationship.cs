using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ConsultaAlumnos2TUP4.Migrations
{
    /// <inheritdoc />
    public partial class ResponeQuestionsRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "UserType",
                value: "Professor");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "UserType",
                value: "Professor");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "LastName", "Name", "Password", "State", "UserName", "UserType" },
                values: new object[,]
                {
                    { 4, "nbologna31@gmail.com", "Bologna", "Nicolas", "123456", true, "nbologna_profesor", "Student" },
                    { 5, "ppaez@gmail.com", "Paez", "Pablo", "123456", true, "ppaez", "Student" }
                });
        }
    }
}
