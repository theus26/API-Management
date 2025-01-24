using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_PeopleManagement.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AlterSchemeForNewSystemByUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChR_ChangeRecord_Emp_Employees_EmployeesId",
                schema: "PeopleManagement",
                table: "ChR_ChangeRecord");

            migrationBuilder.DropColumn(
                name: "Emp_AdmissionDate",
                schema: "PeopleManagement",
                table: "Emp_Employees");

            migrationBuilder.DropColumn(
                name: "Emp_Position",
                schema: "PeopleManagement",
                table: "Emp_Employees");

            migrationBuilder.DropColumn(
                name: "Emp_Wage",
                schema: "PeopleManagement",
                table: "Emp_Employees");

            migrationBuilder.RenameColumn(
                name: "VaR_VacationeEndDate",
                schema: "PeopleManagement",
                table: "VaR_VacationRecord",
                newName: "VaR_StartedIn");

            migrationBuilder.RenameColumn(
                name: "VaR_VacationStartDate",
                schema: "PeopleManagement",
                table: "VaR_VacationRecord",
                newName: "VaR_EndIn");

            migrationBuilder.RenameColumn(
                name: "EmployeesId",
                schema: "PeopleManagement",
                table: "ChR_ChangeRecord",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ChR_ChangeRecord_EmployeesId",
                schema: "PeopleManagement",
                table: "ChR_ChangeRecord",
                newName: "IX_ChR_ChangeRecord_UserId");

            migrationBuilder.AddColumn<string>(
                name: "Emp_BankDetails",
                schema: "PeopleManagement",
                table: "Emp_Employees",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Emp_CPF",
                schema: "PeopleManagement",
                table: "Emp_Employees",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Emp_CTPS",
                schema: "PeopleManagement",
                table: "Emp_Employees",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Emp_DateOfBirth",
                schema: "PeopleManagement",
                table: "Emp_Employees",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Emp_EmailEmployee",
                schema: "PeopleManagement",
                table: "Emp_Employees",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Emp_Observations",
                schema: "PeopleManagement",
                table: "Emp_Employees",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Emp_PhoneNumber",
                schema: "PeopleManagement",
                table: "Emp_Employees",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Emp_PisPasep",
                schema: "PeopleManagement",
                table: "Emp_Employees",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Emp_RG",
                schema: "PeopleManagement",
                table: "Emp_Employees",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Emp_UnitId",
                schema: "PeopleManagement",
                table: "Emp_Employees",
                type: "uuid",
                nullable: true);

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
                    Uni_NameUnit = table.Column<string>(type: "text", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uni_Unit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Uni_Unit_Emp_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalSchema: "PeopleManagement",
                        principalTable: "Emp_Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "IX_Uni_Unit_EmployeeId",
                schema: "PeopleManagement",
                table: "Uni_Unit",
                column: "EmployeeId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ChR_ChangeRecord_Usu_User_UserId",
                schema: "PeopleManagement",
                table: "ChR_ChangeRecord",
                column: "UserId",
                principalSchema: "PeopleManagement",
                principalTable: "Usu_User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChR_ChangeRecord_Usu_User_UserId",
                schema: "PeopleManagement",
                table: "ChR_ChangeRecord");

            migrationBuilder.DropTable(
                name: "Epc_EmployeePosition",
                schema: "PeopleManagement");

            migrationBuilder.DropTable(
                name: "Uni_Unit",
                schema: "PeopleManagement");

            migrationBuilder.DropTable(
                name: "Usu_User",
                schema: "PeopleManagement");

            migrationBuilder.DropTable(
                name: "Pos_Positions",
                schema: "PeopleManagement");

            migrationBuilder.DropColumn(
                name: "Emp_BankDetails",
                schema: "PeopleManagement",
                table: "Emp_Employees");

            migrationBuilder.DropColumn(
                name: "Emp_CPF",
                schema: "PeopleManagement",
                table: "Emp_Employees");

            migrationBuilder.DropColumn(
                name: "Emp_CTPS",
                schema: "PeopleManagement",
                table: "Emp_Employees");

            migrationBuilder.DropColumn(
                name: "Emp_DateOfBirth",
                schema: "PeopleManagement",
                table: "Emp_Employees");

            migrationBuilder.DropColumn(
                name: "Emp_EmailEmployee",
                schema: "PeopleManagement",
                table: "Emp_Employees");

            migrationBuilder.DropColumn(
                name: "Emp_Observations",
                schema: "PeopleManagement",
                table: "Emp_Employees");

            migrationBuilder.DropColumn(
                name: "Emp_PhoneNumber",
                schema: "PeopleManagement",
                table: "Emp_Employees");

            migrationBuilder.DropColumn(
                name: "Emp_PisPasep",
                schema: "PeopleManagement",
                table: "Emp_Employees");

            migrationBuilder.DropColumn(
                name: "Emp_RG",
                schema: "PeopleManagement",
                table: "Emp_Employees");

            migrationBuilder.DropColumn(
                name: "Emp_UnitId",
                schema: "PeopleManagement",
                table: "Emp_Employees");

            migrationBuilder.RenameColumn(
                name: "VaR_StartedIn",
                schema: "PeopleManagement",
                table: "VaR_VacationRecord",
                newName: "VaR_VacationeEndDate");

            migrationBuilder.RenameColumn(
                name: "VaR_EndIn",
                schema: "PeopleManagement",
                table: "VaR_VacationRecord",
                newName: "VaR_VacationStartDate");

            migrationBuilder.RenameColumn(
                name: "UserId",
                schema: "PeopleManagement",
                table: "ChR_ChangeRecord",
                newName: "EmployeesId");

            migrationBuilder.RenameIndex(
                name: "IX_ChR_ChangeRecord_UserId",
                schema: "PeopleManagement",
                table: "ChR_ChangeRecord",
                newName: "IX_ChR_ChangeRecord_EmployeesId");

            migrationBuilder.AddColumn<DateTime>(
                name: "Emp_AdmissionDate",
                schema: "PeopleManagement",
                table: "Emp_Employees",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Emp_Position",
                schema: "PeopleManagement",
                table: "Emp_Employees",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Emp_Wage",
                schema: "PeopleManagement",
                table: "Emp_Employees",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddForeignKey(
                name: "FK_ChR_ChangeRecord_Emp_Employees_EmployeesId",
                schema: "PeopleManagement",
                table: "ChR_ChangeRecord",
                column: "EmployeesId",
                principalSchema: "PeopleManagement",
                principalTable: "Emp_Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
