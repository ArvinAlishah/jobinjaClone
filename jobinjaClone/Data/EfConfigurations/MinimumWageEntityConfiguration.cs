using jobinjaClone.Controllers;
using jobinjaClone.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace jobinjaClone.Data.EfConfigurations
{
    public class MinimumWageEntityConfiguration : IEntityTypeConfiguration<Minimumwage>
    {
        public void Configure(EntityTypeBuilder<Minimumwage> builder)
        {
            builder.ToTable("Minimumwage");
            builder.Property(x => x.minimum);
        }
    }
}
