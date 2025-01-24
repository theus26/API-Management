using API_PeopleManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API_PeopleManagement.Infra.Data.Mapping;

public class VacationRecordMap : IEntityTypeConfiguration<VacationRecord>
{
    public void Configure(EntityTypeBuilder<VacationRecord> builder)
    {
        builder.HasKey(prop => prop.Id);

        builder.Property(prop => prop.StartedIn)
            .IsRequired()
            .HasColumnName("VaR_StartedIn");

        builder.Property(prop => prop.EndIn)
            .IsRequired()
            .HasColumnName("VaR_EndIn");

        builder.Property(prop => prop.VacationStatus)
            .IsRequired()
            .HasColumnName("VaR_VacationStatus");

        builder.HasOne(x => x.Employees)
            .WithMany(c => c.VacationRecord)
            .HasForeignKey(x => x.EmployeesId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();


        builder.ToTable("VaR_VacationRecord", "PeopleManagement");
    }
}
