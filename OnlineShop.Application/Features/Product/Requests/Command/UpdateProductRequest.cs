using MediatR;
using OnlineShop.Application.DTOs.Product;

namespace OnlineShop.Application.Features.Product.Requests.Command
{
    public class UpdateProductRequest : IRequest<Unit>
    {
        public UpdateProductDto UpdateProductDto { get; set; }
    }
}
