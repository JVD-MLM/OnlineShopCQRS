using AutoMapper;
using MediatR;
using OnlineShop.Application.Contracts.Persistence;
using OnlineShop.Application.DTOs.Product;
using OnlineShop.Application.Features.Product.Requests.Query;

namespace OnlineShop.Application.Features.Product.Handlers.Query
{
    public class GetProductHandler : IRequestHandler<GetProductRequest, ProductDto>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ProductDto> Handle(GetProductRequest request, CancellationToken cancellationToken)
        {
            var result = await _productRepository.Get(request.Id);
            return _mapper.Map<ProductDto>(result);
        }
    }
}
