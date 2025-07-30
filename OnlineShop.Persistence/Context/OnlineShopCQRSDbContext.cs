using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Entities.Cart;
using OnlineShop.Domain.Entities.Categories;
using OnlineShop.Domain.Entities.Products;
using OnlineShop.Domain.Entities.Users;
using OnlineShop.Persistence.EntityValidator;

namespace OnlineShop.Persistence.Context
{
    public class OnlineShopCQRSDbContext : DbContext
    {
        public OnlineShopCQRSDbContext(DbContextOptions<OnlineShopCQRSDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryValidator());
            modelBuilder.ApplyConfiguration(new ProductValidator());
            modelBuilder.ApplyConfiguration(new UserValidator());
            modelBuilder.ApplyConfiguration(new CartItemValidator());
            modelBuilder.ApplyConfiguration(new ShoppingCartValidator());

            base.OnModelCreating(modelBuilder);
        }
    }
}
