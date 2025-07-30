using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Domain.Entities.Cart;

namespace OnlineShop.Persistence.EntityValidator
{
    public class CartItemValidator : IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> builder)
        {
            builder.HasKey(c => c.Id);
            builder.HasOne(c => c.ShoppingCart).WithMany(s => s.CartItems).HasForeignKey(c => c.ShoppingCartId);
            builder.HasOne(c => c.Product).WithMany().HasForeignKey(c => c.ProductId);
        }
    }
}
