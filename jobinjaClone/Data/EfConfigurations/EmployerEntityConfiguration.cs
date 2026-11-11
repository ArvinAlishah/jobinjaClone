using jobinjaClone.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace jobinjaClone.Data.EfConfigurations
{
    public class EmployerEntityConfiguration : IEntityTypeConfiguration<Employer>
    {
        public void Configure(EntityTypeBuilder<Employer> builder)
        {
            builder.ToTable("Employer");

            builder.Property(x => x.LastName).IsRequired();

            builder.Property(x => x.FirstName).IsRequired();

            builder.HasOne(x => x.Office)
                .WithOne(x => x.Employer)
                .HasForeignKey<Office>(x => x.EmployerId);

        }
    }
}
