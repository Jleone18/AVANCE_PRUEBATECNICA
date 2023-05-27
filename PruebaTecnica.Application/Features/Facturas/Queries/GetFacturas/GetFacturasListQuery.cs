using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Application.Features.Facturas.Queries.GetFacturas
{
    public class GetFacturasListQuery:IRequest<List<FacturaVm>>
    {
    }
}
