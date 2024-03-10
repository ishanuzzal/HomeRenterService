using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyRent.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Owners_AspNetUsers_Id",
                table: "Owners");

            migrationBuilder.DropForeignKey(
                name: "FK_Renters_AspNetUsers_Id",
                table: "Renters");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "41effe72-2274-4215-8584-99bbf4870de5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5f700ddd-2b8e-4a76-acc7-8bf7bb7a4bee");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e82dbf8d-35ad-4137-8446-5bd1071254e4");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Renters",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "EmailAddress",
                table: "Renters",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "Renters",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNo",
                table: "Renters",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Renters",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Owners",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "EmailAddress",
                table: "Owners",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "Owners",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNo",
                table: "Owners",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Owners",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Renters");

            migrationBuilder.DropColumn(
                name: "EmailAddress",
                table: "Renters");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "Renters");

            migrationBuilder.DropColumn(
                name: "PhoneNo",
                table: "Renters");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Renters");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Owners");

            migrationBuilder.DropColumn(
                name: "EmailAddress",
                table: "Owners");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "Owners");

            migrationBuilder.DropColumn(
                name: "PhoneNo",
                table: "Owners");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Owners");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "AspNetUsers",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "AspNetUsers",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "41effe72-2274-4215-8584-99bbf4870de5", null, "renter", "RENTER" },
                    { "5f700ddd-2b8e-4a76-acc7-8bf7bb7a4bee", null, "admin", "ADMIN" },
                    { "e82dbf8d-35ad-4137-8446-5bd1071254e4", null, "Owner", "OWNER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Owners_AspNetUsers_Id",
                table: "Owners",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Renters_AspNetUsers_Id",
                table: "Renters",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
