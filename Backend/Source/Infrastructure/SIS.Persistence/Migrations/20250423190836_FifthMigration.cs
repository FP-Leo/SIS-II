using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SIS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FifthMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_AspNetUsers_HeadOfDepartmentID",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Faculties_FacultyID",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Faculties_AspNetUsers_DeanID",
                table: "Faculties");

            migrationBuilder.DropForeignKey(
                name: "FK_Faculties_Universities_UniID",
                table: "Faculties");

            migrationBuilder.DropForeignKey(
                name: "FK_Universities_AspNetUsers_RectorID",
                table: "Universities");

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
                name: "RectorID",
                table: "Universities",
                newName: "RectorId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Universities",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Universities_RectorID",
                table: "Universities",
                newName: "IX_Universities_RectorId");

            migrationBuilder.RenameColumn(
                name: "UniID",
                table: "Faculties",
                newName: "UniId");

            migrationBuilder.RenameColumn(
                name: "DeanID",
                table: "Faculties",
                newName: "DeanId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Faculties",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Faculties_UniID_Name",
                table: "Faculties",
                newName: "IX_Faculties_UniId_Name");

            migrationBuilder.RenameIndex(
                name: "IX_Faculties_DeanID",
                table: "Faculties",
                newName: "IX_Faculties_DeanId");

            migrationBuilder.RenameColumn(
                name: "HeadOfDepartmentID",
                table: "Departments",
                newName: "HeadOfDepartmentId");

            migrationBuilder.RenameColumn(
                name: "FacultyID",
                table: "Departments",
                newName: "FacultyId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Departments",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Departments_Name_FacultyID",
                table: "Departments",
                newName: "IX_Departments_Name_FacultyId");

            migrationBuilder.RenameIndex(
                name: "IX_Departments_HeadOfDepartmentID",
                table: "Departments",
                newName: "IX_Departments_HeadOfDepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Departments_FacultyID",
                table: "Departments",
                newName: "IX_Departments_FacultyId");

            migrationBuilder.RenameColumn(
                name: "SchoolID",
                table: "AspNetUsers",
                newName: "SchoolId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "05bf9501-2feb-4c2e-b3bf-bdf5bf6765cd", null, "Admin", "ADMIN" },
                    { "0d025f50-60c5-406e-9cff-0e731a693b27", null, "Advisor", "ADVISOR" },
                    { "485952d1-9eac-4122-ba2e-aceada7a5452", null, "Lecturer", "LECTURER" },
                    { "580221d5-b6f9-495f-b922-bdfa9c1e8ea9", null, "Staff", "STAFF" },
                    { "76e02293-fdc5-4034-b35d-b5fcdb0b160c", null, "Administrator", "ADMINISTRATOR" },
                    { "a60d0042-c719-469a-8903-0a41c2d5a4c7", null, "Student", "STUDENT" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_AspNetUsers_HeadOfDepartmentId",
                table: "Departments",
                column: "HeadOfDepartmentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Faculties_FacultyId",
                table: "Departments",
                column: "FacultyId",
                principalTable: "Faculties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Faculties_AspNetUsers_DeanId",
                table: "Faculties",
                column: "DeanId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Faculties_Universities_UniId",
                table: "Faculties",
                column: "UniId",
                principalTable: "Universities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Universities_AspNetUsers_RectorId",
                table: "Universities",
                column: "RectorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_AspNetUsers_HeadOfDepartmentId",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Faculties_FacultyId",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Faculties_AspNetUsers_DeanId",
                table: "Faculties");

            migrationBuilder.DropForeignKey(
                name: "FK_Faculties_Universities_UniId",
                table: "Faculties");

            migrationBuilder.DropForeignKey(
                name: "FK_Universities_AspNetUsers_RectorId",
                table: "Universities");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "05bf9501-2feb-4c2e-b3bf-bdf5bf6765cd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0d025f50-60c5-406e-9cff-0e731a693b27");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "485952d1-9eac-4122-ba2e-aceada7a5452");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "580221d5-b6f9-495f-b922-bdfa9c1e8ea9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "76e02293-fdc5-4034-b35d-b5fcdb0b160c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a60d0042-c719-469a-8903-0a41c2d5a4c7");

            migrationBuilder.RenameColumn(
                name: "RectorId",
                table: "Universities",
                newName: "RectorID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Universities",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_Universities_RectorId",
                table: "Universities",
                newName: "IX_Universities_RectorID");

            migrationBuilder.RenameColumn(
                name: "UniId",
                table: "Faculties",
                newName: "UniID");

            migrationBuilder.RenameColumn(
                name: "DeanId",
                table: "Faculties",
                newName: "DeanID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Faculties",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_Faculties_UniId_Name",
                table: "Faculties",
                newName: "IX_Faculties_UniID_Name");

            migrationBuilder.RenameIndex(
                name: "IX_Faculties_DeanId",
                table: "Faculties",
                newName: "IX_Faculties_DeanID");

            migrationBuilder.RenameColumn(
                name: "HeadOfDepartmentId",
                table: "Departments",
                newName: "HeadOfDepartmentID");

            migrationBuilder.RenameColumn(
                name: "FacultyId",
                table: "Departments",
                newName: "FacultyID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Departments",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_Departments_Name_FacultyId",
                table: "Departments",
                newName: "IX_Departments_Name_FacultyID");

            migrationBuilder.RenameIndex(
                name: "IX_Departments_HeadOfDepartmentId",
                table: "Departments",
                newName: "IX_Departments_HeadOfDepartmentID");

            migrationBuilder.RenameIndex(
                name: "IX_Departments_FacultyId",
                table: "Departments",
                newName: "IX_Departments_FacultyID");

            migrationBuilder.RenameColumn(
                name: "SchoolId",
                table: "AspNetUsers",
                newName: "SchoolID");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_AspNetUsers_HeadOfDepartmentID",
                table: "Departments",
                column: "HeadOfDepartmentID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Faculties_FacultyID",
                table: "Departments",
                column: "FacultyID",
                principalTable: "Faculties",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Faculties_AspNetUsers_DeanID",
                table: "Faculties",
                column: "DeanID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Faculties_Universities_UniID",
                table: "Faculties",
                column: "UniID",
                principalTable: "Universities",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Universities_AspNetUsers_RectorID",
                table: "Universities",
                column: "RectorID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
