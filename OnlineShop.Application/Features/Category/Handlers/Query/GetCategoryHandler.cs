using AutoMapper;
using MediatR;
using OnlineShop.Application.Contracts.Persistence;
using OnlineShop.Application.DTOs.Category;
using OnlineShop.Application.Features.Category.Requests.Query;

namespace OnlineShop.Application.Features.Category.Handlers.Query
{
    public class GetCategoryHandler:IRequestHandler<GetCategoryRequest,CategoryDto>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetCategoryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CategoryDto> Handle(GetCategoryRequest request, CancellationToken cancellationToken)
        {
            var result = await _categoryRepository.Get(request.Id);
            return _mapper.Map<CategoryDto>(result);
        }
    }
}
