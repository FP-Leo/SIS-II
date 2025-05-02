using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SIS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ThirdMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "18ea4d2a-9b8c-4a1c-92d8-9c236ae2c551");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4142d94c-ebd2-4e36-98d8-e500a2b76666");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44e801dc-68ee-4b59-a544-e23777936676");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "66473753-0828-4a86-9882-cb168f794929");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b59d403e-6e39-42ae-8b87-c72caa2c0244");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bf53770f-4572-43df-bd03-e781335365e5");

            migrationBuilder.CreateTable(
                name: "Universities",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Abbreviation = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Domain = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RectorID = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Universities", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Universities_AspNetUsers_RectorID",
                        column: x => x.RectorID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Faculties",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    UniID = table.Column<int>(type: "int", nullable: false),
                    DeanID = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculties", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Faculties_AspNetUsers_DeanID",
                        column: x => x.DeanID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Faculties_Universities_UniID",
                        column: x => x.UniID,
                        principalTable: "Universities",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NumberOfSemesters = table.Column<int>(type: "int", nullable: false),
                    MaxYears = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    FacultyID = table.Column<int>(type: "int", nullable: false),
                    HeadOfDepartmentID = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Departments_AspNetUsers_HeadOfDepartmentID",
                        column: x => x.HeadOfDepartmentID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Departments_Faculties_FacultyID",
                        column: x => x.FacultyID,
                        principalTable: "Faculties",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3e3ac85f-c2ef-4357-89e6-b412ca17a08b", null, "Student", "STUDENT" },
                    { "64113cfa-5227-4881-9542-78bef916f9e9", null, "Lecturer", "LECTURER" },
                    { "9eac022a-fbde-4ca0-be99-7281f9ec316e", null, "Staff", "STAFF" },
                    { "d907d606-a6d6-493f-a18d-cc714e913984", null, "Administrator", "ADMINISTRATOR" },
                    { "eb2953ed-e92e-4999-9428-feda236d0d1a", null, "Admin", "ADMIN" },
                    { "fcfb2edf-918e-452a-9ba7-0043a63e6633", null, "Advisor", "ADVISOR" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Departments_Code",
                table: "Departments",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Departments_FacultyID",
                table: "Departments",
                column: "FacultyID");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_HeadOfDepartmentID",
                table: "Departments",
                column: "HeadOfDepartmentID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Departments_Name_FacultyID",
                table: "Departments",
                columns: new[] { "Name", "FacultyID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Faculties_Code",
                table: "Faculties",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Faculties_DeanID",
                table: "Faculties",
                column: "DeanID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Faculties_PhoneNumber",
                table: "Faculties",
                column: "PhoneNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Faculties_UniID_Name",
                table: "Faculties",
                columns: new[] { "UniID", "Name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Universities_Abbreviation",
                table: "Universities",
                column: "Abbreviation",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Universities_Name",
                table: "Universities",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Universities_RectorID",
                table: "Universities",
                column: "RectorID",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Faculties");

            migrationBuilder.DropTable(
                name: "Universities");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3e3ac85f-c2ef-4357-89e6-b412ca17a08b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "64113cfa-5227-4881-9542-78bef916f9e9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9eac022a-fbde-4ca0-be99-7281f9ec316e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d907d606-a6d6-493f-a18d-cc714e913984");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eb2953ed-e92e-4999-9428-feda236d0d1a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fcfb2edf-918e-452a-9ba7-0043a63e6633");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "18ea4d2a-9b8c-4a1c-92d8-9c236ae2c551", null, "Lecturer", "LECTURER" },
                    { "4142d94c-ebd2-4e36-98d8-e500a2b76666", null, "Staff", "STAFF" },
                    { "44e801dc-68ee-4b59-a544-e23777936676", null, "Student", "STUDENT" },
                    { "66473753-0828-4a86-9882-cb168f794929", null, "Administrator", "ADMINISTRATOR" },
                    { "b59d403e-6e39-42ae-8b87-c72caa2c0244", null, "Admin", "ADMIN" },
                    { "bf53770f-4572-43df-bd03-e781335365e5", null, "Advisor", "ADVISOR" }
                });
        }
    }
}
