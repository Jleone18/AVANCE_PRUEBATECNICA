using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Application.Features.Productos.Queries.GetProductos.GetProductoByName
{
    public class GetProductoByNameQuery:IRequest<List<ProductoVm>>
    {
        public string Parametro { get; set; }

        public GetProductoByNameQuery(string parametro)
        {
            Parametro = parametro;
        }
    }
}
