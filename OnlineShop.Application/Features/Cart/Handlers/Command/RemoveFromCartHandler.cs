using MediatR;
using OnlineShop.Application.Contracts.Persistence;
using OnlineShop.Application.Features.Cart.Requests.Command;

namespace OnlineShop.Application.Features.Cart.Handlers.Command
{
    public class RemoveFromCartHandler : IRequestHandler<RemoveFromCartRequest, Unit>
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;
        private readonly IProductRepository _productRepository;

        public RemoveFromCartHandler(IShoppingCartRepository shoppingCartRepository, IProductRepository productRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
            _productRepository = productRepository;
        }

        public async Task<Unit> Handle(RemoveFromCartRequest request, CancellationToken cancellationToken)
        {
            var cart = await _shoppingCartRepository.CheckExistShoppingCart(request.RemoveFromCartDto.UserId);

            if (cart == null)
            {
                throw new Exception("Cart not found"); // todo: not use exception
            }

            var cartItem = cart.CartItems.FirstOrDefault(i => i.Id == request.RemoveFromCartDto.ProductId);

            if (cartItem != null)
            {
                cart.CartItems.Remove(cartItem);
            }

            await _shoppingCartRepository.Update(cart);

            return Unit.Value;
        }
    }
}
