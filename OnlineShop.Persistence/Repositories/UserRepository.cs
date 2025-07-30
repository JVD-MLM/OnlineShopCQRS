using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Contracts.Persistence;
using OnlineShop.Domain.Entities.Users;
using OnlineShop.Persistence.Context;

namespace OnlineShop.Persistence.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly OnlineShopCQRSDbContext _context;

        public UserRepository(OnlineShopCQRSDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> ExistUserName(string userName)
        {
            return await _context.Users.AnyAsync(u => u.UserName == userName);
        }

        public async Task<User> GetUserWithUserName(string userName)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.UserName == userName);
        }
    }
}
