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

namespace PruebaTecnica.Application.Features.Categorias.Command.Update
{
    public class UpdateCategoriaCommandHandler : IRequestHandler<UpdateCategoriaCommand, long>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateCategoriaCommandHandler> _logger;

        public UpdateCategoriaCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<UpdateCategoriaCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<long> Handle(UpdateCategoriaCommand request, CancellationToken cancellationToken)
        {
            var categoryToUpdate = await _unitOfWork.CategoriaRepository.GetByIdAsync(request.IdCategoria);

      
            if (categoryToUpdate == null)
            {
                _logger.LogError($"No se encontro la categoria {request.IdCategoria}");
                throw new NotFoundException(nameof(Categoria), request.IdCategoria);

            }
            _mapper.Map(request, categoryToUpdate, typeof(UpdateCategoriaCommand), typeof(Categoria));

            _unitOfWork.CategoriaRepository.UpdateEntity(categoryToUpdate);

            await _unitOfWork.Complete();
            _logger.LogInformation("La operacion fue Exitosa");
            return categoryToUpdate.IdCategoria;
        }
    }
}
