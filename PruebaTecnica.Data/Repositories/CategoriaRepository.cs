using PruebaTecnica.Application.Contracts.Persistence;
using PruebaTecnica.Domain.Models;
using PruebaTecnica.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Infrastructura.Repositories
{
    public class CategoriaRepository : RepositoryBase<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(PruebaTecnicaContext context) : base(context)
        {

        }
    }
}
