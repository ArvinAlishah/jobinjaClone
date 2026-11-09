using jobinjaClone.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace jobinjaClone.Data.EfConfigurations;

public class BasicDataEntityConfiguration : IEntityTypeConfiguration<BasicData>
{
    public void Configure(EntityTypeBuilder<BasicData> builder)
    {
        builder.ToTable("BasicData");
        builder.Property(x => x.FirstName).HasMaxLength(30).IsRequired();

        builder.Property(x => x.LastName).HasMaxLength(30).IsRequired();

        builder.Property(x => x.JobTitel).HasMaxLength(30).IsRequired();

        builder.Property(x => x.WorkingStatus).IsRequired();

        builder.HasOne(x => x.JobSeeker)
            .WithOne(x => x.BasicData)
              .HasForeignKey<BasicData>(x => x.JobSeekerId);

    }
}
