namespace OnlineShop.Application.Contracts.Persistence
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        public Task<TEntity> Get(int id);
        public Task<List<TEntity>> GetAll();
        public Task<TEntity> Create(TEntity entity);
        public Task Update(TEntity entity);
        public Task Delete(TEntity entity);
    }
}
