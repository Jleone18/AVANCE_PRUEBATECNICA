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

namespace PruebaTecnica.Application.Features.Clientes.Command.Update
{
    public class UpdateClienteCommandHandler : IRequestHandler<UpdateClienteCommand, long>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateClienteCommandHandler> _logger;

        public UpdateClienteCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<UpdateClienteCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<long> Handle(UpdateClienteCommand request, CancellationToken cancellationToken)
        {
            var clienteToUpdate = await _unitOfWork.ClienteRepository.GetByIdAsync(request.IdCliente);


            if (clienteToUpdate == null)
            {
                _logger.LogError($"No se encontro la categoria {request.IdCliente}");
                throw new NotFoundException(nameof(Cliente), request.IdCliente);

            }
            _mapper.Map(request, clienteToUpdate, typeof(UpdateClienteCommand), typeof(Categoria));

            _unitOfWork.ClienteRepository.UpdateEntity(clienteToUpdate);

            await _unitOfWork.Complete();
            _logger.LogInformation("La operacion fue Exitosa");
            return clienteToUpdate.IdCliente;
        }
    }
}
