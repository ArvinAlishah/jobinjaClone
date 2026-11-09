using jobinjaClone.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace jobinjaClone.Data.EfConfigurations
{
    public class ProfileImageEntityConfiguration : IEntityTypeConfiguration<ProfileImage>
    {
        public void Configure(EntityTypeBuilder<ProfileImage> builder)
        {
            builder.ToTable("ProfileImage");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Url).IsRequired();
        }
    }
}