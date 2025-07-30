using AutoMapper;
using MediatR;
using OnlineShop.Application.Contracts.Persistence;
using OnlineShop.Application.Features.Product.Requests.Command;

namespace OnlineShop.Application.Features.Product.Handlers.Command
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductRequest, Unit>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public DeleteProductHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteProductRequest request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.Get(request.Id);
            await _productRepository.Delete(product);
            return Unit.Value;
        }
    }
}
