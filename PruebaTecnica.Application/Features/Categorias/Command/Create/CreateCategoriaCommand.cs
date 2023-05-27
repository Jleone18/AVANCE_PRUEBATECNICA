using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Application.Features.Categorias.Command.Create
{
    public class CreateCategoriaCommand:IRequest<long>
    {
        public string Nombre { get; set; }
    }
}
