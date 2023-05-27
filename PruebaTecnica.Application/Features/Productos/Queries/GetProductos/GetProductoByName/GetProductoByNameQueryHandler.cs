using AutoMapper;
using MediatR;
using PruebaTecnica.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PruebaTecnica.Application.Features.Productos.Queries.GetProductos.GetProductoByName
{
    public class GetProductoByNameQueryHandler:IRequestHandler<GetProductoByNameQuery,List<ProductoVm>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetProductoByNameQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<ProductoVm>> Handle(GetProductoByNameQuery request, CancellationToken cancellationToken)
        {
            var productos = await _unitOfWork.ProductoRepository.GetAsync(x => x.IdProducto.Equals(request.Nombre) || x.Descripcion.Equals(request.Nombre));
            return _mapper.Map<List<ProductoVm>>(productos);
        }
    }
}
