using jobinjaClone.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace jobinjaClone.Data.EfConfigurations;

public class JobSeekerEntityConfiguration : IEntityTypeConfiguration<JobSeeker>
{
    public void Configure(EntityTypeBuilder<JobSeeker> builder)
    {
        builder.ToTable("JobSeekers");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.FirstName).HasMaxLength(30).IsRequired();

        builder.Property(x => x.LastName).HasMaxLength(30).IsRequired();


        builder.Property(x => x.About).HasMaxLength(255);


        builder.Property(x => x.BirthDay).HasMaxLength(20);


        builder.Property(x => x.Mobile).HasMaxLength(20);

        builder.Property(x => x.Gender);

        builder.Property(x => x.MarriageStatus);

        builder.Property(x => x.MiliteryStatus);

        builder.HasOne(x => x.Province)
            .WithMany(x => x.JobSeekers)
              .HasForeignKey(x => x.ProvinceId)
                .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.Skills)
            .WithMany(x => x.JobSeekers);

        builder.HasMany(x => x.Languages)
           .WithOne(x => x.JobSeeker)
            .HasForeignKey(x=>x.JobSeekerId)
              .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.Education)
           .WithOne(x => x.JobSeeker)
            .HasForeignKey(x => x.JobSeekerId)
              .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.Experiences)
           .WithOne(x => x.JobSeeker)
            .HasForeignKey(x => x.JobSeekerId)
              .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Preference)
           .WithOne(x => x.JobSeeker)
            .HasForeignKey<Preference>(x => x.JobSeekerId)
              .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Resume)
            .WithOne(x => x.JobSeeker)
             .HasForeignKey<Resume>(x=>x.JobSeekerId);

        builder.HasOne(x => x.User)
             .WithOne()
                  .HasForeignKey<JobSeeker>(x => x.UserId)
                     .OnDelete(DeleteBehavior.Restrict);


    }
}
