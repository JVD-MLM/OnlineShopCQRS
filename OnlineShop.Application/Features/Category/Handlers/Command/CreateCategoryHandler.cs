using AutoMapper;
using MediatR;
using OnlineShop.Application.Contracts.Persistence;
using OnlineShop.Application.DTOs.Category.Validator;
using OnlineShop.Application.Features.Category.Requests.Command;

namespace OnlineShop.Application.Features.Category.Handlers.Command
{
    public class CreateCategoryHandler : IRequestHandler<CreateCategoryRequest, Unit>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CreateCategoryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateCategoryRequest request, CancellationToken cancellationToken)
        {
            // todo: check validation all project

            /* var validator = new CreateCategoryDtoValidator();
            var validation = await validator.ValidateAsync(request.CreateCategoryDto);
            if (validation.IsValid)
            {

            } */

            var category = _mapper.Map<Domain.Entities.Categories.Category>(request.CreateCategoryDto);
            await _categoryRepository.Create(category);
            return Unit.Value;
        }
    }
}
