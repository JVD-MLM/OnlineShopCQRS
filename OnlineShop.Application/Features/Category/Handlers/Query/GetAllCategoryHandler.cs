using AutoMapper;
using MediatR;
using OnlineShop.Application.Contracts.Persistence;
using OnlineShop.Application.DTOs.Category;
using OnlineShop.Application.Features.Category.Requests.Query;

namespace OnlineShop.Application.Features.Category.Handlers.Query
{
    public class GetAllCategoryHandler : IRequestHandler<GetAllCategoryRequest, List<CategoryDto>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetAllCategoryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<List<CategoryDto>> Handle(GetAllCategoryRequest request, CancellationToken cancellationToken)
        {
            var result = await _categoryRepository.GetAll();
            return _mapper.Map<List<CategoryDto>>(result);
        }
    }
}
