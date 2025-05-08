using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SIS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SeventhMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0fce6691-e5c6-45b3-82d8-fc7893d6382b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26cc7fe8-1d01-4f13-9899-7647d818a177");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2f827d36-28be-45c3-95a2-12d4b1e6db8e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6d004b96-097f-4851-b6c5-2cca23aeecbf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "95622ea3-ef64-48b5-a1aa-4bb14b8f907c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a2399a9f-24fd-476f-abdc-88fbbf76042e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "12bf1bff-1187-43ea-9f96-186885e2e64f", null, "Staff", "STAFF" },
                    { "13b7f491-0c3f-4a3b-ae21-967fefb3d2f8", null, "Dean", "DEAN" },
                    { "2d7f4304-e5bc-42c9-b2a1-617bf7aa3b5b", null, "Administrator", "ADMINISTRATOR" },
                    { "3af2f28c-78e3-4421-8399-532d80719cf3", null, "Rector", "RECTOR" },
                    { "82d8adc2-efe1-47c6-9538-8d794fda2dc1", null, "Lecturer", "LECTURER" },
                    { "8f890471-1b7d-4296-bce8-07aeb3df1537", null, "HoD", "HOD" },
                    { "91fa22d1-5b1d-4b55-837c-f798ae42d01a", null, "Student", "STUDENT" },
                    { "e305e512-ca40-4363-8063-e8b9d70debf0", null, "Advisor", "ADVISOR" },
                    { "ec2837a8-ac81-4a74-b6e9-c2b587eab481", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "12bf1bff-1187-43ea-9f96-186885e2e64f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "13b7f491-0c3f-4a3b-ae21-967fefb3d2f8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2d7f4304-e5bc-42c9-b2a1-617bf7aa3b5b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3af2f28c-78e3-4421-8399-532d80719cf3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "82d8adc2-efe1-47c6-9538-8d794fda2dc1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8f890471-1b7d-4296-bce8-07aeb3df1537");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "91fa22d1-5b1d-4b55-837c-f798ae42d01a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e305e512-ca40-4363-8063-e8b9d70debf0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ec2837a8-ac81-4a74-b6e9-c2b587eab481");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0fce6691-e5c6-45b3-82d8-fc7893d6382b", null, "Lecturer", "LECTURER" },
                    { "26cc7fe8-1d01-4f13-9899-7647d818a177", null, "Admin", "ADMIN" },
                    { "2f827d36-28be-45c3-95a2-12d4b1e6db8e", null, "Staff", "STAFF" },
                    { "6d004b96-097f-4851-b6c5-2cca23aeecbf", null, "Administrator", "ADMINISTRATOR" },
                    { "95622ea3-ef64-48b5-a1aa-4bb14b8f907c", null, "Advisor", "ADVISOR" },
                    { "a2399a9f-24fd-476f-abdc-88fbbf76042e", null, "Student", "STUDENT" }
                });
        }
    }
}
