using OnlineShop.Domain.Entities.Common;

namespace OnlineShop.Domain.Entities.Cart
{
    public class ShoppingCart : BaseEntity
    {
        public int UserId { get; set; }

        public int TotalPrice
        {
            get // todo: write no mapping method
            {
                return CartItems.Sum(i => i.Product.Price * i.Quantity);
            }
        }




        public List<CartItem> CartItems { get; set; }
    }
}
