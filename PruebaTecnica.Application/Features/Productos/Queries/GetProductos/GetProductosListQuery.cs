using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Application.Features.Productos.Queries.GetProductos
{
    public class GetProductosListQuery : IRequest<List<ProductoVm>>
    {
    }
}
