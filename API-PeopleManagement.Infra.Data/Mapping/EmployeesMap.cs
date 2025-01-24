using API_PeopleManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API_PeopleManagement.Infra.Data.Mapping;

public class EmployeesMap : IEntityTypeConfiguration<Employees>
{
    public void Configure(EntityTypeBuilder<Employees> builder)
    {
        builder.HasKey(prop => prop.Id);

        builder.Property(prop => prop.NameEmployee)
            .IsRequired()
            .HasColumnName("Emp_Name");

        builder.Property(prop => prop.CTPS)
            .HasColumnName("Emp_CTPS");
        
        builder.Property(prop => prop.PisPasep)
            .HasColumnName("Emp_PisPasep");
        
        builder.Property(prop => prop.DateOfBirth)
            .HasColumnName("Emp_DateOfBirth");
        
        builder.Property(prop => prop.Rg)
            .HasColumnName("Emp_RG");
        
        builder.Property(prop => prop.Cpf)
            .HasColumnName("Emp_CPF");
        
        builder.Property(prop => prop.EmailEmployee)
            .HasColumnName("Emp_EmailEmployee");
        
        builder.Property(prop => prop.PhoneNumber)
            .HasColumnName("Emp_PhoneNumber");
        
        builder.Property(prop => prop.BankDetails)
            .HasColumnName("Emp_BankDetails");
        
        builder.Property(prop => prop.Observations)
            .HasColumnName("Emp_Observations");
        
        builder.Property(prop => prop.UnitId)
            .HasColumnName("Emp_UnitId");

        builder.Property(prop => prop.IsActive)
            .IsRequired()
            .HasColumnName("Emp_EmployeesStatus");
        
        builder.HasMany(prop => prop.VacationRecord)
            .WithOne(prop => prop.Employees)
            .HasForeignKey(prop => prop.EmployeesId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(prop => prop.Unit)
            .WithOne(prop => prop.Employees)
            .HasForeignKey<Unit>(x => x.EmployeeId)
            .OnDelete(DeleteBehavior.Cascade);


        builder.ToTable("Emp_Employees", "PeopleManagement");
    }
}
