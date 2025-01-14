using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_PeopleManagement.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class initialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "PeopleManagement");

            migrationBuilder.CreateTable(
                name: "Emp_Employees",
                schema: "PeopleManagement",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Emp_Name = table.Column<string>(type: "text", nullable: false),
                    Emp_Position = table.Column<string>(type: "text", nullable: false),
                    Emp_AdmissionDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Emp_Wage = table.Column<double>(type: "double precision", nullable: false),
                    Emp_EmployeesStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emp_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChR_ChangeRecord",
                schema: "PeopleManagement",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ChR_DateAndTimeOfChange = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ChR_ChangedField = table.Column<string>(type: "text", nullable: false),
                    ChR_OldValue = table.Column<string>(type: "text", nullable: false),
                    ChR_NewValue = table.Column<string>(type: "text", nullable: false),
                    ChR_ChangedBy = table.Column<string>(type: "text", nullable: false),
                    EmployeesId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChR_ChangeRecord", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChR_ChangeRecord_Emp_Employees_EmployeesId",
                        column: x => x.EmployeesId,
                        principalSchema: "PeopleManagement",
                        principalTable: "Emp_Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VaR_VacationRecord",
                schema: "PeopleManagement",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    VaR_VacationStartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    VaR_VacationeEndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    VaR_VacationStatus = table.Column<int>(type: "integer", nullable: false),
                    EmployeesId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VaR_VacationRecord", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VaR_VacationRecord_Emp_Employees_EmployeesId",
                        column: x => x.EmployeesId,
                        principalSchema: "PeopleManagement",
                        principalTable: "Emp_Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChR_ChangeRecord_EmployeesId",
                schema: "PeopleManagement",
                table: "ChR_ChangeRecord",
                column: "EmployeesId");

            migrationBuilder.CreateIndex(
                name: "IX_VaR_VacationRecord_EmployeesId",
                schema: "PeopleManagement",
                table: "VaR_VacationRecord",
                column: "EmployeesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChR_ChangeRecord",
                schema: "PeopleManagement");

            migrationBuilder.DropTable(
                name: "VaR_VacationRecord",
                schema: "PeopleManagement");

            migrationBuilder.DropTable(
                name: "Emp_Employees",
                schema: "PeopleManagement");
        }
    }
}
