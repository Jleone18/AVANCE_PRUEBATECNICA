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
    public class EstablecimientoRepository : RepositoryBase<Establecimiento>, IEstablecimientoRepository
    {
        public EstablecimientoRepository(PruebaTecnicaContext context) : base(context)
        {

        }
    }
}
