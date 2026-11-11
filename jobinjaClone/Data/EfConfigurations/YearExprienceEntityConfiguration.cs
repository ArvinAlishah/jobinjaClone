using jobinjaClone.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace jobinjaClone.Data.EfConfigurations
{
    public class YearExprienceEntityConfiguration : IEntityTypeConfiguration<YearExprience>
    {
        public void Configure(EntityTypeBuilder<YearExprience> builder)
        {
            builder.ToTable("YearExprience");
            builder.HasKey(e => e.Id);
            builder.Property(x => x.Year).IsRequired();
           

        }
    }
}
