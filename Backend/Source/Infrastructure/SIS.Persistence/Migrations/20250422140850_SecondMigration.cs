using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SIS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "22969a94-9acc-4579-b8cf-8080d6d19f01");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9f893544-c2e3-41e0-9e47-a46ba8034938");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a7bb2617-de08-4931-96e4-b8c3f5604f94");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "af06a715-d151-4f54-a1dd-23a422d6ea68");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e39cb473-f55f-4571-9408-96185040a823");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fdd29483-0a32-47a2-9900-d74606ef5e70");

            migrationBuilder.AddColumn<DateOnly>(
                name: "DateOfBirth",
                table: "AspNetUsers",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateOnly>(
                name: "RegisterDate",
                table: "AspNetUsers",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<int>(
                name: "SchoolID",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SchoolMail",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "18ea4d2a-9b8c-4a1c-92d8-9c236ae2c551", null, "Lecturer", "LECTURER" },
                    { "4142d94c-ebd2-4e36-98d8-e500a2b76666", null, "Staff", "STAFF" },
                    { "44e801dc-68ee-4b59-a544-e23777936676", null, "Student", "STUDENT" },
                    { "66473753-0828-4a86-9882-cb168f794929", null, "Administrator", "ADMINISTRATOR" },
                    { "b59d403e-6e39-42ae-8b87-c72caa2c0244", null, "Admin", "ADMIN" },
                    { "bf53770f-4572-43df-bd03-e781335365e5", null, "Advisor", "ADVISOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "18ea4d2a-9b8c-4a1c-92d8-9c236ae2c551");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4142d94c-ebd2-4e36-98d8-e500a2b76666");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44e801dc-68ee-4b59-a544-e23777936676");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "66473753-0828-4a86-9882-cb168f794929");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b59d403e-6e39-42ae-8b87-c72caa2c0244");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bf53770f-4572-43df-bd03-e781335365e5");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RegisterDate",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SchoolID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SchoolMail",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "22969a94-9acc-4579-b8cf-8080d6d19f01", null, "Administrator", "ADMINISTRATOR" },
                    { "9f893544-c2e3-41e0-9e47-a46ba8034938", null, "Advisor", "ADVISOR" },
                    { "a7bb2617-de08-4931-96e4-b8c3f5604f94", null, "Staff", "STAFF" },
                    { "af06a715-d151-4f54-a1dd-23a422d6ea68", null, "Student", "STUDENT" },
                    { "e39cb473-f55f-4571-9408-96185040a823", null, "Lecturer", "LECTURER" },
                    { "fdd29483-0a32-47a2-9900-d74606ef5e70", null, "Admin", "ADMIN" }
                });
        }
    }
}
