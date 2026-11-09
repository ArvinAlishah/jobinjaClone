using jobinjaClone.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace jobinjaClone.Data.EfConfigurations;

public class ProvinceEntityConfiguration : IEntityTypeConfiguration<Province>
{
    public void Configure(EntityTypeBuilder<Province> builder)
    {
        builder.ToTable("Provinces");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name).IsRequired().HasMaxLength(20);

        builder.HasMany(x=>x.JobSeekers)
            .WithOne(x=>x.Province)
             .HasForeignKey(x=>x.ProvinceId)
                .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.Preferences)
            .WithMany(x => x.Province);


    }
}
