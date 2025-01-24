using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API_PeopleManagement.Infra.Data.Mapping;

public class UnitMap : IEntityTypeConfiguration<Domain.Entities.Unit>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Unit> builder)
    {
        builder.HasKey(prop => prop.Id);
        
        builder.Property(prop => prop.NameUnit)
            .IsRequired()
            .HasColumnName("Uni_NameUnit");
        
        builder.ToTable("Uni_Unit", "PeopleManagement");
    }
}