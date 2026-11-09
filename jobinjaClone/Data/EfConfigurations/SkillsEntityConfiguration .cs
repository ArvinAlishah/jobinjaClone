using jobinjaClone.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace jobinjaClone.Data.EfConfigurations;

public class SkillsEntityConfiguration : IEntityTypeConfiguration<Skills>
{
    public void Configure(EntityTypeBuilder<Skills> builder)
    {
        builder.ToTable("Skills");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name).IsRequired().HasMaxLength(128);


    }
}
