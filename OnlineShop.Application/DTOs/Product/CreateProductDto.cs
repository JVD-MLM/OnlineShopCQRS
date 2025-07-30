namespace OnlineShop.Application.DTOs.Product
{
    public class CreateProductDto
    {
        public string Name { get; set; }
        public string Desc { get; set; }
        public int Price { get; set; }
        public int CategoryId { get; set; }
    }
}
