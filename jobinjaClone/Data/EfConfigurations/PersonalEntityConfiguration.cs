using jobinjaClone.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace jobinjaClone.Data.EfConfigurations
{
    public class PersonalEntityConfiguration : IEntityTypeConfiguration<Personal>
    {
        public void Configure(EntityTypeBuilder<Personal> builder)
        {
            builder.ToTable("Personal");
            builder.Property(x => x.BirthDay).HasMaxLength(20);


            builder.Property(x => x.Mobile).HasMaxLength(20);

            builder.Property(x => x.Gender);

            builder.Property(x => x.MarriageStatus);

            builder.Property(x => x.MiliteryStatus);

            builder.HasOne(x => x.Province)
                .WithMany(x => x.Personal)
                  .HasForeignKey(x => x.ProvinceId)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
