using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SIS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class DropDomain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Departments_Code",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Departments_Name_FacultyId",
                table: "Departments");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0a54cc89-df96-41b6-8a89-d35b3b506430");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "198b9c2a-c098-4b1e-a104-df2bf8fe5936");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1cdeba1c-4b25-4875-a73c-75bc2ef082f5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "35c18f46-c918-43fb-9a02-4bdefff6b3c4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5010a761-33c2-425e-a1f1-cea713c1dd8e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "64090d57-4411-4711-a4fd-6f2a09c9e34d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7d3630aa-9ae8-407a-8802-8296e7dd6aeb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a4560a1f-01ea-46b8-b48f-346789e18796");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b0f39858-5a08-45dc-b710-6461fa9608c9");

            migrationBuilder.DropColumn(
                name: "Domain",
                table: "Universities");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Departments",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Departments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Departments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "19bc85c1-563d-45b2-b823-0ac257a65ba3", null, "Rector", "RECTOR" },
                    { "1f892514-4f8b-4249-b921-0e791bc35103", null, "SuperUser", "SUPERUSER" },
                    { "542d9916-0fb0-4644-bcec-ee0d168223d8", null, "Staff", "STAFF" },
                    { "708fa54c-5bc0-4485-a756-55cee1238b0b", null, "Lecturer", "LECTURER" },
                    { "799d520a-4143-4bd6-a3ef-81f79d874f02", null, "HoD", "HOD" },
                    { "7d272f7e-1b6e-4ae7-98c9-6db1dd9844fc", null, "Student", "STUDENT" },
                    { "adbc2da8-8a53-4234-be53-e59ce8ca0401", null, "Advisor", "ADVISOR" },
                    { "d0fa7113-f902-48ca-afa7-bc8bd845ec05", null, "Administrator", "ADMINISTRATOR" },
                    { "f55df943-e5b0-49ce-86af-d0393ed00df9", null, "Dean", "DEAN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Departments_PhoneNumber",
                table: "Departments",
                column: "PhoneNumber",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Departments_PhoneNumber",
                table: "Departments");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "19bc85c1-563d-45b2-b823-0ac257a65ba3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1f892514-4f8b-4249-b921-0e791bc35103");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "542d9916-0fb0-4644-bcec-ee0d168223d8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "708fa54c-5bc0-4485-a756-55cee1238b0b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "799d520a-4143-4bd6-a3ef-81f79d874f02");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7d272f7e-1b6e-4ae7-98c9-6db1dd9844fc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "adbc2da8-8a53-4234-be53-e59ce8ca0401");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d0fa7113-f902-48ca-afa7-bc8bd845ec05");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f55df943-e5b0-49ce-86af-d0393ed00df9");

            migrationBuilder.AddColumn<string>(
                name: "Domain",
                table: "Universities",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Departments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Departments",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Departments",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0a54cc89-df96-41b6-8a89-d35b3b506430", null, "Staff", "STAFF" },
                    { "198b9c2a-c098-4b1e-a104-df2bf8fe5936", null, "Advisor", "ADVISOR" },
                    { "1cdeba1c-4b25-4875-a73c-75bc2ef082f5", null, "Administrator", "ADMINISTRATOR" },
                    { "35c18f46-c918-43fb-9a02-4bdefff6b3c4", null, "Rector", "RECTOR" },
                    { "5010a761-33c2-425e-a1f1-cea713c1dd8e", null, "Dean", "DEAN" },
                    { "64090d57-4411-4711-a4fd-6f2a09c9e34d", null, "Student", "STUDENT" },
                    { "7d3630aa-9ae8-407a-8802-8296e7dd6aeb", null, "Lecturer", "LECTURER" },
                    { "a4560a1f-01ea-46b8-b48f-346789e18796", null, "HoD", "HOD" },
                    { "b0f39858-5a08-45dc-b710-6461fa9608c9", null, "SuperUser", "SUPERUSER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Departments_Code",
                table: "Departments",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Departments_Name_FacultyId",
                table: "Departments",
                columns: new[] { "Name", "FacultyId" },
                unique: true);
        }
    }
}
