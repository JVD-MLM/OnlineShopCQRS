using AutoMapper;
using MediatR;
using OnlineShop.Application.Contracts.Persistence;
using OnlineShop.Application.Features.Category.Requests.Command;

namespace OnlineShop.Application.Features.Category.Handlers.Command
{
    public class UpdateCategoryHandler : IRequestHandler<UpdateCategoryRequest, Unit>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public UpdateCategoryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateCategoryRequest request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.Get(request.UpdateCategoryDto.Id);
            category = _mapper.Map(request.UpdateCategoryDto, category);
            await _categoryRepository.Update(category);
            return Unit.Value;
        }
    }
}
