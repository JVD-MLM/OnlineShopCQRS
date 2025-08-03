using MediatR;
using OnlineShop.Application.DTOs.ShoppingCart;

namespace OnlineShop.Application.Features.Cart.Requests.Command
{
    public class RemoveFromCartRequest : IRequest<Unit>
    {
        public RemoveFromCartDto RemoveFromCartDto { get; set; }
    }
}
