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

namespace PruebaTecnica.Application.Features.Productos.Command.Update
{
    public class UpdateProductoCommandHandler:IRequestHandler<UpdateProductoCommand,long>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateProductoCommandHandler> _logger;

        public UpdateProductoCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<UpdateProductoCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<long> Handle(UpdateProductoCommand request, CancellationToken cancellationToken)
        {
            var productoToUpdate = await _unitOfWork.ProductoRepository.GetByIdAsync(request.IdProducto);


            if (productoToUpdate == null)
            {
                _logger.LogError($"No se encontro la categoria {request.IdProducto}");
                throw new NotFoundException(nameof(Producto), request.IdProducto);

            }
            _mapper.Map(request, productoToUpdate, typeof(UpdateProductoCommand), typeof(Categoria));

            _unitOfWork.ProductoRepository.UpdateEntity(productoToUpdate);

            await _unitOfWork.Complete();
            _logger.LogInformation("La operacion fue Exitosa");
            return productoToUpdate.IdProducto;
        }
    }
}
