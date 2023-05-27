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

namespace PruebaTecnica.Application.Features.Clientes.Command.Create
{
    public class CreateClienteCommandHandler : IRequestHandler<CreateClienteCommand, long>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateClienteCommandHandler> _logger;

        public CreateClienteCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<CreateClienteCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<long> Handle(CreateClienteCommand request, CancellationToken cancellationToken)
        {
            var cliente = _mapper.Map<Cliente>(request);
            //var newCategory= await _categoryRepository.AddAsync(categoryEntity);
            _unitOfWork.ClienteRepository.AddEntity(cliente);
            var result = await _unitOfWork.Complete();
            if (result <= 0)
            {
                throw new Exception($"No se pudo ingresar el record de Category");
            }
            _logger.LogInformation($"Categoria {cliente.IdCliente} fue creado exitosamente");
            return cliente.IdCliente;
        }
    }
}
