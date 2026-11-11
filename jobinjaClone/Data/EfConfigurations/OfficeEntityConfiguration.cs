using jobinjaClone.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace jobinjaClone.Data.EfConfigurations
{
    public class OfficeEntityConfiguration : IEntityTypeConfiguration<Office>
    {
        public void Configure(EntityTypeBuilder<Office> builder)
        {
            builder.ToTable("Office");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.HaveLogo).IsRequired();
            builder.Property(x => x.LogoUrl).IsRequired();
            builder.Property(x => x.OfficeNameEnglish).IsRequired();
            builder.Property(x => x.SiteUrl).IsRequired();
            builder.Property(x => x.OfficeNameFarsi).IsRequired();
            builder.Property(x => x.AboutOffice).IsRequired();


            builder.HasMany(x => x.OfficeFeild)
                .WithMany(x => x.office);

            builder.HasOne(x => x.EmploeyNumber)
                .WithMany(x => x.office)
                .HasForeignKey(x => x.EmployNumberId);

            builder.HasOne(x => x.Province)
            .WithMany(x => x.office)
            .HasForeignKey(x => x.ProvinceId);
        }
    }
}
