using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.Application.Features.Facturas;
using PruebaTecnica.Application.Features.Facturas.Commands.Create;
using PruebaTecnica.Application.Features.Facturas.Commands.Delete;
using PruebaTecnica.Application.Features.Facturas.Commands.Update;
using PruebaTecnica.Application.Features.Facturas.Queries;
using PruebaTecnica.Application.Features.Facturas.Queries.GetFacturas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace PruebaTecnica.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FacturaController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("GetInvoicesList", Name = "GetInvoiceList")]
        [ProducesResponseType(typeof(IEnumerable<FacturaVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<FacturaVm>>> GetAllInvoices()
        {
            var query = new GetFacturasListQuery();
            var facturas = await _mediator.Send(query);
            return Ok(facturas);

        }


        [HttpGet("{idFactura}", Name = "GetInvoice")]
        [ProducesResponseType(typeof(IEnumerable<FacturaCompletaVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<FacturaCompletaVm>>> GetAllInvoice(long idFactura)
        {
            var query = new GetFacturaByIdQuery(idFactura);
            var factura = await _mediator.Send(query);
            return Ok(factura);

        }


        [HttpPost(Name = "CreateInvoice")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<long>> CreateInvoice([FromBody] CreateFacturaCommand command)
        {
            return await _mediator.Send(command);
        }
        [HttpPut(Name = "UpdateInvoice")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateInvoice([FromBody] UpdateFacturaCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }
        [HttpDelete("{idInvoice}", Name = "DeleteInvoice")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteInvoice(long idInvoice)
        {
            var command = new DeleteFacturaCommand
            {
                IdFactura = idInvoice
            };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
