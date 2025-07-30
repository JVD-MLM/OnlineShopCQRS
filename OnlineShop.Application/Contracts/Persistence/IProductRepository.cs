using OnlineShop.Domain.Entities.Products;

namespace OnlineShop.Application.Contracts.Persistence
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        public Task<Product> CheckExistProduct(int id);
    }
}
