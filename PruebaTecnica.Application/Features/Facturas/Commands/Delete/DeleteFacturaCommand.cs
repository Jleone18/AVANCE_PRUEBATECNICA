using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Application.Features.Facturas.Commands.Delete
{
    public class DeleteFacturaCommand:IRequest
    {
        public long IdFactura { get; set; }
    }
}
