using MediatR;
using OnlineShop.Application.DTOs.Product;

namespace OnlineShop.Application.Features.Product.Requests.Query
{
    public class GetProductRequest : IRequest<ProductDto>
    {
        public int Id { get; set; }
    }
}
