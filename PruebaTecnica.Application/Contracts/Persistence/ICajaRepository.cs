using PruebaTecnica.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Application.Contracts.Persistence
{
    public interface ICajaRepository:IAsyncRepository<Caja>
    {
    }
}
