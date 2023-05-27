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

namespace PruebaTecnica.Application.Features.Facturas.Commands.Create
{
    public class CreateFacturaCommandHandler : IRequestHandler<CreateFacturaCommand, long>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateFacturaCommandHandler> _logger;

        public CreateFacturaCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<CreateFacturaCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<long> Handle(CreateFacturaCommand request, CancellationToken cancellationToken)
        {
          
            Factura factura = new Factura();
            _mapper.Map(request, factura, typeof(CreateFacturaCommand), typeof(Factura));
            _unitOfWork.FacturaRepository.AddEntity(factura);
            var result = await _unitOfWork.Complete();
            if (result <= 0)
            {
                throw new Exception($"No se pudo ingresar el record de Factura");
            }
            _logger.LogInformation($"Categoria {factura.IdFactura} fue creado exitosamente");
            return factura.IdFactura;
        }
    }
}
