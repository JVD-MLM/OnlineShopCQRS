using MediatR;

namespace OnlineShop.Application.Features.Product.Requests.Command
{
    public class DeleteProductRequest : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
