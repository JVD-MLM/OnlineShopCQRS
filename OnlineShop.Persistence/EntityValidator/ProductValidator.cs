using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Domain.Entities.Products;

namespace OnlineShop.Persistence.EntityValidator
{
    public class ProductValidator : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Desc).HasMaxLength(400);
            builder.Property(p => p.Price).IsRequired();
            builder.HasOne(p => p.Category).WithMany().HasForeignKey(p => p.CategoryId);
        }
    }
}
