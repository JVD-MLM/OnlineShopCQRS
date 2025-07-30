using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Domain.Entities.Cart;

namespace OnlineShop.Persistence.EntityValidator
{
    public class ShoppingCartValidator : IEntityTypeConfiguration<ShoppingCart>
    {
        public void Configure(EntityTypeBuilder<ShoppingCart> builder)
        {
            builder.HasKey(s => s.Id);
            builder.HasMany(s => s.CartItems).WithOne(c => c.ShoppingCart).HasForeignKey(c => c.ShoppingCartId);
        }
    }
}
