using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyRent.Migrations
{
    /// <inheritdoc />
    public partial class idautogeneration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "842c614e-e511-4994-8c08-2f15e519bc17");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a563c905-c07c-4c1a-9892-884f11d30149");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "abe2d8f4-bf81-49b5-8ad9-1ae7d5de5425");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "17a86ef6-5c0a-4706-b8a3-c974f8e36134", null, "renter", "RENTER" },
                    { "1e8bb21f-a320-41f3-9557-1727fe1b1bf9", null, "admin", "ADMIN" },
                    { "d46e79f4-fff6-4ddb-9705-093b63ce515f", null, "Owner", "OWNER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "17a86ef6-5c0a-4706-b8a3-c974f8e36134");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1e8bb21f-a320-41f3-9557-1727fe1b1bf9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d46e79f4-fff6-4ddb-9705-093b63ce515f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "842c614e-e511-4994-8c08-2f15e519bc17", null, "renter", "RENTER" },
                    { "a563c905-c07c-4c1a-9892-884f11d30149", null, "admin", "ADMIN" },
                    { "abe2d8f4-bf81-49b5-8ad9-1ae7d5de5425", null, "Owner", "OWNER" }
                });
        }
    }
}
