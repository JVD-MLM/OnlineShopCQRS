using FluentValidation;
using OnlineShop.Application.Contracts.Persistence;

namespace OnlineShop.Application.DTOs.User.Validator
{
    public class CreateUserDtoValidator : AbstractValidator<UserDto>
    {
        private readonly IUserRepository _userRepository;
        public CreateUserDtoValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;

            RuleFor(u => u.UserName).NotEmpty().WithMessage("نمی تواند خالی باشد").MustAsync(async (userName, token) =>
            {
                var result = await _userRepository.CheckExistUser(userName);
                return !result;
            }).WithMessage("نام کاربری موجود است");
            RuleFor(u => u.Email).EmailAddress().WithMessage("نمی تواند خالی باشد");
            RuleFor(u => u.Password).NotEmpty().WithMessage("نمی تواند خالی باشد"); // todo: password validation
        }
    }
}
