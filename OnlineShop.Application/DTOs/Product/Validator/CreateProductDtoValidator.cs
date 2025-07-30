using FluentValidation;
using OnlineShop.Application.Contracts.Persistence;

namespace OnlineShop.Application.DTOs.Product.Validator
{
    public class CreateProductDtoValidator : AbstractValidator<CreateProductDto>
    {
        private readonly ICategoryRepository _categoryRepository;

        public CreateProductDtoValidator(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;

            RuleFor(p => p.Name).NotEmpty().WithMessage("نمی تواند خالی باشد");
            RuleFor(p => p.Desc).MaximumLength(500).WithMessage("حداکثر 500 کاراکتر");
            RuleFor(p => p.Price).GreaterThan(0).WithMessage("قیمت نمی تواند 0 باشد");
            RuleFor(p => p.CategoryId).MustAsync(async (id, token) =>
            {
                return await _categoryRepository.CheckExistCategory(id);
            }).WithMessage("دسته بندی مورد نظر وجود ندارد");
        }
    }
}
