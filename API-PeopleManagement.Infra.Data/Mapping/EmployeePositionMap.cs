using API_PeopleManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API_PeopleManagement.Infra.Data.Mapping;

public class EmployeePositionMap : IEntityTypeConfiguration<EmployeePosition>
{
    public void Configure(EntityTypeBuilder<EmployeePosition> builder)
    {
        builder.HasKey(prop => prop.Id);
        
        builder.Property(prop => prop.EmployeeId)
            .IsRequired()
            .HasColumnName("Epc_employeeId");
        
        builder.Property(prop => prop.PositionId)
            .IsRequired()
            .HasColumnName("Epc_positionId");
        
        builder.Property(prop => prop.DateCreation)
            .IsRequired()
            .HasColumnName("Epc_dateCreation");
        
        builder.HasOne(x => x.Employees)
            .WithMany(x => x.EmployeePosition)
            .HasForeignKey(x => x.EmployeeId);

        builder.HasOne(x => x.Positions)
            .WithMany(x => x.EmployeePosition)
            .HasForeignKey(x => x.PositionId);
        
        builder.ToTable("Epc_EmployeePosition", "PeopleManagement");
    }
}