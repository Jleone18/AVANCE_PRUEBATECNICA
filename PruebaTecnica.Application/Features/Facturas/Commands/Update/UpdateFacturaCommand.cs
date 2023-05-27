using MediatR;
using PruebaTecnica.Application.Features.Detalles;
using PruebaTecnica.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Application.Features.Facturas.Commands.Update
{
    public class UpdateFacturaCommand : IRequest<long>
    {
        public long IdFactura { get; set; }
        public long IdCaja { get; set; }
        public long IdEstablecimiento { get; set; }
        public long IdCliente { get; set; }
        public string NumeroFactura { get; set; }
        public DateTime Fecha { get; set; }
        public double? Subtotal { get; set; }
        public double? TotalIva { get; set; }
        public double? Total { get; set; }
        public List<DetalleVm> Detalles { get; set; }
    }
}
