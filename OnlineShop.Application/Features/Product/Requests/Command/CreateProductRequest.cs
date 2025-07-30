using MediatR;
using OnlineShop.Application.DTOs.Product;

namespace OnlineShop.Application.Features.Product.Requests.Command
{
    public class CreateProductRequest : IRequest<Unit>
    {
        public CreateProductDto CreateProductDto { get; set; }
    }
}
