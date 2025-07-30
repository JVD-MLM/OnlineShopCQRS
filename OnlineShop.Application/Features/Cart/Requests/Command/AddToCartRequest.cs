using MediatR;
using OnlineShop.Application.DTOs.ShoppingCart;

namespace OnlineShop.Application.Features.Cart.Requests.Command
{
    public class AddToCartRequest : IRequest<Unit>
    {
        public AddToCartDto AddToCartDto { get; set; }
    }
}
