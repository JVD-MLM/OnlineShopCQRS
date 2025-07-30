using OnlineShop.Domain.Entities.Categories;
using OnlineShop.Domain.Entities.Common;

namespace OnlineShop.Domain.Entities.Products
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Desc { get; set; }
        public int Price { get; set; }
        public int CategoryId { get; set; }




        public Category Category { get; set; }
    }
}
