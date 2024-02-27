using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WWDemo.Application.DTOs;
using WWDemo.Application.Products.Queries.GetProductBySerialNumber;
using WWDemo.Data.Products;
using WWDemo.Models;

namespace WWDemo.Application.Products.Queries.GetProductsByName
{
    public class GetProductByNameHandler : IRequestHandler<GetProductByNameQuery, ProductRepresentation>
    {
        private readonly IProductRepository productRepository;
        private readonly IMapper _mapper;


        public GetProductByNameHandler(IProductRepository productRepository, IMapper mapper)
        {
            this.productRepository = productRepository;
            this._mapper = mapper;
        }



        public async Task<ProductRepresentation> Handle(GetProductByNameQuery request, CancellationToken cancellationToken)
        {
            var products = await productRepository.GetProductByName(request.Name);
            var result = _mapper.Map <Models.Product, DTOs.ProductRepresentation>(products!);

            return result;
        }
    }
}

