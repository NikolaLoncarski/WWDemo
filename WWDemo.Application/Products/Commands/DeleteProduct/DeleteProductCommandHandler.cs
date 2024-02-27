using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WWDemo.Data.Products; 

namespace WWDemo.Application.Products.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Unit>
    {
        private readonly IProductRepository _productRepository;

        public DeleteProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            await _productRepository.DeleteProductBySerialNumber(request.SerialNumber);
            return Unit.Value;
        }
    }
}
