using AutoMapper;
using MediatR;
using OnlineShop.Application.Contracts.Persistence;
using OnlineShop.Application.Features.Category.Requests.Command;

namespace OnlineShop.Application.Features.Category.Handlers.Command
{
    public class DeleteCategoryHandler : IRequestHandler<DeleteCategoryRequest, Unit>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public DeleteCategoryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteCategoryRequest request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.Get(request.Id);
            await _categoryRepository.Delete(category);
            return Unit.Value;
        }
    }
}
