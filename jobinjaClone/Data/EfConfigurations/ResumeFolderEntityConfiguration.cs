using jobinjaClone.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace jobinjaClone.Data.EfConfigurations
{
    public class ResumeFolderEntityConfiguration : IEntityTypeConfiguration<ResumeFolder>
    {
        public void Configure(EntityTypeBuilder<ResumeFolder> builder)
        {
            builder.ToTable("ResumeFolder");
            builder.HasOne(x => x.Employer)
                .WithOne(x => x.ResumeFolder)
                .HasForeignKey<ResumeFolder>(x => x.EmployerId);


            builder.HasMany(x => x.resume);


        }
    }
}
