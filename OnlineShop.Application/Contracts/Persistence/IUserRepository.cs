using OnlineShop.Domain.Entities.Users;

namespace OnlineShop.Application.Contracts.Persistence
{
    public interface IUserRepository : IGenericRepository<User>
    {
        public Task<bool> ExistUserName(string userName);
        public Task<User> GetUserWithUserName(string userName);
    }
}
