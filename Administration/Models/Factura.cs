using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Administration.Models
{
    public class Factura
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
      
    }
}
