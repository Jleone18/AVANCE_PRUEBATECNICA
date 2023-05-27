using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Application.Features.Clientes.Queries.GetClienteByCedulaNombre
{
    public class GetClienteQuery:IRequest<List<ClienteVm>>
    {
        public string Parametro { get; set; }

        public GetClienteQuery(string parametro)
        {
            Parametro = parametro;
        }
    }
}
