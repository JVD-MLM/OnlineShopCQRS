using FluentValidation;

namespace OnlineShop.Application.DTOs.Category.Validator
{
    public class UpdateCategoryDtoValidator : AbstractValidator<UpdateCategoryDto>
    {
        public UpdateCategoryDtoValidator()
        {
            RuleFor(c => c.Name).NotEmpty().WithMessage("نمی تواند خالی باشد");
            RuleFor(c => c.Desc).MaximumLength(500).WithMessage("حداکثر 500 کاراکتر");
        }
    }
}
