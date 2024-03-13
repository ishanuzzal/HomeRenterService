using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyRent.Migrations
{
    /// <inheritdoc />
    public partial class somechanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "images",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    uploadDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    path = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ApartmentId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_images_apartments_ApartmentId",
                        column: x => x.ApartmentId,
                        principalTable: "apartments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "407513a1-8ff0-4f8c-b6f3-1cc6e86ddc66", null, "Owner", "OWNER" },
                    { "757adc4f-47b3-4275-acf4-e574beee5a1f", null, "renter", "RENTER" },
                    { "ccc9fcc9-d01b-4806-9355-e21333684d01", null, "admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_images_ApartmentId",
                table: "images",
                column: "ApartmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "images");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "407513a1-8ff0-4f8c-b6f3-1cc6e86ddc66");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "757adc4f-47b3-4275-acf4-e574beee5a1f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ccc9fcc9-d01b-4806-9355-e21333684d01");

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
    }
}
