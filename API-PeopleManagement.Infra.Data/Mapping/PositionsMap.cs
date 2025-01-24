using API_PeopleManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API_PeopleManagement.Infra.Data.Mapping;

public class PositionsMap : IEntityTypeConfiguration<Positions>
{
    public void Configure(EntityTypeBuilder<Positions> builder)
    {
        builder.HasKey(prop => prop.Id);
        
        builder.Property(prop => prop.Wage)
            .IsRequired()
            .HasColumnName("Pos_Wage");
        
        builder.Property(prop => prop.Position)
            .IsRequired()
            .HasColumnName("Pos_Position");
        
        builder.Property(prop => prop.ChangeDate)
            .IsRequired()
            .HasColumnName("Pos_ChangeDate");
        
        builder.ToTable("Pos_Positions", "PeopleManagement");
    }
}