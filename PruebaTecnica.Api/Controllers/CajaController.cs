using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.Application.Features.Cajas.Command.Create;
using PruebaTecnica.Application.Features.Cajas.Command.Delete;
using PruebaTecnica.Application.Features.Cajas.Command.Update;
using PruebaTecnica.Application.Features.Cajas.Queries;
using PruebaTecnica.Application.Features.Cajas.Queries.GetCajas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace PruebaTecnica.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CajaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CajaController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("GetCashRegistersList", Name = "GetCashRegistersList")]
        [ProducesResponseType(typeof(IEnumerable<CajaVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<CajaVm>>> GetAllCashRegisters()
        {
            var query = new GetCajasListQuery();
            var cajas = await _mediator.Send(query);
            return Ok(cajas);

        }

        [HttpPost(Name = "CreateCashRegister")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<long>> CreateCashRegister([FromBody] CreateCajaCommand command)
        {
            return await _mediator.Send(command);
        }
        [HttpPut(Name = "UpdateCashRegister")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateCashRegister([FromBody] UpdateCajaCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }
        [HttpDelete("{idCaja}", Name = "DeleteCashRegister")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteCashRegister(long idCaja)
        {
            var command = new DeleteCajaCommand
            {
                IdCaja = idCaja
            };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
