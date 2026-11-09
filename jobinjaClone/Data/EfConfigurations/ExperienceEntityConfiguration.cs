using jobinjaClone.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace jobinjaClone.Data.EfConfigurations
{
    public class ExperienceEntityConfiguration : IEntityTypeConfiguration<Experience>
    {
        public void Configure(EntityTypeBuilder<Experience> builder)
        {
            builder.ToTable("Experiences");
             
            builder.HasKey(x => x.Id);

            builder.Property(x => x.CompanyName).IsRequired().HasMaxLength(150);

            builder.Property(x => x.RollName).IsRequired().HasMaxLength(100);

            builder.Property(x => x.Description).HasMaxLength(1000);

            builder.Property(x => x.StartYear).IsRequired().HasMaxLength(4);

            builder.Property(x => x.EndYear).HasMaxLength(4);

           
        }
    }
}
