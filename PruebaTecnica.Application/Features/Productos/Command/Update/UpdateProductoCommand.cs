using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Application.Features.Productos.Command.Update
{
    public class UpdateProductoCommand: IRequest<long>
    {
        public long IdProducto { get; set; }
        public long IdCategoria { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
    }
}
