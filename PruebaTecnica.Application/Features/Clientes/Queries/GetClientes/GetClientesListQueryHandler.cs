using AutoMapper;
using MediatR;
using PruebaTecnica.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PruebaTecnica.Application.Features.Clientes.Queries.GetClientes
{
    public class GetClientesListQueryHandler : IRequestHandler<GetClientesListQuery, List<ClienteVm>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetClientesListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<ClienteVm>> Handle(GetClientesListQuery request, CancellationToken cancellationToken)
        {
            var clientes = await _unitOfWork.ClienteRepository.GetAllAsync();
            return _mapper.Map<List<ClienteVm>>(clientes);
        }
    }
}
