﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Application.Features.Categorias.Queries.GetCategorias
{
    public class GetCategoriasListQuery : IRequest<List<CategoriaVm>>
    {

    }
}
