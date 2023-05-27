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

namespace PruebaTecnica.Application.Features.Cajas.Command.Create
{
    public class CreateCajaCommandHandler:IRequestHandler<CreateCajaCommand,long>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateCajaCommandHandler> _logger;

        public CreateCajaCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<CreateCajaCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<long> Handle(CreateCajaCommand request, CancellationToken cancellationToken)
        {
            var caja = _mapper.Map<Caja>(request);

            _unitOfWork.CajaRepository.AddEntity(caja);

            var result = await _unitOfWork.Complete();
            if (result <= 0)
            {
                throw new Exception($"No se pudo ingresar el record de Category");
            }
            _logger.LogInformation($"Categoria {caja.IdCaja} fue creado exitosamente");
            return caja.IdCaja;
        }
    }
}

