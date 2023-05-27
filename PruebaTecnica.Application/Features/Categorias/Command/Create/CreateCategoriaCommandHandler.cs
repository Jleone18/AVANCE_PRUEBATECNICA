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

namespace PruebaTecnica.Application.Features.Categorias.Command.Create
{
    public class CreateCategoriaCommandHandler : IRequestHandler<CreateCategoriaCommand, long>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateCategoriaCommandHandler> _logger;

        public CreateCategoriaCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<CreateCategoriaCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<long> Handle(CreateCategoriaCommand request, CancellationToken cancellationToken)
        {
            var categoria = _mapper.Map<Categoria>(request);
            
            _unitOfWork.CategoriaRepository.AddEntity(categoria);
            var result = await _unitOfWork.Complete();
            if (result <= 0)
            {
                throw new Exception($"No se pudo ingresar el record de Categoria");
            }
            _logger.LogInformation($"Categoria {categoria.IdCategoria} fue creado exitosamente");
            return categoria.IdCategoria;
        }
    }
}
