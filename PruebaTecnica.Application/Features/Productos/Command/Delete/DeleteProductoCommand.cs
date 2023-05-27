using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Application.Features.Productos.Command.Delete
{
    public class DeleteProductoCommand : IRequest
    {
        public long IdProducto { get; set; }
    }
}
