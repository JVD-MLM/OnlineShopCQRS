using OnlineShop.Domain.Entities.Users;

namespace OnlineShop.Application.Contracts.Persistence
{
    public interface IUserRepository : IGenericRepository<User>
    {
        public Task<bool> CheckExistUser(string userName);
        public Task<bool> CheckExistUser(int id);
        public Task<User> GetUserWithUserName(string userName);
    }
}
