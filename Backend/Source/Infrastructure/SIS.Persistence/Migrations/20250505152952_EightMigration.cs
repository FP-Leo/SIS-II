using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SIS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class EightMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Faculties_Universities_UniId",
                table: "Faculties");

            migrationBuilder.DropIndex(
                name: "IX_Faculties_Code",
                table: "Faculties");

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

            migrationBuilder.RenameColumn(
                name: "UniId",
                table: "Faculties",
                newName: "UniversityId");

            migrationBuilder.RenameIndex(
                name: "IX_Faculties_UniId_Name",
                table: "Faculties",
                newName: "IX_Faculties_UniversityId_Name");

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
                name: "IX_Faculties_UniversityId_Code",
                table: "Faculties",
                columns: new[] { "UniversityId", "Code" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Faculties_Universities_UniversityId",
                table: "Faculties",
                column: "UniversityId",
                principalTable: "Universities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Faculties_Universities_UniversityId",
                table: "Faculties");

            migrationBuilder.DropIndex(
                name: "IX_Faculties_UniversityId_Code",
                table: "Faculties");

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

            migrationBuilder.RenameColumn(
                name: "UniversityId",
                table: "Faculties",
                newName: "UniId");

            migrationBuilder.RenameIndex(
                name: "IX_Faculties_UniversityId_Name",
                table: "Faculties",
                newName: "IX_Faculties_UniId_Name");

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

            migrationBuilder.CreateIndex(
                name: "IX_Faculties_Code",
                table: "Faculties",
                column: "Code",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Faculties_Universities_UniId",
                table: "Faculties",
                column: "UniId",
                principalTable: "Universities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
