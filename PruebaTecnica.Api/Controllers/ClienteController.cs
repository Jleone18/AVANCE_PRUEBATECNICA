using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.Application.Features.Clientes.Command.Create;
using PruebaTecnica.Application.Features.Clientes.Command.Delete;
using PruebaTecnica.Application.Features.Clientes.Command.Update;
using PruebaTecnica.Application.Features.Clientes.Queries;
using PruebaTecnica.Application.Features.Clientes.Queries.GetClienteByCedulaNombre;
using PruebaTecnica.Application.Features.Clientes.Queries.GetClientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace PruebaTecnica.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ClienteController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("GetCustomersList", Name = "GetCustomersList")]
        [ProducesResponseType(typeof(IEnumerable<ClienteVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ClienteVm>>> GetAllCustomers()
        {
            var query = new GetClientesListQuery();
            var clientes = await _mediator.Send(query);
            return Ok(clientes);

        }
        [HttpGet("{parametro}", Name = "GetCustomerByNombreCedula")]
        [ProducesResponseType(typeof(IEnumerable<ClienteVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ClienteVm>>> GetCustomerByNombreCedula( string parametro)
        {
            var query = new GetClienteQuery(parametro);
            var cliente = await _mediator.Send(query);
            return Ok(cliente);

        }

        [HttpPost(Name = "CreateCustomer")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<long>> CreateCustomer([FromBody] CreateClienteCommand command)
        {
            return await _mediator.Send(command);
        }
        [HttpPut(Name = "UpdateCustomer")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<long>> UpdateCustomer([FromBody] UpdateClienteCommand command)
        {
            return await _mediator.Send(command);

        }
        [HttpDelete("{idCliente}", Name = "DeleteCustomer")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<Unit>> DeleteProduct(long idCliente)
        {
            var command = new DeleteClienteCommand
            {
                IdCliente = idCliente
            };
            return await _mediator.Send(command);

        }
    }
}
