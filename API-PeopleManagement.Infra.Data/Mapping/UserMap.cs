using API_PeopleManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API_PeopleManagement.Infra.Data.Mapping;

public class UserMap : IEntityTypeConfiguration<Users>
{
    public void Configure(EntityTypeBuilder<Users> builder)
    {
        builder.HasKey(prop => prop.Id);

        builder.Property(prop => prop.Email)
            .IsRequired()
            .HasColumnName("Usu_Email");
        
        builder.Property(prop => prop.Name)
            .IsRequired()
            .HasColumnName("Usu_Name");
        
        builder.Property(prop => prop.Password)
            .IsRequired()
            .HasColumnName("Usu_Password");
        
        builder.Property(prop => prop.Role)
            .IsRequired()
            .HasColumnName("Usu_Role");
        
        builder.HasMany(x => x.ChangeRecord)
            .WithOne(c => c.Users)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();
        
        builder.ToTable("Usu_User", "PeopleManagement");
    }
}