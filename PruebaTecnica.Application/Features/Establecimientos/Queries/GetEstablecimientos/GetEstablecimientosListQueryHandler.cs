using AutoMapper;
using MediatR;
using PruebaTecnica.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PruebaTecnica.Application.Features.Establecimientos.Queries.GetEstablecimientos
{
    public class GetEstablecimientosListQueryHandler : IRequestHandler<GetEstablecimientosListQuery, List<EstablecimientosVm>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetEstablecimientosListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<EstablecimientosVm>> Handle(GetEstablecimientosListQuery request, CancellationToken cancellationToken)
        {
            var categorias = await _unitOfWork.EstablecimientoRepository.GetAllAsync();
            return _mapper.Map<List<EstablecimientosVm>>(categorias);
        }
    }
}
