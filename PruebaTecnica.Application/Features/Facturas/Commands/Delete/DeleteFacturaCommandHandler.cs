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

namespace PruebaTecnica.Application.Features.Facturas.Commands.Delete
{
    public class DeleteFacturaCommandHandler:IRequestHandler<DeleteFacturaCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteFacturaCommandHandler> _logger;

        public DeleteFacturaCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<DeleteFacturaCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        

        public async Task<Unit> Handle(DeleteFacturaCommand request, CancellationToken cancellationToken)
        {
            var facturaToDelete = await _unitOfWork.FacturaRepository.GetByIdAsync(request.IdFactura);
            if (facturaToDelete == null)
            {
                _logger.LogError($"{request.IdFactura} no existe en el sistema");
                throw new NotFoundException(nameof(Factura), request.IdFactura);
            }
            _unitOfWork.FacturaRepository.DeleteEntity(facturaToDelete);
            await _unitOfWork.Complete();
            _logger.LogInformation($"{facturaToDelete.IdFactura} fue eliminado correctamente");
            return Unit.Value;
        }
    }
}
