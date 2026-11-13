using jobinjaClone.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace jobinjaClone.Data.EfConfigurations
{
    public class JobApplicationEntityConfiguration : IEntityTypeConfiguration<JobApplication>
    {
        public void Configure(EntityTypeBuilder<JobApplication> builder)
        {
            builder.ToTable("JobApplication");
            builder.HasMany(x => x.Resume);
            builder.HasOne(x => x.ResumeFolder)
                .WithMany(x => x.JobApplication)
                .HasForeignKey(x => x.ResumeFolderId);
                

        }
    }
}
