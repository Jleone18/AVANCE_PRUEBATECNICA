using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.Application.Features.Categorias.Command.Create;
using PruebaTecnica.Application.Features.Categorias.Command.Delete;
using PruebaTecnica.Application.Features.Categorias.Command.Update;
using PruebaTecnica.Application.Features.Categorias.Queries;
using PruebaTecnica.Application.Features.Categorias.Queries.GetCategorias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace PruebaTecnica.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {

        private readonly IMediator _mediator;

        public CategoriaController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("GetCategoriesList", Name = "GetCategoriesList")]
        [ProducesResponseType(typeof(IEnumerable<CategoriaVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<CategoriaVm>>> GetAllCategories()
        {
            var query = new GetCategoriasListQuery();
            var categories = await _mediator.Send(query);
            return Ok(categories);

        }

        [HttpPost(Name = "CreateCategory")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<long>> CreateCategory([FromBody] CreateCategoriaCommand command)
        {
            return await _mediator.Send(command);
        }
        [HttpPut(Name = "UpdateCategory")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateCategory([FromBody] UpdateCategoriaCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }
        [HttpDelete("{idCategoria}", Name = "DeleteCategory")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteCategory(long idCategoria)
        {
            var command = new DeleteCategoriaCommand
            {
                IdCategoria = idCategoria
            };
            await _mediator.Send(command);
            return NoContent();
        }

    }
}
