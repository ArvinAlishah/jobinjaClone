using jobinjaClone.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace jobinjaClone.Data.EfConfigurations;

public class PreferenceEntityConfiguration : IEntityTypeConfiguration<Preference>
{
    public void Configure(EntityTypeBuilder<Preference> builder)
    {
        builder.ToTable("Preferences");

        builder.Property(x => x.ExpectedSalary).HasMaxLength(50);

        builder.HasMany(x => x.PrefersContact)
            .WithMany(x => x.Preferences);

        builder.HasMany(x => x.SeniorityLevel)
            .WithMany(x => x.Preferences);

        builder.HasMany(x => x.JobCategories)
            .WithMany(x => x.Preferences);

        builder.HasMany(x => x.Province)
            .WithMany(x => x.Preferences);

        builder.HasMany(x => x.Benefits)
            .WithMany(x => x.Preferences);
    }
}