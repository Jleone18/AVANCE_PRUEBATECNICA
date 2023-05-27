using AutoMapper;
using MediatR;
using PruebaTecnica.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PruebaTecnica.Application.Features.Facturas.Queries.GetFacturas
{
    public class GetFacturasListQueryHandler:IRequestHandler<GetFacturasListQuery,List<FacturaVm>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetFacturasListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<FacturaVm>> Handle(GetFacturasListQuery request, CancellationToken cancellationToken)
        {
            var facturas = await _unitOfWork.FacturaRepository.GetAllFacturaDetallesAsync();
            return _mapper.Map<List<FacturaVm>>(facturas);
        }
    }
}
