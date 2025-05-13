using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SIS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AdvisorAdministratorProfiles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AcademicProgram_CampusBuilding_CampusId",
                table: "AcademicProgram");

            migrationBuilder.DropIndex(
                name: "IX_AcademicProgram_CampusId",
                table: "AcademicProgram");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3076678c-a847-41ef-afde-2d8d9e5b3c3d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7ee75cda-06b8-4ff9-91c2-7fb33b8314cf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7fe9b441-ebf8-49da-802c-552ea4aec608");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b173dd69-4f66-415b-86b0-80b96a631fad");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b2accb25-2925-4626-bcd0-d5cdffef775e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f0dfd368-972f-4bf6-aeb7-3b95dea2e34c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fb2762fd-7506-4515-8731-e6948a3a6d1f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fbc1ddd4-ae7f-4e05-9628-07de5d0a74ff");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fc3b95af-4d6c-4153-8e54-ea849c97ba8a");

            migrationBuilder.AddColumn<int>(
                name: "AdvisorId",
                table: "StudentProgramEnrollment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AdminProfileId",
                table: "CourseInstance",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CampusBuildingId",
                table: "AcademicProgram",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AdministratorProfile",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdministratorProfile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdministratorProfile_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AdministratorProfile_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AdvisorProfile",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvisorProfile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdvisorProfile_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AdvisorProfile_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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
                name: "IX_StudentProgramEnrollment_AdvisorId",
                table: "StudentProgramEnrollment",
                column: "AdvisorId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseInstance_AdminProfileId",
                table: "CourseInstance",
                column: "AdminProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_AcademicProgram_CampusBuildingId",
                table: "AcademicProgram",
                column: "CampusBuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_AdministratorProfile_DepartmentId",
                table: "AdministratorProfile",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_AdministratorProfile_UserId_DepartmentId",
                table: "AdministratorProfile",
                columns: new[] { "UserId", "DepartmentId" });

            migrationBuilder.CreateIndex(
                name: "IX_AdvisorProfile_DepartmentId",
                table: "AdvisorProfile",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_AdvisorProfile_UserId_DepartmentId",
                table: "AdvisorProfile",
                columns: new[] { "UserId", "DepartmentId" });

            migrationBuilder.AddForeignKey(
                name: "FK_AcademicProgram_CampusBuilding_CampusBuildingId",
                table: "AcademicProgram",
                column: "CampusBuildingId",
                principalTable: "CampusBuilding",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseInstance_AdministratorProfile_AdminProfileId",
                table: "CourseInstance",
                column: "AdminProfileId",
                principalTable: "AdministratorProfile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentProgramEnrollment_AdvisorProfile_AdvisorId",
                table: "StudentProgramEnrollment",
                column: "AdvisorId",
                principalTable: "AdvisorProfile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AcademicProgram_CampusBuilding_CampusBuildingId",
                table: "AcademicProgram");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseInstance_AdministratorProfile_AdminProfileId",
                table: "CourseInstance");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentProgramEnrollment_AdvisorProfile_AdvisorId",
                table: "StudentProgramEnrollment");

            migrationBuilder.DropTable(
                name: "AdministratorProfile");

            migrationBuilder.DropTable(
                name: "AdvisorProfile");

            migrationBuilder.DropIndex(
                name: "IX_StudentProgramEnrollment_AdvisorId",
                table: "StudentProgramEnrollment");

            migrationBuilder.DropIndex(
                name: "IX_CourseInstance_AdminProfileId",
                table: "CourseInstance");

            migrationBuilder.DropIndex(
                name: "IX_AcademicProgram_CampusBuildingId",
                table: "AcademicProgram");

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
                name: "AdvisorId",
                table: "StudentProgramEnrollment");

            migrationBuilder.DropColumn(
                name: "AdminProfileId",
                table: "CourseInstance");

            migrationBuilder.DropColumn(
                name: "CampusBuildingId",
                table: "AcademicProgram");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3076678c-a847-41ef-afde-2d8d9e5b3c3d", null, "Staff", "STAFF" },
                    { "7ee75cda-06b8-4ff9-91c2-7fb33b8314cf", null, "Rector", "RECTOR" },
                    { "7fe9b441-ebf8-49da-802c-552ea4aec608", null, "Dean", "DEAN" },
                    { "b173dd69-4f66-415b-86b0-80b96a631fad", null, "HoD", "HOD" },
                    { "b2accb25-2925-4626-bcd0-d5cdffef775e", null, "Student", "STUDENT" },
                    { "f0dfd368-972f-4bf6-aeb7-3b95dea2e34c", null, "Administrator", "ADMINISTRATOR" },
                    { "fb2762fd-7506-4515-8731-e6948a3a6d1f", null, "Lecturer", "LECTURER" },
                    { "fbc1ddd4-ae7f-4e05-9628-07de5d0a74ff", null, "Advisor", "ADVISOR" },
                    { "fc3b95af-4d6c-4153-8e54-ea849c97ba8a", null, "SuperUser", "SUPERUSER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AcademicProgram_CampusId",
                table: "AcademicProgram",
                column: "CampusId");

            migrationBuilder.AddForeignKey(
                name: "FK_AcademicProgram_CampusBuilding_CampusId",
                table: "AcademicProgram",
                column: "CampusId",
                principalTable: "CampusBuilding",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
