using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Cinema_Hope.Migrations
{
    /// <inheritdoc />
    public partial class AddRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "security",
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "55ccf601-7b66-4813-afb6-39872a374b59", "f7677b64-f56b-4ac0-89d4-c5320f052507", "User", "user" },
                    { "ae898bb8-2ea4-4ef4-9dfb-881308f60496", "fe3a632a-3829-4cae-baa1-785ccfceb59b", "Admin", "admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "security",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "55ccf601-7b66-4813-afb6-39872a374b59");

            migrationBuilder.DeleteData(
                schema: "security",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "ae898bb8-2ea4-4ef4-9dfb-881308f60496");
        }
    }
}
