using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WWDemo.Application.DTOs;

namespace WWDemo.Application.Products.Queries.GetProductsByName
{
    public class GetProductByNameQuery : IRequest<ProductRepresentation>
    {
        public string? Name { get; set; }
    }
}
