using PruebaTecnica.Application.Features.Clientes.Queries;
using PruebaTecnica.Application.Features.Detalles;
using PruebaTecnica.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Application.Features.Facturas.Queries
{
    public class FacturaCompletaVm
    {
        public long IdFactura { get; set; }
        public string PuntoEmision { get; set; }
        public string Establecimiento { get; set; }
        public string NumeroFactura { get; set; }
        public DateTime Fecha { get; set; }
        public ClienteVm Cliente { get; set; }
        public double? Subtotal { get; set; }
        public double? TotalIva { get; set; }
        public double? Total { get; set; }
        public List<DetalleVm> Detalles { get; set; }
    }

}
