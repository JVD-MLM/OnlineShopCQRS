using MediatR;
using OnlineShop.Application.DTOs.Product;

namespace OnlineShop.Application.Features.Product.Requests.Query
{
    public class GetAllProductRequest : IRequest<List<ProductDto>>
    {
    }
}
