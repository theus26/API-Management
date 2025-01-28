﻿// <auto-generated />
using System;
using API_PeopleManagement.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace API_PeopleManagement.Infra.Data.Migrations
{
    [DbContext(typeof(PeopleManagementContext))]
    partial class PeopleManagementContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("API_PeopleManagement.Domain.Entities.ChangeRecord", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("ChangedBy")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("ChR_ChangedBy");

                    b.Property<string>("ChangedField")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("ChR_ChangedField");

                    b.Property<DateTime>("DateAndTimeOfChange")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("ChR_DateAndTimeOfChange");

                    b.Property<string>("NewValue")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("ChR_NewValue");

                    b.Property<string>("OldValue")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("ChR_OldValue");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("ChR_ChangeRecord", "PeopleManagement");
                });

            modelBuilder.Entity("API_PeopleManagement.Domain.Entities.EmployeePosition", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DateCreation")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("Epc_dateCreation");

                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("uuid")
                        .HasColumnName("Epc_employeeId");

                    b.Property<Guid>("PositionId")
                        .HasColumnType("uuid")
                        .HasColumnName("Epc_positionId");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("PositionId");

                    b.ToTable("Epc_EmployeePosition", "PeopleManagement");
                });

            modelBuilder.Entity("API_PeopleManagement.Domain.Entities.Employees", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("BankDetails")
                        .HasColumnType("text")
                        .HasColumnName("Emp_BankDetails");

                    b.Property<string>("CTPS")
                        .HasColumnType("text")
                        .HasColumnName("Emp_CTPS");

                    b.Property<string>("Cpf")
                        .HasColumnType("text")
                        .HasColumnName("Emp_CPF");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("Emp_DateOfBirth");

                    b.Property<string>("EmailEmployee")
                        .HasColumnType("text")
                        .HasColumnName("Emp_EmailEmployee");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean")
                        .HasColumnName("Emp_EmployeesStatus");

                    b.Property<string>("NameEmployee")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Emp_Name");

                    b.Property<string>("Observations")
                        .HasColumnType("text")
                        .HasColumnName("Emp_Observations");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text")
                        .HasColumnName("Emp_PhoneNumber");

                    b.Property<string>("PisPasep")
                        .HasColumnType("text")
                        .HasColumnName("Emp_PisPasep");

                    b.Property<string>("Rg")
                        .HasColumnType("text")
                        .HasColumnName("Emp_RG");

                    b.Property<Guid?>("UnitId")
                        .HasColumnType("uuid")
                        .HasColumnName("Emp_UnitId");

                    b.HasKey("Id");

                    b.HasIndex("UnitId");

                    b.ToTable("Emp_Employees", "PeopleManagement");
                });

            modelBuilder.Entity("API_PeopleManagement.Domain.Entities.Positions", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("ChangeDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("Pos_ChangeDate");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Pos_Position");

                    b.Property<double>("Wage")
                        .HasColumnType("double precision")
                        .HasColumnName("Pos_Wage");

                    b.HasKey("Id");

                    b.ToTable("Pos_Positions", "PeopleManagement");
                });

            modelBuilder.Entity("API_PeopleManagement.Domain.Entities.Unit", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("NameUnit")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Uni_NameUnit");

                    b.HasKey("Id");

                    b.ToTable("Uni_Unit", "PeopleManagement");
                });

            modelBuilder.Entity("API_PeopleManagement.Domain.Entities.Users", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Usu_Email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Usu_Name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Usu_Password");

                    b.Property<int>("Role")
                        .HasColumnType("integer")
                        .HasColumnName("Usu_Role");

                    b.HasKey("Id");

                    b.ToTable("Usu_User", "PeopleManagement");
                });

            modelBuilder.Entity("API_PeopleManagement.Domain.Entities.VacationRecord", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("EmployeesId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("EndIn")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("VaR_EndIn");

                    b.Property<DateTime>("StartedIn")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("VaR_StartedIn");

                    b.Property<int>("VacationStatus")
                        .HasColumnType("integer")
                        .HasColumnName("VaR_VacationStatus");

                    b.HasKey("Id");

                    b.HasIndex("EmployeesId");

                    b.ToTable("VaR_VacationRecord", "PeopleManagement");
                });

            modelBuilder.Entity("API_PeopleManagement.Domain.Entities.ChangeRecord", b =>
                {
                    b.HasOne("API_PeopleManagement.Domain.Entities.Users", "Users")
                        .WithMany("ChangeRecord")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Users");
                });

            modelBuilder.Entity("API_PeopleManagement.Domain.Entities.EmployeePosition", b =>
                {
                    b.HasOne("API_PeopleManagement.Domain.Entities.Employees", "Employees")
                        .WithMany("EmployeePosition")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API_PeopleManagement.Domain.Entities.Positions", "Positions")
                        .WithMany("EmployeePosition")
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employees");

                    b.Navigation("Positions");
                });

            modelBuilder.Entity("API_PeopleManagement.Domain.Entities.Employees", b =>
                {
                    b.HasOne("API_PeopleManagement.Domain.Entities.Unit", "Unit")
                        .WithMany()
                        .HasForeignKey("UnitId");

                    b.Navigation("Unit");
                });

            modelBuilder.Entity("API_PeopleManagement.Domain.Entities.VacationRecord", b =>
                {
                    b.HasOne("API_PeopleManagement.Domain.Entities.Employees", "Employees")
                        .WithMany("VacationRecord")
                        .HasForeignKey("EmployeesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employees");
                });

            modelBuilder.Entity("API_PeopleManagement.Domain.Entities.Employees", b =>
                {
                    b.Navigation("EmployeePosition");

                    b.Navigation("VacationRecord");
                });

            modelBuilder.Entity("API_PeopleManagement.Domain.Entities.Positions", b =>
                {
                    b.Navigation("EmployeePosition");
                });

            modelBuilder.Entity("API_PeopleManagement.Domain.Entities.Users", b =>
                {
                    b.Navigation("ChangeRecord");
                });
#pragma warning restore 612, 618
        }
    }
}
