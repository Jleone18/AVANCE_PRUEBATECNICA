using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Application.Features.Categorias.Command.Update
{
    public class UpdateCategoriaCommand:IRequest<long>
    {
        public long IdCategoria { get; set; }
        public string Nombre { get; set; }
    }
}
