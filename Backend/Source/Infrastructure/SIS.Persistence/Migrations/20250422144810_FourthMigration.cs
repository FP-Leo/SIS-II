using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SIS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FourthMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3e3ac85f-c2ef-4357-89e6-b412ca17a08b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "64113cfa-5227-4881-9542-78bef916f9e9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9eac022a-fbde-4ca0-be99-7281f9ec316e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d907d606-a6d6-493f-a18d-cc714e913984");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eb2953ed-e92e-4999-9428-feda236d0d1a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fcfb2edf-918e-452a-9ba7-0043a63e6633");

            migrationBuilder.RenameColumn(
                name: "NumberOfSemesters",
                table: "Departments",
                newName: "MinYears");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "123e13dd-4a2a-4ef9-a912-dcb14d7e1e6e", null, "Administrator", "ADMINISTRATOR" },
                    { "6bf3bf40-d5aa-4a78-99a3-1ac9299114c0", null, "Admin", "ADMIN" },
                    { "9231802e-f2f0-48c7-9efb-73d6583738ab", null, "Staff", "STAFF" },
                    { "d0d5e636-08d2-49ea-b04d-0298b543926e", null, "Advisor", "ADVISOR" },
                    { "e55810a7-512f-45fc-9f65-98aae1be9d21", null, "Lecturer", "LECTURER" },
                    { "f7361dd8-5c18-4949-a2cc-492515ed0e22", null, "Student", "STUDENT" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "123e13dd-4a2a-4ef9-a912-dcb14d7e1e6e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6bf3bf40-d5aa-4a78-99a3-1ac9299114c0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9231802e-f2f0-48c7-9efb-73d6583738ab");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d0d5e636-08d2-49ea-b04d-0298b543926e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e55810a7-512f-45fc-9f65-98aae1be9d21");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f7361dd8-5c18-4949-a2cc-492515ed0e22");

            migrationBuilder.RenameColumn(
                name: "MinYears",
                table: "Departments",
                newName: "NumberOfSemesters");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3e3ac85f-c2ef-4357-89e6-b412ca17a08b", null, "Student", "STUDENT" },
                    { "64113cfa-5227-4881-9542-78bef916f9e9", null, "Lecturer", "LECTURER" },
                    { "9eac022a-fbde-4ca0-be99-7281f9ec316e", null, "Staff", "STAFF" },
                    { "d907d606-a6d6-493f-a18d-cc714e913984", null, "Administrator", "ADMINISTRATOR" },
                    { "eb2953ed-e92e-4999-9428-feda236d0d1a", null, "Admin", "ADMIN" },
                    { "fcfb2edf-918e-452a-9ba7-0043a63e6633", null, "Advisor", "ADVISOR" }
                });
        }
    }
}
