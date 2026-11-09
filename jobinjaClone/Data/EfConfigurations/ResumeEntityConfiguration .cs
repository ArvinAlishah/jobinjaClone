using jobinjaClone.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace jobinjaClone.Data.EfConfigurations;

public class ResumeEntityConfiguration : IEntityTypeConfiguration<Resume>
{
    public void Configure(EntityTypeBuilder<Resume> builder)
    {
        builder.ToTable("Resumes");

        builder.Property(x => x.Url).IsRequired().HasMaxLength(100);

        builder.HasIndex(x => x.Url).IsUnique();

        builder.Property(x => x.IsPublic).HasDefaultValue(true);
    }
}