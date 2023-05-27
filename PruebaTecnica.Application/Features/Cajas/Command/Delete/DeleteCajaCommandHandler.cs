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

namespace PruebaTecnica.Application.Features.Cajas.Command.Delete
{
    public class DeleteCajaCommandHandler:IRequestHandler<DeleteCajaCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteCajaCommandHandler> _logger;

        public DeleteCajaCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<DeleteCajaCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(DeleteCajaCommand request, CancellationToken cancellationToken)
        {
            var cajaToDelete = await _unitOfWork.CajaRepository.GetByIdAsync(request.IdCaja);
            if (cajaToDelete == null)
            {
                _logger.LogError($"{request.IdCaja} no existe en el sistema");
                throw new NotFoundException(nameof(Caja), request.IdCaja);
            }
            _unitOfWork.CajaRepository.DeleteEntity(cajaToDelete);
            await _unitOfWork.Complete();
            _logger.LogInformation($"{cajaToDelete.IdCaja} fue eliminado correctamente");
            return Unit.Value;
        }
    }
}
