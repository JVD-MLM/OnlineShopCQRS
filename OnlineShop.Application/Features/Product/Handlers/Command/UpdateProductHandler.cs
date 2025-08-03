using AutoMapper;
using MediatR;
using OnlineShop.Application.Contracts.Persistence;
using OnlineShop.Application.Features.Product.Requests.Command;

namespace OnlineShop.Application.Features.Product.Handlers.Command
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductRequest, Unit>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public UpdateProductHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateProductRequest request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.Get(request.UpdateProductDto.Id);
            var result = _mapper.Map(request.UpdateProductDto, product);
            await _productRepository.Update(result);
            return Unit.Value;
        }
    }
}
