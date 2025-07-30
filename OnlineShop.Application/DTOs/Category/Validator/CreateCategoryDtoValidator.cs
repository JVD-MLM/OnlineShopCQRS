using FluentValidation;

namespace OnlineShop.Application.DTOs.Category.Validator
{
    public class CreateCategoryDtoValidator : AbstractValidator<CreateCategoryDto>
    {
        public CreateCategoryDtoValidator()
        {
            RuleFor(c => c.Name).NotEmpty().WithMessage("نمی تواند خالی باشد");
            RuleFor(c => c.Desc).MaximumLength(500).WithMessage("حداکثر 500 کاراکتر");
        }
    }
}
