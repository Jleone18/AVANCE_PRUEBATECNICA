using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Application.Features.Facturas.Queries
{
    public class GetFacturaByIdQuery : IRequest<FacturaCompletaVm>
    {
        public long IdFactura { get; set; }
        public GetFacturaByIdQuery(long idFactura)
        {
            IdFactura = idFactura;
        }
    }
}
