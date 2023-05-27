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

namespace PruebaTecnica.Application.Features.Clientes.Command.Delete
{
    public class DeleteClienteCommandHandler : IRequestHandler<DeleteClienteCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteClienteCommandHandler> _logger;

        public DeleteClienteCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<DeleteClienteCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(DeleteClienteCommand request, CancellationToken cancellationToken)
        {
            var clienteToDelete = await _unitOfWork.ClienteRepository.GetByIdAsync(request.IdCliente);
            if (clienteToDelete == null)
            {
                _logger.LogError($"{request.IdCliente} no existe en el sistema");
                throw new NotFoundException(nameof(Cliente), request.IdCliente);
            }
            _unitOfWork.ClienteRepository.DeleteEntity(clienteToDelete);
            await _unitOfWork.Complete();
            _logger.LogInformation($"{clienteToDelete.IdCliente} fue eliminado correctamente");
            return Unit.Value;

        }
    }
}
