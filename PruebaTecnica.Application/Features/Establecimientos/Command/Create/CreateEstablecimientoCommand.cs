using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Application.Features.Establecimientos.Command.Create
{
    public class CreateEstablecimientoCommand:IRequest<long>
    {
        public string Nombre { get; set; }
        public string Codigo { get; set; }
    }
}
