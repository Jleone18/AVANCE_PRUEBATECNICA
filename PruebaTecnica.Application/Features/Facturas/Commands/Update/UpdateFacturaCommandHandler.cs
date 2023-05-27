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

namespace PruebaTecnica.Application.Features.Facturas.Commands.Update
{
    public class UpdateFacturaCommandHandler:IRequestHandler<UpdateFacturaCommand, long>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateFacturaCommandHandler> _logger;

        public UpdateFacturaCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<UpdateFacturaCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<long> Handle(UpdateFacturaCommand request, CancellationToken cancellationToken)
        {
            var facturaToUpdate = await _unitOfWork.FacturaRepository.GetByIdAsync(request.IdFactura);


            if (facturaToUpdate == null)
            {
                _logger.LogError($"No se encontro la categoria {request.IdFactura}");
                throw new NotFoundException(nameof(Factura), request.IdCliente);

            }
            _mapper.Map(request, facturaToUpdate, typeof(UpdateFacturaCommand), typeof(Factura));

            _unitOfWork.FacturaRepository.UpdateEntity(facturaToUpdate);

            await _unitOfWork.Complete();
            _logger.LogInformation("La operacion fue Exitosa");
            return facturaToUpdate.IdFactura;
        }
    }
}
