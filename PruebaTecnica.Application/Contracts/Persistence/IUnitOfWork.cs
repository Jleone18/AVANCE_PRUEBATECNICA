using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Application.Contracts.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : class;
        IFacturaRepository FacturaRepository { get; }
        IProductoRepository ProductoRepository { get; }
        ICategoriaRepository CategoriaRepository { get; }
        IClienteRepository ClienteRepository { get; }
        ICajaRepository CajaRepository { get; }
        IEstablecimientoRepository EstablecimientoRepository { get; }
        Task<int> Complete();
    }
}
