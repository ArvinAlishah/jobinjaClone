using jobinjaClone.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace jobinjaClone.Data.EfConfigurations;

public class UserEntityConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("User");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Email).IsRequired().HasMaxLength(100);

        builder.Property(x => x.PasswordHash).IsRequired().HasMaxLength(150);

        builder.Property(x => x.username).IsRequired().HasMaxLength(20);


        builder.HasMany(x => x.UserRoles)
               .WithOne(x => x.User)
               .HasForeignKey(x => x.UserId);






    }
}
