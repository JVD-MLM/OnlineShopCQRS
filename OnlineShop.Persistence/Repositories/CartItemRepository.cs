using OnlineShop.Application.Contracts.Persistence;
using OnlineShop.Domain.Entities.Cart;
using OnlineShop.Persistence.Context;

namespace OnlineShop.Persistence.Repositories
{
    public class CartItemRepository : GenericRepository<CartItem>, ICartItemRepository
    {
        private readonly OnlineShopCQRSDbContext _context;

        public CartItemRepository(OnlineShopCQRSDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
