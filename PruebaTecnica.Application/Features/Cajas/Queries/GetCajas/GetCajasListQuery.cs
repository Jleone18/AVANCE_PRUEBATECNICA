using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Application.Features.Cajas.Queries.GetCajas
{
    public class GetCajasListQuery:IRequest<List<CajaVm>>
    {
    }
}
