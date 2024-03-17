using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyRent.Migrations
{
    /// <inheritdoc />
    public partial class addcascade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "51951219-34c0-4959-86f8-e6e001efe085");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "543ce661-c68c-40e4-9e8e-782570de7607");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cf7d9f9d-c5d8-4cb9-a1e0-a1126029b5ca");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "84a130cc-dd33-40a2-8a1d-c07f09fe7c44", null, "Owner", "OWNER" },
                    { "86068ae7-1d81-4b34-ae80-b8f489226b8e", null, "admin", "ADMIN" },
                    { "bd5e1a12-b32b-4ca1-af62-b40b50249ff5", null, "renter", "RENTER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "84a130cc-dd33-40a2-8a1d-c07f09fe7c44");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "86068ae7-1d81-4b34-ae80-b8f489226b8e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bd5e1a12-b32b-4ca1-af62-b40b50249ff5");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "51951219-34c0-4959-86f8-e6e001efe085", null, "admin", "ADMIN" },
                    { "543ce661-c68c-40e4-9e8e-782570de7607", null, "renter", "RENTER" },
                    { "cf7d9f9d-c5d8-4cb9-a1e0-a1126029b5ca", null, "Owner", "OWNER" }
                });
        }
    }
}
