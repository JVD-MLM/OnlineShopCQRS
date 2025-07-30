using OnlineShop.Domain.Entities.Common;
using OnlineShop.Domain.Entities.Products;

namespace OnlineShop.Domain.Entities.Cart
{
    public class CartItem:BaseEntity
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int ShoppingCartId { get; set; }




        public Product Product { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
    }
}
