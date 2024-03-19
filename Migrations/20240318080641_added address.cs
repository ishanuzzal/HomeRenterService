using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyRent.Migrations
{
    /// <inheritdoc />
    public partial class addedaddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "Area",
                table: "apartments",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "Size",
                table: "apartments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "27ac5434-7aec-423c-a406-9d12b0c8e92e", null, "admin", "ADMIN" },
                    { "5ac00e56-9a0a-448b-ad79-1037c648537e", null, "Owner", "OWNER" },
                    { "dbef2f68-3c97-4c8d-9b75-6c1c3dead561", null, "renter", "RENTER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27ac5434-7aec-423c-a406-9d12b0c8e92e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5ac00e56-9a0a-448b-ad79-1037c648537e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dbef2f68-3c97-4c8d-9b75-6c1c3dead561");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "apartments");

            migrationBuilder.AlterColumn<int>(
                name: "Area",
                table: "apartments",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

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
    }
}
