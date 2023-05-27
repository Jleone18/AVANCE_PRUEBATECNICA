using PruebaTecnica.Application.Contracts.Persistence;
using PruebaTecnica.Infrastructura.Repositories;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly PruebaTecnicaContext _context;


        private ICajaRepository _cajaRepository;
        private IClienteRepository _clienteRepository;
        private IEstablecimientoRepository _establecimientoRepository;
        private ICategoriaRepository _categoriaRepository;
        private IProductoRepository _productoRepository;
        private IFacturaRepository _facturaRepository;
        public UnitOfWork(PruebaTecnicaContext context)
        {
            _context = context;
        }

        public IFacturaRepository FacturaRepository => _facturaRepository ??= new FacturaRepository(_context);

        public IProductoRepository ProductoRepository => _productoRepository ??= new ProductoRepository(_context);

        public ICategoriaRepository CategoriaRepository => _categoriaRepository ??= new CategoriaRepository(_context);

        public IClienteRepository ClienteRepository => _clienteRepository ??= new ClienteRepository(_context);

        public ICajaRepository CajaRepository => _cajaRepository ??= new CajaRepository(_context);

        public IEstablecimientoRepository EstablecimientoRepository => _establecimientoRepository ??= new EstablecimientoRepository(_context);

        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            throw new NotImplementedException();
        }
    }
}
