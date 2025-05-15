using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SIS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class MinorChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LecturerProfile_AspNetUsers_UserId",
                table: "LecturerProfile");

            migrationBuilder.DropIndex(
                name: "IX_LecturerProfile_LecturerId",
                table: "LecturerProfile");

            migrationBuilder.DropIndex(
                name: "IX_LecturerProfile_UserId",
                table: "LecturerProfile");

            migrationBuilder.DropIndex(
                name: "IX_AdvisorProfile_UserId_DepartmentId",
                table: "AdvisorProfile");

            migrationBuilder.DropIndex(
                name: "IX_AdministratorProfile_UserId_DepartmentId",
                table: "AdministratorProfile");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "18a16a11-f8ac-47b2-84c7-993682749765");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "54cea3b5-b905-4faa-b69b-ab02b4be10c6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "64828654-a780-4d5a-8510-62204d709fb8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "82d20668-88ce-4a32-a9c1-27601b893e7e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "acf13a20-35fc-4fd9-a919-8fd19b5da846");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cbb9c0d5-1aed-4755-a624-00ecf75bf275");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e0961a83-b5a9-4731-baf1-365dd40c43e5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e1a6b5e7-09e0-4461-8d3a-2f6b45d96993");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f8d1e667-75bf-4c66-a0e8-fb37e2894599");

            migrationBuilder.DropColumn(
                name: "LecturerId",
                table: "LecturerProfile");

            migrationBuilder.AddColumn<int>(
                name: "DefaultProgramId",
                table: "StudentProfile",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "LecturerProfile",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_LecturerProfile_UserId",
                table: "LecturerProfile",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AdvisorProfile_UserId",
                table: "AdvisorProfile",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AdministratorProfile_UserId",
                table: "AdministratorProfile",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_LecturerProfile_AspNetUsers_UserId",
                table: "LecturerProfile",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LecturerProfile_AspNetUsers_UserId",
                table: "LecturerProfile");

            migrationBuilder.DropIndex(
                name: "IX_LecturerProfile_UserId",
                table: "LecturerProfile");

            migrationBuilder.DropIndex(
                name: "IX_AdvisorProfile_UserId",
                table: "AdvisorProfile");

            migrationBuilder.DropIndex(
                name: "IX_AdministratorProfile_UserId",
                table: "AdministratorProfile");

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
                name: "DefaultProgramId",
                table: "StudentProfile");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "LecturerProfile",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "LecturerId",
                table: "LecturerProfile",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "18a16a11-f8ac-47b2-84c7-993682749765", null, "Rector", "RECTOR" },
                    { "54cea3b5-b905-4faa-b69b-ab02b4be10c6", null, "SuperUser", "SUPERUSER" },
                    { "64828654-a780-4d5a-8510-62204d709fb8", null, "Staff", "STAFF" },
                    { "82d20668-88ce-4a32-a9c1-27601b893e7e", null, "Administrator", "ADMINISTRATOR" },
                    { "acf13a20-35fc-4fd9-a919-8fd19b5da846", null, "HoD", "HOD" },
                    { "cbb9c0d5-1aed-4755-a624-00ecf75bf275", null, "Dean", "DEAN" },
                    { "e0961a83-b5a9-4731-baf1-365dd40c43e5", null, "Advisor", "ADVISOR" },
                    { "e1a6b5e7-09e0-4461-8d3a-2f6b45d96993", null, "Lecturer", "LECTURER" },
                    { "f8d1e667-75bf-4c66-a0e8-fb37e2894599", null, "Student", "STUDENT" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_LecturerProfile_LecturerId",
                table: "LecturerProfile",
                column: "LecturerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LecturerProfile_UserId",
                table: "LecturerProfile",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AdvisorProfile_UserId_DepartmentId",
                table: "AdvisorProfile",
                columns: new[] { "UserId", "DepartmentId" });

            migrationBuilder.CreateIndex(
                name: "IX_AdministratorProfile_UserId_DepartmentId",
                table: "AdministratorProfile",
                columns: new[] { "UserId", "DepartmentId" });

            migrationBuilder.AddForeignKey(
                name: "FK_LecturerProfile_AspNetUsers_UserId",
                table: "LecturerProfile",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
