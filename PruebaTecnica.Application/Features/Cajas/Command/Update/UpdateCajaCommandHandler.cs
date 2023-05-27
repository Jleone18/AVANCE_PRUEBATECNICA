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

namespace PruebaTecnica.Application.Features.Cajas.Command.Update
{
    public class UpdateCajaCommandHandler : IRequestHandler<UpdateCajaCommand, long>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateCajaCommandHandler> _logger;

        public UpdateCajaCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<UpdateCajaCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<long> Handle(UpdateCajaCommand request, CancellationToken cancellationToken)
        {
            var cajaToUpdate = await _unitOfWork.CajaRepository.GetByIdAsync(request.IdCaja);


            if (cajaToUpdate == null)
            {
                _logger.LogError($"No se encontro la categoria {request.IdCaja}");
                throw new NotFoundException(nameof(Caja), request.IdCaja);

            }
            _mapper.Map(request, cajaToUpdate, typeof(UpdateCajaCommand), typeof(Categoria));

            _unitOfWork.CajaRepository.UpdateEntity(cajaToUpdate);

            await _unitOfWork.Complete();
            _logger.LogInformation("La operacion fue Exitosa");
            return cajaToUpdate.IdCaja;
        }
    }
}
