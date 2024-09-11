using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Demo.Infrastructure.Domain.Product;

public class ProductConfiguration : IEntityTypeConfiguration<Demo.Domain.Entities.Product>
{
    public void Configure(EntityTypeBuilder<Demo.Domain.Entities.Product> builder)
    {
        builder.ToTable("Products");
        builder.Property(x => x.Id).ValueGeneratedNever();

        builder.Property<Guid>("CompanyId");
        builder.HasIndex("CompanyId");
        builder.HasOne(x => x.Company).WithMany(x => x.Products).HasForeignKey("CompanyId").IsRequired();

    }
}