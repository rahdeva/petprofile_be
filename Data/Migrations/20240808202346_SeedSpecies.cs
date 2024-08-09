using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PetProfile.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedSpecies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Species",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Dog" },
                    { 2, "Cat" },
                    { 3, "Bird" },
                    { 4, "Hamster" },
                    { 5, "Snake" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
