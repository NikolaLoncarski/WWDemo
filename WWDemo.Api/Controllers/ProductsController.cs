using MediatR;
using Microsoft.AspNetCore.Mvc;
using WWDemo.Api.Requests;
using WWDemo.Application.DTOs;
using WWDemo.Application.Products.Commands.AddProduct;
using WWDemo.Application.Products.Commands.DeleteProduct;
using WWDemo.Application.Products.Queries.GetAllProducts;
using WWDemo.Application.Products.Queries.GetProductBySerialNumber;
using WWDemo.Application.Products.Queries.GetProductsByName;

namespace WWDemo.Api.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		private readonly IMediator _mediator;

		public ProductsController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpPost]
		[ProducesResponseType(200)]
		[ProducesResponseType(400)]
		public async Task<IActionResult> AddProduct(AddProductRequest request)
		{
			await _mediator.Send(new AddProductCommand
			{
				Name = request.Name,
				Price = request.Price,
				SerialNumber = request.SerialNumber,
				Category = request.Category,
			});

			return Ok();
		}

		[HttpGet]
		[ProducesResponseType(typeof(List<ProductRepresentation>), StatusCodes.Status200OK)]
		public async Task<List<ProductRepresentation>> GetAllProducts()
		{
			var result = await _mediator.Send(new GetAllProductsQuery());

			return result;
		}

		[HttpGet("{serial-number}")]
		public async Task<IActionResult> GetProductBySerialNumber([FromRoute(Name = "serial-number")]string serialNumber)
		{
            var result = await _mediator.Send(new GetProductBySerialNumberQuery { SerialNumber = serialNumber});
            
			return Ok(result);
		}

        [HttpDelete("{serial-number}")]
        public async Task<IActionResult> DeleteProduct([FromRoute(Name = "serial-number")] string serialNumber)
        {

                await _mediator.Send(new DeleteProductCommand { SerialNumber = serialNumber });
                return Ok();

        }
    
		[HttpDelete]
		public async Task<IActionResult> DeleteProduct()
		{
			return Ok();
		}

        [HttpGet]
		[Route("api/GetProductByName")]
		
        public async Task<IActionResult> GetProductByName( string name)
        {
            var result = await _mediator.Send(new GetProductByNameQuery { Name = name });

            return Ok(result);
        }
    }
}
