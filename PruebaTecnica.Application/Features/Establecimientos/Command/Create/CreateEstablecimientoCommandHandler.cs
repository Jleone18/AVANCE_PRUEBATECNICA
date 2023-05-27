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

namespace PruebaTecnica.Application.Features.Establecimientos.Command.Create
{
    public class CreateEstablecimientoCommandHandler : IRequestHandler<CreateEstablecimientoCommand, long>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateEstablecimientoCommandHandler> _logger;

        public CreateEstablecimientoCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<CreateEstablecimientoCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<long> Handle(CreateEstablecimientoCommand request, CancellationToken cancellationToken)
        {
            var establecimiento = _mapper.Map<Establecimiento>(request);
            //var newCategory= await _categoryRepository.AddAsync(categoryEntity);
            _unitOfWork.EstablecimientoRepository.AddEntity(establecimiento);
            var result = await _unitOfWork.Complete();
            if (result <= 0)
            {
                throw new Exception($"No se pudo ingresar el record de Category");
            }
            _logger.LogInformation($"Categoria {establecimiento.IdEstablecimiento} fue creado exitosamente");
            return establecimiento.IdEstablecimiento;
        }
    }
}
