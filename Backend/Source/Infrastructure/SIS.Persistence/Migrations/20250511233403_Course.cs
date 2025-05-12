using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SIS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Course : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Credits = table.Column<int>(type: "int", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateOnly>(type: "date", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PrerequisiteCourseIds = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Courses_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1058dcff-67ff-48a3-ac82-834c1f2d41d2", null, "Administrator", "ADMINISTRATOR" },
                    { "2a5ff440-f3bd-4dd2-b160-46a3dec657b9", null, "Advisor", "ADVISOR" },
                    { "386a25e2-04c9-4097-90ce-14fa5b6bb7de", null, "Lecturer", "LECTURER" },
                    { "3bbdc8ba-b63d-4612-8b63-8fe37f5e8907", null, "Dean", "DEAN" },
                    { "6ca2fa6f-6015-45c6-bb97-1f3df556735c", null, "SuperUser", "SUPERUSER" },
                    { "a9f51001-4171-43e2-8133-b34c15c1b2ae", null, "Rector", "RECTOR" },
                    { "aef77472-6edd-4157-9bcf-d028541ba863", null, "Student", "STUDENT" },
                    { "ce238438-3664-4502-a90a-9b1fd8c4cb51", null, "Staff", "STAFF" },
                    { "fd6d70d4-e3ed-4c19-b684-8e365280741a", null, "HoD", "HOD" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CourseId",
                table: "Courses",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_DepartmentId",
                table: "Courses",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_Name",
                table: "Courses",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1058dcff-67ff-48a3-ac82-834c1f2d41d2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2a5ff440-f3bd-4dd2-b160-46a3dec657b9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "386a25e2-04c9-4097-90ce-14fa5b6bb7de");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3bbdc8ba-b63d-4612-8b63-8fe37f5e8907");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6ca2fa6f-6015-45c6-bb97-1f3df556735c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a9f51001-4171-43e2-8133-b34c15c1b2ae");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aef77472-6edd-4157-9bcf-d028541ba863");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ce238438-3664-4502-a90a-9b1fd8c4cb51");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fd6d70d4-e3ed-4c19-b684-8e365280741a");

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
        }
    }
}
