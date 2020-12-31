using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PetHRM.Repositories.Migrations
{
    public partial class AddEmployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    EmployeeId = table.Column<string>(type: "varchar(255)", nullable: true),
                    FirstName = table.Column<string>(type: "longtext", nullable: true),
                    LastName = table.Column<string>(type: "longtext", nullable: true),
                    Designation = table.Column<string>(type: "longtext", nullable: true),
                    Address = table.Column<string>(type: "longtext", nullable: true),
                    CreatedBy = table.Column<string>(type: "longtext", nullable: true),
                    UpdateBy = table.Column<string>(type: "longtext", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Address", "CreatedBy", "CreatedOn", "Designation", "EmployeeId", "FirstName", "LastName", "UpdateBy", "UpdatedOn" },
                values: new object[] { "1", "Dhaka", "Admin", new DateTime(2020, 12, 31, 11, 27, 27, 832, DateTimeKind.Local).AddTicks(780), "Manger", "e001", "Darren", "Sammy", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EmployeeId",
                table: "Employees",
                column: "EmployeeId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
