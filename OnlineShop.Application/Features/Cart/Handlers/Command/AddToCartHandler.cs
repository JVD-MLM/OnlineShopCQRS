using MediatR;
using OnlineShop.Application.Contracts.Persistence;
using OnlineShop.Application.Features.Cart.Requests.Command;
using OnlineShop.Domain.Entities.Cart;

namespace OnlineShop.Application.Features.Cart.Handlers.Command
{
    public class AddToCartHandler : IRequestHandler<AddToCartRequest, Unit>
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;
        private readonly IProductRepository _productRepository;

        public AddToCartHandler(IShoppingCartRepository shoppingCartRepository, IProductRepository productRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
            _productRepository = productRepository;
        }

        public async Task<Unit> Handle(AddToCartRequest request, CancellationToken cancellationToken)
        {
            var cart = await _shoppingCartRepository.CheckExistShoppingCart(request.AddToCartDto.UserId);

            if (cart == null)
            {
                cart = new ShoppingCart()
                {
                    UserId = request.AddToCartDto.UserId,
                    CartItems = new List<CartItem>()
                };
            }

            var product = await _productRepository.CheckExistProduct(request.AddToCartDto.ProductId);

            if (product == null)
            {
                throw new Exception("Product not found"); // todo: not use exception
            }

            var cartItems = cart.CartItems.FirstOrDefault(c => c.ProductId == request.AddToCartDto.ProductId);

            if (cartItems == null)
            {
                cartItems = new CartItem()
                {
                    ProductId = request.AddToCartDto.ProductId,
                    Quantity = request.AddToCartDto.Quantity,
                    Product = product
                    // todo: check how init ShoppingCartID
                };

                cart.CartItems.Add(cartItems);
            }
            else
            {
                cartItems.Quantity += request.AddToCartDto.Quantity;
            }

            await _shoppingCartRepository.Create(cart);

            return Unit.Value;
        }
    }
}
