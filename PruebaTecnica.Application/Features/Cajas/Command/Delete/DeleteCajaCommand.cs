using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Application.Features.Cajas.Command.Delete
{
    public class DeleteCajaCommand : IRequest
    {
        public long IdCaja { get; set; }
    }
}
