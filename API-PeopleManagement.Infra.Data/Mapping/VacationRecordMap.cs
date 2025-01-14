using API_PeopleManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API_PeopleManagement.Infra.Data.Mapping;

public class VacationRecordMap : IEntityTypeConfiguration<VacationRecord>
{
    public void Configure(EntityTypeBuilder<VacationRecord> builder)
    {
        builder.HasKey(prop => prop.Id);

        builder.Property(prop => prop.VacationStartDate)
            .IsRequired()
            .HasColumnName("VaR_VacationStartDate");

        builder.Property(prop => prop.VacationeEndDate)
            .IsRequired()
            .HasColumnName("VaR_VacationeEndDate");

        builder.Property(prop => prop.VacationStatus)
            .IsRequired()
            .HasColumnName("VaR_VacationStatus");

        builder.HasOne(x => x.Employees)
            .WithMany(c => c.VacationRecords)
            .HasForeignKey(x => x.EmployeesId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();


        builder.ToTable("VaR_VacationRecord", "PeopleManagement");
    }
}
