using AutoMapper;
using MediatR;
using PruebaTecnica.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PruebaTecnica.Application.Features.Facturas.Queries.GetFacturaById
{
    public class GetFacturaByIdQueryHandler : IRequestHandler<GetFacturaByIdQuery, FacturaCompletaVm>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetFacturaByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<FacturaCompletaVm> Handle(GetFacturaByIdQuery request, CancellationToken cancellationToken)
        {
            var factura = await _unitOfWork.FacturaRepository.GetFacturaDetallesAsync(request.IdFactura);

            return _mapper.Map<FacturaCompletaVm>(factura);

        }
    }
}
