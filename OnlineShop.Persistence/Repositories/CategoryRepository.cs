using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Contracts.Persistence;
using OnlineShop.Domain.Entities.Categories;
using OnlineShop.Persistence.Context;

namespace OnlineShop.Persistence.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private readonly OnlineShopCQRSDbContext _context;

        public CategoryRepository(OnlineShopCQRSDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> CheckExistCategory(int id)
        {
            return await _context.Categories.AnyAsync(c => c.Id == id);
        }
    }
}
