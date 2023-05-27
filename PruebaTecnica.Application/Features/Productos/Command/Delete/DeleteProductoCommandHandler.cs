using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using PruebaTecnica.Application.Contracts.Persistence;
using PruebaTecnica.Application.Exceptions;
using PruebaTecnica.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PruebaTecnica.Application.Features.Productos.Command.Delete
{
    public class DeleteProductoCommandHandler : IRequestHandler<DeleteProductoCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteProductoCommandHandler> _logger;

        public DeleteProductoCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<DeleteProductoCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(DeleteProductoCommand request, CancellationToken cancellationToken)
        {
            var productoToDelete = await _unitOfWork.ProductoRepository.GetByIdAsync(request.IdProducto);
            if (productoToDelete == null)
            {
                _logger.LogError($"{request.IdProducto} no existe en el sistema");
                throw new NotFoundException(nameof(Producto), request.IdProducto);
            }
            _unitOfWork.ProductoRepository.DeleteEntity(productoToDelete);
            await _unitOfWork.Complete();
            _logger.LogInformation($"{productoToDelete.Descripcion} fue eliminado correctamente");
            return Unit.Value;

        }
    }
}
