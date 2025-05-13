using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SIS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UniqueConstraintsUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExamPeriod_AcademicProgram_AcademicProgramId",
                table: "ExamPeriod");

            migrationBuilder.DropForeignKey(
                name: "FK_ExamPeriod_ProgramSemester_ProgramSemesterId",
                table: "ExamPeriod");

            migrationBuilder.DropForeignKey(
                name: "FK_LecturerProfile_AspNetUsers_LecturerId",
                table: "LecturerProfile");

            migrationBuilder.DropForeignKey(
                name: "FK_RegistrationPeriod_AcademicProgram_AcademicProgramId",
                table: "RegistrationPeriod");

            migrationBuilder.DropForeignKey(
                name: "FK_RegistrationPeriod_AcademicSemester_AcademicSemesterId",
                table: "RegistrationPeriod");

            migrationBuilder.DropTable(
                name: "AcademicProgramPrerequisite");

            migrationBuilder.DropTable(
                name: "CoursePrerequisite");

            migrationBuilder.DropIndex(
                name: "IX_StudentCourseEnrollment_ProgramEnrollmentId",
                table: "StudentCourseEnrollment");

            migrationBuilder.DropIndex(
                name: "IX_RegistrationPeriod_AcademicSemesterId_AcademicProgramId",
                table: "RegistrationPeriod");

            migrationBuilder.DropIndex(
                name: "IX_ExamPeriod_ProgramSemesterId",
                table: "ExamPeriod");

            migrationBuilder.DropIndex(
                name: "IX_Assessment_CourseInstanceId",
                table: "Assessment");

            migrationBuilder.DropIndex(
                name: "IX_AcademicYear_Name",
                table: "AcademicYear");

            migrationBuilder.DropIndex(
                name: "IX_AcademicCalendar_AcademicYearId",
                table: "AcademicCalendar");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "352af689-533d-4fa1-b3e5-ada36f596061");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "55d2f49f-8e73-4fae-b6d9-d3e4796eafc6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "59b7941a-52d4-4a8a-94b4-a070cb14b0e6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "76b01644-9ce0-431c-ba8e-4295ae142df9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7b0e1460-1385-46ba-9415-ec4c9b10fea8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "83d7941b-edd4-40b3-8db2-51fa5a596bc8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8ff72d1d-4a83-4f4f-ab8d-b2c5a073f6de");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "972061cc-f9d7-4a89-9b51-6840c872999e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ae81c36c-d0c9-4ae2-8239-fb31b5873998");

            migrationBuilder.RenameColumn(
                name: "AcademicSemesterId",
                table: "RegistrationPeriod",
                newName: "SemesterId");

            migrationBuilder.RenameColumn(
                name: "AcademicProgramId",
                table: "RegistrationPeriod",
                newName: "ProgramId");

            migrationBuilder.RenameIndex(
                name: "IX_RegistrationPeriod_AcademicProgramId",
                table: "RegistrationPeriod",
                newName: "IX_RegistrationPeriod_ProgramId");

            migrationBuilder.RenameColumn(
                name: "ProgramSemesterId",
                table: "ExamPeriod",
                newName: "SemesterId");

            migrationBuilder.RenameColumn(
                name: "AcademicProgramId",
                table: "ExamPeriod",
                newName: "ProgramId");

            migrationBuilder.RenameIndex(
                name: "IX_ExamPeriod_AcademicProgramId",
                table: "ExamPeriod",
                newName: "IX_ExamPeriod_ProgramId");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "LecturerProfile",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Holidays",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "CourseSchedule",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "Course",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Course",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Assessment",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AcademicSemester",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AcademicProgram",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "AcademicProgramId",
                table: "AcademicProgram",
                type: "int",
                nullable: true);

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
                name: "IX_StudentCourseEnrollment_ProgramEnrollmentId_CourseInstanceId",
                table: "StudentCourseEnrollment",
                columns: new[] { "ProgramEnrollmentId", "CourseInstanceId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RegistrationPeriod_SemesterId_ProgramId",
                table: "RegistrationPeriod",
                columns: new[] { "SemesterId", "ProgramId" },
                unique: true,
                filter: "[ProgramId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_LecturerProfile_UserId",
                table: "LecturerProfile",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Holidays_Name_AcademicCalendarId",
                table: "Holidays",
                columns: new[] { "Name", "AcademicCalendarId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExamPeriod_SemesterId_ProgramId",
                table: "ExamPeriod",
                columns: new[] { "SemesterId", "ProgramId" },
                unique: true,
                filter: "[ProgramId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSchedule_DayOfWeek_StartTime_Location",
                table: "CourseSchedule",
                columns: new[] { "DayOfWeek", "StartTime", "Location" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Course_CourseId",
                table: "Course",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Assessment_CourseInstanceId_Name",
                table: "Assessment",
                columns: new[] { "CourseInstanceId", "Name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AcademicYear_Name_UniversityId",
                table: "AcademicYear",
                columns: new[] { "Name", "UniversityId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AcademicSemester_Name_AcademicCalendarId",
                table: "AcademicSemester",
                columns: new[] { "Name", "AcademicCalendarId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AcademicProgram_AcademicProgramId",
                table: "AcademicProgram",
                column: "AcademicProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_AcademicProgram_Name_DepartmentId",
                table: "AcademicProgram",
                columns: new[] { "Name", "DepartmentId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AcademicCalendar_AcademicYearId",
                table: "AcademicCalendar",
                column: "AcademicYearId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AcademicProgram_AcademicProgram_AcademicProgramId",
                table: "AcademicProgram",
                column: "AcademicProgramId",
                principalTable: "AcademicProgram",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Course_CourseId",
                table: "Course",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExamPeriod_AcademicProgram_ProgramId",
                table: "ExamPeriod",
                column: "ProgramId",
                principalTable: "AcademicProgram",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExamPeriod_AcademicSemester_SemesterId",
                table: "ExamPeriod",
                column: "SemesterId",
                principalTable: "AcademicSemester",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LecturerProfile_AspNetUsers_UserId",
                table: "LecturerProfile",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RegistrationPeriod_AcademicProgram_ProgramId",
                table: "RegistrationPeriod",
                column: "ProgramId",
                principalTable: "AcademicProgram",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RegistrationPeriod_AcademicSemester_SemesterId",
                table: "RegistrationPeriod",
                column: "SemesterId",
                principalTable: "AcademicSemester",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AcademicProgram_AcademicProgram_AcademicProgramId",
                table: "AcademicProgram");

            migrationBuilder.DropForeignKey(
                name: "FK_Course_Course_CourseId",
                table: "Course");

            migrationBuilder.DropForeignKey(
                name: "FK_ExamPeriod_AcademicProgram_ProgramId",
                table: "ExamPeriod");

            migrationBuilder.DropForeignKey(
                name: "FK_ExamPeriod_AcademicSemester_SemesterId",
                table: "ExamPeriod");

            migrationBuilder.DropForeignKey(
                name: "FK_LecturerProfile_AspNetUsers_UserId",
                table: "LecturerProfile");

            migrationBuilder.DropForeignKey(
                name: "FK_RegistrationPeriod_AcademicProgram_ProgramId",
                table: "RegistrationPeriod");

            migrationBuilder.DropForeignKey(
                name: "FK_RegistrationPeriod_AcademicSemester_SemesterId",
                table: "RegistrationPeriod");

            migrationBuilder.DropIndex(
                name: "IX_StudentCourseEnrollment_ProgramEnrollmentId_CourseInstanceId",
                table: "StudentCourseEnrollment");

            migrationBuilder.DropIndex(
                name: "IX_RegistrationPeriod_SemesterId_ProgramId",
                table: "RegistrationPeriod");

            migrationBuilder.DropIndex(
                name: "IX_LecturerProfile_UserId",
                table: "LecturerProfile");

            migrationBuilder.DropIndex(
                name: "IX_Holidays_Name_AcademicCalendarId",
                table: "Holidays");

            migrationBuilder.DropIndex(
                name: "IX_ExamPeriod_SemesterId_ProgramId",
                table: "ExamPeriod");

            migrationBuilder.DropIndex(
                name: "IX_CourseSchedule_DayOfWeek_StartTime_Location",
                table: "CourseSchedule");

            migrationBuilder.DropIndex(
                name: "IX_Course_CourseId",
                table: "Course");

            migrationBuilder.DropIndex(
                name: "IX_Assessment_CourseInstanceId_Name",
                table: "Assessment");

            migrationBuilder.DropIndex(
                name: "IX_AcademicYear_Name_UniversityId",
                table: "AcademicYear");

            migrationBuilder.DropIndex(
                name: "IX_AcademicSemester_Name_AcademicCalendarId",
                table: "AcademicSemester");

            migrationBuilder.DropIndex(
                name: "IX_AcademicProgram_AcademicProgramId",
                table: "AcademicProgram");

            migrationBuilder.DropIndex(
                name: "IX_AcademicProgram_Name_DepartmentId",
                table: "AcademicProgram");

            migrationBuilder.DropIndex(
                name: "IX_AcademicCalendar_AcademicYearId",
                table: "AcademicCalendar");

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

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "LecturerProfile");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "AcademicProgramId",
                table: "AcademicProgram");

            migrationBuilder.RenameColumn(
                name: "SemesterId",
                table: "RegistrationPeriod",
                newName: "AcademicSemesterId");

            migrationBuilder.RenameColumn(
                name: "ProgramId",
                table: "RegistrationPeriod",
                newName: "AcademicProgramId");

            migrationBuilder.RenameIndex(
                name: "IX_RegistrationPeriod_ProgramId",
                table: "RegistrationPeriod",
                newName: "IX_RegistrationPeriod_AcademicProgramId");

            migrationBuilder.RenameColumn(
                name: "SemesterId",
                table: "ExamPeriod",
                newName: "ProgramSemesterId");

            migrationBuilder.RenameColumn(
                name: "ProgramId",
                table: "ExamPeriod",
                newName: "AcademicProgramId");

            migrationBuilder.RenameIndex(
                name: "IX_ExamPeriod_ProgramId",
                table: "ExamPeriod",
                newName: "IX_ExamPeriod_AcademicProgramId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Holidays",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "CourseSchedule",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Assessment",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AcademicSemester",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AcademicProgram",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateTable(
                name: "AcademicProgramPrerequisite",
                columns: table => new
                {
                    PrerequisiteId = table.Column<int>(type: "int", nullable: false),
                    ProgramId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicProgramPrerequisite", x => new { x.PrerequisiteId, x.ProgramId });
                    table.ForeignKey(
                        name: "FK_AcademicProgramPrerequisite_AcademicProgram_PrerequisiteId",
                        column: x => x.PrerequisiteId,
                        principalTable: "AcademicProgram",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AcademicProgramPrerequisite_AcademicProgram_ProgramId",
                        column: x => x.ProgramId,
                        principalTable: "AcademicProgram",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CoursePrerequisite",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    PrerequisiteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoursePrerequisite", x => new { x.CourseId, x.PrerequisiteId });
                    table.ForeignKey(
                        name: "FK_CoursePrerequisite_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CoursePrerequisite_Course_PrerequisiteId",
                        column: x => x.PrerequisiteId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "352af689-533d-4fa1-b3e5-ada36f596061", null, "Staff", "STAFF" },
                    { "55d2f49f-8e73-4fae-b6d9-d3e4796eafc6", null, "Lecturer", "LECTURER" },
                    { "59b7941a-52d4-4a8a-94b4-a070cb14b0e6", null, "SuperUser", "SUPERUSER" },
                    { "76b01644-9ce0-431c-ba8e-4295ae142df9", null, "Dean", "DEAN" },
                    { "7b0e1460-1385-46ba-9415-ec4c9b10fea8", null, "Rector", "RECTOR" },
                    { "83d7941b-edd4-40b3-8db2-51fa5a596bc8", null, "Administrator", "ADMINISTRATOR" },
                    { "8ff72d1d-4a83-4f4f-ab8d-b2c5a073f6de", null, "HoD", "HOD" },
                    { "972061cc-f9d7-4a89-9b51-6840c872999e", null, "Student", "STUDENT" },
                    { "ae81c36c-d0c9-4ae2-8239-fb31b5873998", null, "Advisor", "ADVISOR" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourseEnrollment_ProgramEnrollmentId",
                table: "StudentCourseEnrollment",
                column: "ProgramEnrollmentId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistrationPeriod_AcademicSemesterId_AcademicProgramId",
                table: "RegistrationPeriod",
                columns: new[] { "AcademicSemesterId", "AcademicProgramId" },
                unique: true,
                filter: "[AcademicProgramId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ExamPeriod_ProgramSemesterId",
                table: "ExamPeriod",
                column: "ProgramSemesterId");

            migrationBuilder.CreateIndex(
                name: "IX_Assessment_CourseInstanceId",
                table: "Assessment",
                column: "CourseInstanceId");

            migrationBuilder.CreateIndex(
                name: "IX_AcademicYear_Name",
                table: "AcademicYear",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AcademicCalendar_AcademicYearId",
                table: "AcademicCalendar",
                column: "AcademicYearId");

            migrationBuilder.CreateIndex(
                name: "IX_AcademicProgramPrerequisite_ProgramId",
                table: "AcademicProgramPrerequisite",
                column: "ProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_CoursePrerequisite_PrerequisiteId",
                table: "CoursePrerequisite",
                column: "PrerequisiteId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExamPeriod_AcademicProgram_AcademicProgramId",
                table: "ExamPeriod",
                column: "AcademicProgramId",
                principalTable: "AcademicProgram",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExamPeriod_ProgramSemester_ProgramSemesterId",
                table: "ExamPeriod",
                column: "ProgramSemesterId",
                principalTable: "ProgramSemester",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LecturerProfile_AspNetUsers_LecturerId",
                table: "LecturerProfile",
                column: "LecturerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RegistrationPeriod_AcademicProgram_AcademicProgramId",
                table: "RegistrationPeriod",
                column: "AcademicProgramId",
                principalTable: "AcademicProgram",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RegistrationPeriod_AcademicSemester_AcademicSemesterId",
                table: "RegistrationPeriod",
                column: "AcademicSemesterId",
                principalTable: "AcademicSemester",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
