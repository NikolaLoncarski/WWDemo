using AutoMapper;
using MediatR;
using WWDemo.Application.DTOs;
using WWDemo.Data.Products;

namespace WWDemo.Application.Products.Queries.GetProductBySerialNumber
{
    public class GetProductsBySerialNumberHandler : IRequestHandler<GetProductBySerialNumberQuery, ProductRepresentation>
    {
        private readonly IProductRepository productRepository;
        private readonly IMapper _mapper;
        public GetProductsBySerialNumberHandler (IProductRepository productRepository, IMapper mapper)
        {
            this.productRepository = productRepository;
            this._mapper = mapper;
        }
        public async Task<ProductRepresentation> Handle(GetProductBySerialNumberQuery request, CancellationToken cancellationToken)
        {
            var product = await productRepository.GetProductBySerialNumber(request.SerialNumber);

            var result = _mapper.Map<Models.Product,DTOs.ProductRepresentation>(product!);

            return result;
        }
    }
}
