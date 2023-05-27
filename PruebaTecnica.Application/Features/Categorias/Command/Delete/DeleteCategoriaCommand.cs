using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Application.Features.Categorias.Command.Delete
{
    public class DeleteCategoriaCommand : IRequest
    {
        public long IdCategoria { get; set; }

    }
}
