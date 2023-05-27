using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Application.Features.Cajas.Command.Create
{
    public class CreateCajaCommand:IRequest<long>
    {
        public string NumeroCaja { get; set; }
    }
}
