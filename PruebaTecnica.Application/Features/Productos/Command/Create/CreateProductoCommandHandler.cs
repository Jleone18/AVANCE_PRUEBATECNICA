using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using PruebaTecnica.Application.Contracts.Persistence;
using PruebaTecnica.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PruebaTecnica.Application.Features.Productos.Command.Create
{
    public class CreateProductoCommandHandler : IRequestHandler<CreateProductoCommand, long>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateProductoCommandHandler> _logger;

        public CreateProductoCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<CreateProductoCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<long> Handle(CreateProductoCommand request, CancellationToken cancellationToken)
        {
            var producto = _mapper.Map<Producto>(request);
            //var newCategory= await _categoryRepository.AddAsync(categoryEntity);
            _unitOfWork.ProductoRepository.AddEntity(producto);
            var result = await _unitOfWork.Complete();
            if (result <= 0)
            {
                throw new Exception($"No se pudo ingresar el record de Category");
            }
            _logger.LogInformation($"Categoria {producto.IdProducto} fue creado exitosamente");
            return producto.IdProducto;
        }
    }
}
