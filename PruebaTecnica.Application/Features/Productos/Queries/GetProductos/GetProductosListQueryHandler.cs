using AutoMapper;
using MediatR;
using PruebaTecnica.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PruebaTecnica.Application.Features.Productos.Queries.GetProductos
{
    public class GetProductosListQueryHandler : IRequestHandler<GetProductosListQuery, List<ProductoVm>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetProductosListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<ProductoVm>> Handle(GetProductosListQuery request, CancellationToken cancellationToken)
        {
            var producto = await _unitOfWork.ProductoRepository.GetAllAsync();
            return _mapper.Map<List<ProductoVm>>(producto);
        }
    }
}
