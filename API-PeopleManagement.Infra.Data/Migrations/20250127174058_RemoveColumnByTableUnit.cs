using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_PeopleManagement.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemoveColumnByTableUnit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Uni_Unit_Emp_Employees_EmployeeId",
                schema: "PeopleManagement",
                table: "Uni_Unit");

            migrationBuilder.DropIndex(
                name: "IX_Uni_Unit_EmployeeId",
                schema: "PeopleManagement",
                table: "Uni_Unit");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                schema: "PeopleManagement",
                table: "Uni_Unit");

            migrationBuilder.CreateIndex(
                name: "IX_Emp_Employees_Emp_UnitId",
                schema: "PeopleManagement",
                table: "Emp_Employees",
                column: "Emp_UnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Emp_Employees_Uni_Unit_Emp_UnitId",
                schema: "PeopleManagement",
                table: "Emp_Employees",
                column: "Emp_UnitId",
                principalSchema: "PeopleManagement",
                principalTable: "Uni_Unit",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Emp_Employees_Uni_Unit_Emp_UnitId",
                schema: "PeopleManagement",
                table: "Emp_Employees");

            migrationBuilder.DropIndex(
                name: "IX_Emp_Employees_Emp_UnitId",
                schema: "PeopleManagement",
                table: "Emp_Employees");

            migrationBuilder.AddColumn<Guid>(
                name: "EmployeeId",
                schema: "PeopleManagement",
                table: "Uni_Unit",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Uni_Unit_EmployeeId",
                schema: "PeopleManagement",
                table: "Uni_Unit",
                column: "EmployeeId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Uni_Unit_Emp_Employees_EmployeeId",
                schema: "PeopleManagement",
                table: "Uni_Unit",
                column: "EmployeeId",
                principalSchema: "PeopleManagement",
                principalTable: "Emp_Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
