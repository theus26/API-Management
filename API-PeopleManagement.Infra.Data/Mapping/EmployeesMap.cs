using API_PeopleManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API_PeopleManagement.Infra.Data.Mapping;

public class EmployeesMap : IEntityTypeConfiguration<Employees>
{
    public void Configure(EntityTypeBuilder<Employees> builder)
    {
        builder.HasKey(prop => prop.Id);

        builder.Property(prop => prop.Name)
            .IsRequired()
            .HasColumnName("Emp_Name");

        builder.Property(prop => prop.Position)
            .IsRequired()
            .HasColumnName("Emp_Position");

        builder.Property(prop => prop.Wage)
            .IsRequired()
            .HasColumnName("Emp_Wage");

        builder.Property(prop => prop.AdmissionDate)
            .IsRequired()
            .HasColumnName("Emp_AdmissionDate");

        builder.Property(prop => prop.IsActive)
            .IsRequired()
            .HasColumnName("Emp_EmployeesStatus");

        builder.HasMany(prop => prop.ChangeRecords)
            .WithOne(prop => prop.Employees)
            .HasForeignKey(prop => prop.EmployeesId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(prop => prop.VacationRecords)
            .WithOne(prop => prop.Employees)
            .HasForeignKey(x => x.EmployeesId)
            .OnDelete(DeleteBehavior.Cascade); ;


        builder.ToTable("Emp_Employees", "PeopleManagement");
    }
}
