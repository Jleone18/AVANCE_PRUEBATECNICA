using AutoMapper;
using MediatR;
using PruebaTecnica.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PruebaTecnica.Application.Features.Cajas.Queries.GetCajas
{
    public class GetCajasListQueryHandler:IRequestHandler<GetCajasListQuery,List<CajaVm>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetCajasListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<CajaVm>> Handle(GetCajasListQuery request, CancellationToken cancellationToken)
        {
            var cajas = await _unitOfWork.CajaRepository.GetAllAsync();
            return _mapper.Map<List<CajaVm>>(cajas);
        }
    }
}
