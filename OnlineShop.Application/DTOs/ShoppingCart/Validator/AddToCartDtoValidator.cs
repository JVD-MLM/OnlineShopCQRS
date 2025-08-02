using FluentValidation;
using OnlineShop.Application.Contracts.Persistence;

namespace OnlineShop.Application.DTOs.ShoppingCart.Validator
{
    public class AddToCartDtoValidator : AbstractValidator<AddToCartDto>
    {
        private readonly IProductRepository _productRepository;
        private readonly IUserRepository _userRepository;

        public AddToCartDtoValidator(IProductRepository productRepository, IUserRepository userRepository)
        {
            _productRepository = productRepository;
            _userRepository = userRepository;

            RuleFor(a => a.ProductId).MustAsync(async (id, token) =>
            {
                var product = await _productRepository.CheckExistProduct(id);

                if (product == null)
                {
                    return false;
                }

                return true;
            }).WithMessage("محصول مورد نظر وجود ندارد");

            RuleFor(a => a.UserId).MustAsync(async (id, token) =>
            {
                return await _userRepository.CheckExistUser(id);
            }).WithMessage("کاربر مورد نظر وجود ندارد");
        }
    }
}
