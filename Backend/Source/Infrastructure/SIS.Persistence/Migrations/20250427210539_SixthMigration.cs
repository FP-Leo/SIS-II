using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SIS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SixthMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DropColumn(
                name: "SchoolId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "SemesterCredits",
                table: "Departments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalCredits",
                table: "Departments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "SchoolMail",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_SchoolMail",
                table: "AspNetUsers",
                column: "SchoolMail",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_SchoolMail",
                table: "AspNetUsers");

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

            migrationBuilder.DropColumn(
                name: "SemesterCredits",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "TotalCredits",
                table: "Departments");

            migrationBuilder.AlterColumn<string>(
                name: "SchoolMail",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "SchoolId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
        }
    }
}
