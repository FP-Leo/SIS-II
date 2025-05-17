using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SIS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class StudentCourseEnrollment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "555292ba-3652-42d1-89b8-26e37ca599fe");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "60a34a13-bab4-47bc-b20f-4a5e1248c045");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bc7bb7d2-6c0f-47f5-9dbf-2b5287b76975");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c49150a2-a9c7-4114-9fbf-f5bf0ff171ef");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d5ca718a-a54c-49ae-89c4-6b4186ade002");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7c3074f-b658-4878-9981-54b97ad75214");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "daf134f7-19d0-46c5-b450-885474822cf7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e2de437b-46be-4f3f-8e3a-a454fde5a437");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e9f7e7e0-f0d6-4921-a90c-414376bd7354");

            migrationBuilder.DropColumn(
                name: "AssessmentIds",
                table: "StudentCourseEnrollment");

            migrationBuilder.RenameColumn(
                name: "CompletmentDate",
                table: "StudentCourseEnrollment",
                newName: "CompletionDate");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EnrollmentDate",
                table: "StudentCourseEnrollment",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "EledgibleForMakeup",
                table: "StudentCourseEnrollment",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<int>(
                name: "AttendancePercentage",
                table: "StudentCourseEnrollment",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0a19c132-0473-4022-91c3-f87a2e786471", null, "Lecturer", "LECTURER" },
                    { "11024746-a56a-4c7c-a415-fd28ecc57cc2", null, "Rector", "RECTOR" },
                    { "2205b443-f20f-44ed-a6ee-c4b9f0b0d103", null, "Administrator", "ADMINISTRATOR" },
                    { "679dbe56-97ae-440b-9e25-18a59cd9b10c", null, "Student", "STUDENT" },
                    { "8ec1a968-9f0a-4699-bf6d-5257b5c92564", null, "HoD", "HOD" },
                    { "9d52507d-7475-4688-a7e2-238ded027738", null, "Dean", "DEAN" },
                    { "c10c5667-0acb-4f59-b4be-655f74b7b554", null, "Advisor", "ADVISOR" },
                    { "c4dab5a7-a3c6-4c60-9ba3-d9903038f8ef", null, "SuperUser", "SUPERUSER" },
                    { "dad6d63a-1bf4-4461-b9d1-b3b936afcf31", null, "Staff", "STAFF" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0a19c132-0473-4022-91c3-f87a2e786471");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "11024746-a56a-4c7c-a415-fd28ecc57cc2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2205b443-f20f-44ed-a6ee-c4b9f0b0d103");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "679dbe56-97ae-440b-9e25-18a59cd9b10c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8ec1a968-9f0a-4699-bf6d-5257b5c92564");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9d52507d-7475-4688-a7e2-238ded027738");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c10c5667-0acb-4f59-b4be-655f74b7b554");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c4dab5a7-a3c6-4c60-9ba3-d9903038f8ef");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dad6d63a-1bf4-4461-b9d1-b3b936afcf31");

            migrationBuilder.RenameColumn(
                name: "CompletionDate",
                table: "StudentCourseEnrollment",
                newName: "CompletmentDate");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EnrollmentDate",
                table: "StudentCourseEnrollment",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<bool>(
                name: "EledgibleForMakeup",
                table: "StudentCourseEnrollment",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AttendancePercentage",
                table: "StudentCourseEnrollment",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AssessmentIds",
                table: "StudentCourseEnrollment",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "555292ba-3652-42d1-89b8-26e37ca599fe", null, "HoD", "HOD" },
                    { "60a34a13-bab4-47bc-b20f-4a5e1248c045", null, "Administrator", "ADMINISTRATOR" },
                    { "bc7bb7d2-6c0f-47f5-9dbf-2b5287b76975", null, "Rector", "RECTOR" },
                    { "c49150a2-a9c7-4114-9fbf-f5bf0ff171ef", null, "Advisor", "ADVISOR" },
                    { "d5ca718a-a54c-49ae-89c4-6b4186ade002", null, "SuperUser", "SUPERUSER" },
                    { "d7c3074f-b658-4878-9981-54b97ad75214", null, "Dean", "DEAN" },
                    { "daf134f7-19d0-46c5-b450-885474822cf7", null, "Staff", "STAFF" },
                    { "e2de437b-46be-4f3f-8e3a-a454fde5a437", null, "Student", "STUDENT" },
                    { "e9f7e7e0-f0d6-4921-a90c-414376bd7354", null, "Lecturer", "LECTURER" }
                });
        }
    }
}
