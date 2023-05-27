using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Application.Features.Cajas.Command.Update
{
    public class UpdateCajaCommand:IRequest<long>
    {
        public long IdCaja { get; set; }
        public string NumeroCaja { get; set; }
    }
}
