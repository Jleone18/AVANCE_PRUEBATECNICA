using AutoMapper;
using MediatR;
using PruebaTecnica.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PruebaTecnica.Application.Features.Categorias.Queries.GetCategorias
{
    public class GetCategoriasListQueryHandler : IRequestHandler<GetCategoriasListQuery, List<CategoriaVm>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetCategoriasListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<CategoriaVm>> Handle(GetCategoriasListQuery request, CancellationToken cancellationToken)
        {
            var categorias = await _unitOfWork.CategoriaRepository.GetAllAsync();
            return _mapper.Map<List<CategoriaVm>>(categorias);
        }
    }
}
