using AutoMapper;
using MediatR;
using PruebaTecnica.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PruebaTecnica.Application.Features.Clientes.Queries.GetClienteByCedulaNombre
{
    public class GetClienteQueryHandler:IRequestHandler<GetClienteQuery,List<ClienteVm>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetClienteQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<ClienteVm>> Handle(GetClienteQuery request, CancellationToken cancellationToken)
        {
            var clientes = await _unitOfWork.ClienteRepository.GetAsync(x => x.Identificacion.Equals(request.Parametro) || x.Nombre.Equals(request.Parametro));
            return _mapper.Map<List<ClienteVm>>(clientes);
        }
    }
}
