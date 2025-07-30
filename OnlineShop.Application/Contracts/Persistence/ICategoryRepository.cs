using OnlineShop.Domain.Entities.Categories;

namespace OnlineShop.Application.Contracts.Persistence
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        public Task<bool> CheckExistCategory(int id);
    }
}
