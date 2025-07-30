using OnlineShop.Domain.Entities.Common;

namespace OnlineShop.Domain.Entities.Categories
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public string Desc { get; set; }
    }
}
