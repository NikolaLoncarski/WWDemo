using MediatR;

namespace WWDemo.Application.Products.Commands.DeleteProduct
{
    public class DeleteProductCommand : IRequest<Unit>
    {
        public string SerialNumber { get; set; }
    }
}