using jobinjaClone.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace jobinjaClone.Data.EfConfigurations
{
    public class EmployerNumberEntityConfiguration : IEntityTypeConfiguration<EmploeyNumber>
    {
        public void Configure(EntityTypeBuilder<EmploeyNumber> builder)
        {
            builder.ToTable("EmploeyNumber");
            builder.Property(x => x.Number).IsRequired();
        }
    }
}