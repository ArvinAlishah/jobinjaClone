using jobinjaClone.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace jobinjaClone.Data.EfConfigurations
{
    public class OffersEntityConfiguration : IEntityTypeConfiguration<Offers>
    {
        public void Configure(EntityTypeBuilder<Offers> builder)
        {
            builder.ToTable("Offers");
            builder.HasOne(x => x.Employer)
                .WithMany(x => x.Offers)
                .HasForeignKey(x => x.EmployId);
            builder.Property(x => x.ExpectedSalary).IsRequired();
            builder.Property(x => x.GenderImportent).IsRequired();
            builder.Property(x => x.AboutJob).IsRequired();
            builder.Property(x => x.AboutOffice).IsRequired();

            builder.Property(x => x.offerStatus).IsRequired();
            builder.Property(x => x.military).IsRequired();

            builder.Property(x => x.title).IsRequired();
            builder.Property(x => x.title).IsRequired();

            builder.Property(x => x.Gnder).IsRequired();
            builder.HasOne(x => x.JobCategories)
                .WithMany(x => x.Offers)
                .HasForeignKey(x => x.JobCategoriesId);

            builder.HasOne(x => x.Minimumwage)
                .WithMany(x => x.Offers)
                .HasForeignKey(x => x.MinmumWageId);

            builder.HasOne(x => x.PrefersContact)
                .WithMany(x => x.Offers)
                .HasForeignKey(x => x.PrefersContactId);

            builder.HasOne(x => x.Province)
                .WithMany(x => x.Offers)
                .HasForeignKey(x => x.ProvinceId);
            builder.HasOne(x => x.YearExprience)
            .WithMany(x => x.offers)
            .HasForeignKey(x => x.YearExpriceId);

        }
    }

}