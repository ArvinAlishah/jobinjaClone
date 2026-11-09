using jobinjaClone.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace jobinjaClone.Data.EfConfigurations
{
    public class RoleEntityConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Role");

             builder.HasKey(x => x.Id);

            builder.Property(x => x.DisplayName).IsRequired().HasMaxLength(20);

            builder.Property(x => x.Name).IsRequired().HasMaxLength(20);

            builder.HasMany(x => x.UserRoles)
                    .WithOne(x => x.Role)
                       .HasForeignKey(x => x.RoleId);




        }
    }
}
