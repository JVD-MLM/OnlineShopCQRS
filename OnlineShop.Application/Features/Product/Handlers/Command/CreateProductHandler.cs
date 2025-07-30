using AutoMapper;
using MediatR;
using OnlineShop.Application.Contracts.Persistence;
using OnlineShop.Application.Features.Product.Requests.Command;

namespace OnlineShop.Application.Features.Product.Handlers.Command
{
    public class CreateProductHandler : IRequestHandler<CreateProductRequest, Unit>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public CreateProductHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateProductRequest request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Domain.Entities.Products.Product>(request.CreateProductDto);
            await _productRepository.Create(product);
            return Unit.Value;
        }
    }
}
