using AutoMapper;
using MediatR;
using OnlineShop.Application.Contracts.Persistence;
using OnlineShop.Application.DTOs.Product;
using OnlineShop.Application.Features.Product.Requests.Query;

namespace OnlineShop.Application.Features.Product.Handlers.Query
{
    public class GetAllProductHandler : IRequestHandler<GetAllProductRequest, List<ProductDto>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetAllProductHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<List<ProductDto>> Handle(GetAllProductRequest request, CancellationToken cancellationToken)
        {
            var result = await _productRepository.GetAll();
            return _mapper.Map<List<ProductDto>>(result);
        }
    }
}
