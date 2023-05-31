using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Application.Features.Productos.Command.Create
{
    public class CreateProductoCommand: IRequest<long>
    {
       
        public long IdCategoria { get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public double? Precio { get; set; }
    }
}
