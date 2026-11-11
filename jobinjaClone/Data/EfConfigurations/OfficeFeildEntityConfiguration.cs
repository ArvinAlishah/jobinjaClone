using jobinjaClone.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace jobinjaClone.Data.EfConfigurations
{
    public class OfficeFeildEntityConfiguration : IEntityTypeConfiguration<OfficeFeild>
    {
        public void Configure(EntityTypeBuilder<OfficeFeild> builder)
        {
            builder.ToTable("OfficeFeild");
            builder.Property(x => x.Name).IsRequired();

        }
    }
}
