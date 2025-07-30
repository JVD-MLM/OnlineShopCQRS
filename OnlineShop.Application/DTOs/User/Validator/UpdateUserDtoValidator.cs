using FluentValidation;
using OnlineShop.Application.Contracts.Persistence;
using OnlineShop.Application.DTOs.Product;

namespace OnlineShop.Application.DTOs.User.Validator
{
    public class UpdateUserDtoValidator : AbstractValidator<UpdateUserDto>
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserDtoValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;

            RuleFor(u => u.UserName).NotEmpty().WithMessage("نمی تواند خالی باشد").MustAsync(async (userName, token) =>
            {
                var result = await _userRepository.ExistUserName(userName);
                return !result;
            }).WithMessage("نام کاربری موجود است");
            RuleFor(u => u.Email).EmailAddress().WithMessage("نمی تواند خالی باشد");
            RuleFor(u => u.Password).NotEmpty().WithMessage("نمی تواند خالی باشد"); // todo: password validation
        }
    }
}
