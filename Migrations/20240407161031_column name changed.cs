using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyRent.Migrations
{
    /// <inheritdoc />
    public partial class columnnamechanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "Area",
                table: "apartments",
                newName: "Address");

            migrationBuilder.AlterColumn<DateTime>(
                name: "availableDate",
                table: "apartments",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0929b014-5b52-4279-90f5-c1ae01035269", null, "Owner", "OWNER" },
                    { "5c693332-3e8e-45ac-a698-02d93c2815b0", null, "admin", "ADMIN" },
                    { "fff455dd-c7eb-4c45-873a-09e1ef2289bb", null, "renter", "RENTER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0929b014-5b52-4279-90f5-c1ae01035269");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5c693332-3e8e-45ac-a698-02d93c2815b0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fff455dd-c7eb-4c45-873a-09e1ef2289bb");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "apartments",
                newName: "Area");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "availableDate",
                table: "apartments",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

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
    }
}
