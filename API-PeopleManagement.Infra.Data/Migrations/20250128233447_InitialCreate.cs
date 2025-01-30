using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_PeopleManagement.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "PeopleManagement");

            migrationBuilder.CreateTable(
                name: "Pos_Positions",
                schema: "PeopleManagement",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Pos_Position = table.Column<string>(type: "text", nullable: false),
                    Pos_Wage = table.Column<double>(type: "double precision", nullable: false),
                    Pos_ChangeDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pos_Positions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Uni_Unit",
                schema: "PeopleManagement",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Uni_NameUnit = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uni_Unit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usu_User",
                schema: "PeopleManagement",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Usu_Name = table.Column<string>(type: "text", nullable: false),
                    Usu_Email = table.Column<string>(type: "text", nullable: false),
                    Usu_Password = table.Column<string>(type: "text", nullable: false),
                    Usu_Role = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usu_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Emp_Employees",
                schema: "PeopleManagement",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Emp_Name = table.Column<string>(type: "text", nullable: false),
                    Emp_CTPS = table.Column<string>(type: "text", nullable: true),
                    Emp_PisPasep = table.Column<string>(type: "text", nullable: true),
                    Emp_DateOfBirth = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Emp_RG = table.Column<string>(type: "text", nullable: true),
                    Emp_CPF = table.Column<string>(type: "text", nullable: true),
                    Emp_EmailEmployee = table.Column<string>(type: "text", nullable: true),
                    Emp_PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    Emp_Observations = table.Column<string>(type: "text", nullable: true),
                    Emp_BankDetails = table.Column<string>(type: "text", nullable: true),
                    Emp_EmployeesStatus = table.Column<bool>(type: "boolean", nullable: false),
                    Emp_UnitId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emp_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Emp_Employees_Uni_Unit_Emp_UnitId",
                        column: x => x.Emp_UnitId,
                        principalSchema: "PeopleManagement",
                        principalTable: "Uni_Unit",
                        principalColumn: "Id");
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
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
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
                    table.ForeignKey(
                        name: "FK_ChR_ChangeRecord_Usu_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "PeopleManagement",
                        principalTable: "Usu_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Epc_EmployeePosition",
                schema: "PeopleManagement",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Epc_employeeId = table.Column<Guid>(type: "uuid", nullable: false),
                    Epc_positionId = table.Column<Guid>(type: "uuid", nullable: false),
                    Epc_dateCreation = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Epc_EmployeePosition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Epc_EmployeePosition_Emp_Employees_Epc_employeeId",
                        column: x => x.Epc_employeeId,
                        principalSchema: "PeopleManagement",
                        principalTable: "Emp_Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Epc_EmployeePosition_Pos_Positions_Epc_positionId",
                        column: x => x.Epc_positionId,
                        principalSchema: "PeopleManagement",
                        principalTable: "Pos_Positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VaR_VacationRecord",
                schema: "PeopleManagement",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    VaR_StartedIn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    VaR_EndIn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
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
                name: "IX_ChR_ChangeRecord_UserId",
                schema: "PeopleManagement",
                table: "ChR_ChangeRecord",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Emp_Employees_Emp_UnitId",
                schema: "PeopleManagement",
                table: "Emp_Employees",
                column: "Emp_UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Epc_EmployeePosition_Epc_employeeId",
                schema: "PeopleManagement",
                table: "Epc_EmployeePosition",
                column: "Epc_employeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Epc_EmployeePosition_Epc_positionId",
                schema: "PeopleManagement",
                table: "Epc_EmployeePosition",
                column: "Epc_positionId");

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
                name: "Epc_EmployeePosition",
                schema: "PeopleManagement");

            migrationBuilder.DropTable(
                name: "VaR_VacationRecord",
                schema: "PeopleManagement");

            migrationBuilder.DropTable(
                name: "Usu_User",
                schema: "PeopleManagement");

            migrationBuilder.DropTable(
                name: "Pos_Positions",
                schema: "PeopleManagement");

            migrationBuilder.DropTable(
                name: "Emp_Employees",
                schema: "PeopleManagement");

            migrationBuilder.DropTable(
                name: "Uni_Unit",
                schema: "PeopleManagement");
        }
    }
}
