using jobinjaClone.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace jobinjaClone.Data.EfConfigurations;

public class EducationEntityConfiguration : IEntityTypeConfiguration<Education>
{
    public void Configure(EntityTypeBuilder<Education> builder)
    {
        builder.ToTable("Education");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.FieldName).IsRequired().HasMaxLength(100);

        builder.Property(x => x.InstituteName).IsRequired().HasMaxLength(150);

        builder.Property(x => x.StartYear).IsRequired().HasMaxLength(20);

        builder.Property(x => x.EndYear).HasMaxLength(4);

        builder.Property(x => x.Description).HasMaxLength(1000);


    }
}
