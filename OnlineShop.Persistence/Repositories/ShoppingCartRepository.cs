using OnlineShop.Application.Contracts.Persistence;
using OnlineShop.Domain.Entities.Cart;
using OnlineShop.Persistence.Context;

namespace OnlineShop.Persistence.Repositories
{
    public class ShoppingCartRepository : GenericRepository<ShoppingCart>, IShoppingCartRepository
    {
        private readonly OnlineShopCQRSDbContext _context;

        public ShoppingCartRepository(OnlineShopCQRSDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ShoppingCart> CheckExistShoppingCart(int userId)
        {
            var cart = _context.ShoppingCarts.FirstOrDefault(s => s.UserId == userId);
            return cart;
        }
    }
}
