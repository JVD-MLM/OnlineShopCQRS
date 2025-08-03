using OnlineShop.Application.DTOs.Common;

namespace OnlineShop.Application.DTOs.Product
{
    public class ProductDto : BaseDto
    {
        public string Name { get; set; }
        public string Desc { get; set; }
        public int Price { get; set; }
        public int CategoryId { get; set; }
    }
}
