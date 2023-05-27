using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Application.Features.Clientes.Command.Delete
{
    public class DeleteClienteCommand : IRequest
    {
        public long IdCliente { get; set; }

    }
    
}
