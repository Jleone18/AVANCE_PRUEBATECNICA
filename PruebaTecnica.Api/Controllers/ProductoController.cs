using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.Application.Features.Productos.Command.Create;
using PruebaTecnica.Application.Features.Productos.Command.Delete;
using PruebaTecnica.Application.Features.Productos.Command.Update;
using PruebaTecnica.Application.Features.Productos.Queries.GetProductos;
using PruebaTecnica.Application.Features.Productos.Queries.GetProductos.GetProductoByName;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace PruebaTecnica.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductoController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("GetProductsList", Name = "GetProductsList")]
        [ProducesResponseType(typeof(IEnumerable<ProductoVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ProductoVm>>> GetAllCategories()
        {
            var query = new GetProductosListQuery();
            var productos = await _mediator.Send(query);
            return Ok(productos);

        }
        [HttpGet("parametro", Name = "GetProductsByNombre")]
        [ProducesResponseType(typeof(IEnumerable<ProductoVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ProductoVm>>> GetProductsByNombre(string parametro)
        {
            var query = new GetProductoByNameQuery(parametro);
            var productos = await _mediator.Send(query);
            return Ok(productos);

        }

        [HttpPost(Name = "CreateProduct")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<long>> CreateProduct([FromBody] CreateProductoCommand command)
        {
            return await _mediator.Send(command);
        }
        [HttpPut(Name = "UpdateProduct")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<long>> UpdateProduct([FromBody] UpdateProductoCommand command)
        {
            return await _mediator.Send(command);
           
        }
        [HttpDelete("{idProducto}", Name = "DeleteProduct")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<Unit>> DeleteProduct(long idProducto)
        {
            var command = new DeleteProductoCommand
            {
                IdProducto = idProducto
            };
            return await _mediator.Send(command);
            
        }
    }
}
