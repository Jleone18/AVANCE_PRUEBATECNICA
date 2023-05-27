using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Application.Features.Establecimientos.Queries.GetEstablecimientos
{
    public class GetEstablecimientosListQuery:IRequest<List<EstablecimientosVm>>
    {
    }
}
