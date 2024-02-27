using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Employee_management_system.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MobileNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeDepartments",
                columns: table => new
                {
                    EmployeeNo = table.Column<int>(type: "int", nullable: false),
                    DepartmentNo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeDepartments", x => new { x.EmployeeNo, x.DepartmentNo });
                    table.ForeignKey(
                        name: "FK_EmployeeDepartments_Departments_DepartmentNo",
                        column: x => x.DepartmentNo,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeDepartments_Employees_EmployeeNo",
                        column: x => x.EmployeeNo,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentId", "DepartmentName" },
                values: new object[,]
                {
                    { 1, "Sales" },
                    { 2, "Marketing" },
                    { 3, "IT" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "Address", "Birthday", "CreationDate", "Department", "Email", "FirstName", "LastName", "MobileNumber" },
                values: new object[,]
                {
                    { 1, "123 Colombo Srilanka", new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 26, 12, 29, 32, 828, DateTimeKind.Local).AddTicks(3575), "Sales", "alice@gmail.com", "Alice", "Smith", "0711234567" },
                    { 2, "456 Colombo Srilanka", new DateTime(1991, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 26, 12, 29, 32, 828, DateTimeKind.Local).AddTicks(3596), "Marketing", "kamal@gmail.com", "Kamal", "Jones", "0771234567" },
                    { 3, "789 Colombo Srilanka", new DateTime(1992, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 26, 12, 29, 32, 828, DateTimeKind.Local).AddTicks(3602), "IT", "amal@gmail.com", "Amal", "Perera", "0751237896" }
                });

            migrationBuilder.InsertData(
                table: "EmployeeDepartments",
                columns: new[] { "DepartmentNo", "EmployeeNo" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDepartments_DepartmentNo",
                table: "EmployeeDepartments",
                column: "DepartmentNo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeDepartments");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
