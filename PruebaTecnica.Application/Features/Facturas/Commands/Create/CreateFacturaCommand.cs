﻿using MediatR;
using PruebaTecnica.Application.Features.Detalles;
using PruebaTecnica.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Application.Features.Facturas.Commands.Create
{
    public class CreateFacturaCommand : IRequest<long>
    {
        public long IdCaja { get; set; }
        public long IdEstablecimiento { get; set; }
        public long IdCliente { get; set; }
        public string NumeroFactura { get; set; }
        public DateTime Fecha { get; set; }
        public double? Subtotal { get; set; }
        public double? TotalIva { get; set; }
        public double? Total { get; set; }
        public List<DetalleVm2> Detalles { get; set; }
    }
}
