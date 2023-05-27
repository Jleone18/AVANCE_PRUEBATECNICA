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

namespace PruebaTecnica.Application.Features.Categorias.Command.Delete
{
    public class DeleteCategoriaCommandHandler : IRequestHandler<DeleteCategoriaCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteCategoriaCommandHandler> _logger;

        public DeleteCategoriaCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<DeleteCategoriaCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(DeleteCategoriaCommand request, CancellationToken cancellationToken)
        {
            var categoriaToDelete = await _unitOfWork.CategoriaRepository.GetByIdAsync(request.IdCategoria);
            if (categoriaToDelete == null)
            {
                _logger.LogError($"{request.IdCategoria} no existe en el sistema");
                throw new NotFoundException(nameof(Categoria), request.IdCategoria);
            }
            _unitOfWork.CategoriaRepository.DeleteEntity(categoriaToDelete);
            await _unitOfWork.Complete();
            _logger.LogInformation($"{categoriaToDelete.IdCategoria} fue eliminado correctamente");
            return Unit.Value;

        }
    }
}
