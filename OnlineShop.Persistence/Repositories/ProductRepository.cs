using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Contracts.Persistence;
using OnlineShop.Domain.Entities.Products;
using OnlineShop.Persistence.Context;

namespace OnlineShop.Persistence.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly OnlineShopCQRSDbContext _context;

        public ProductRepository(OnlineShopCQRSDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Product> CheckExistProduct(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
