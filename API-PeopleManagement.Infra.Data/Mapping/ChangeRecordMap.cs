using API_PeopleManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API_PeopleManagement.Infra.Data.Mapping;

public class ChangeRecordMap : IEntityTypeConfiguration<ChangeRecord>
{
    public void Configure(EntityTypeBuilder<ChangeRecord> builder)
    {
        builder.HasKey(prop => prop.Id);
        
        builder.Property(prop => prop.DateAndTimeOfChange)
            .IsRequired()
            .HasColumnName("ChR_DateAndTimeOfChange");

        builder.Property(prop => prop.ChangedField)
            .IsRequired()
            .HasColumnName("ChR_ChangedField");

        builder.Property(prop => prop.NewValue)
            .IsRequired()
            .HasColumnName("ChR_NewValue");

        builder.Property(prop => prop.OldValue)
            .IsRequired()
            .HasColumnName("ChR_OldValue");

        builder.Property(prop => prop.ChangedBy)
            .IsRequired()
            .HasColumnName("ChR_ChangedBy");

        builder.HasOne(x => x.Users)
            .WithMany(c => c.ChangeRecord)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();
        
        builder.HasOne(x => x.Employees)
            .WithMany(c => c.ChangeRecords)
            .HasForeignKey(x => x.EmployeesId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();


        builder.ToTable("ChR_ChangeRecord", "PeopleManagement");
    }
}
