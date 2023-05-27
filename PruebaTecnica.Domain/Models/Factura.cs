using System;
using System.Collections.Generic;

#nullable disable

namespace PruebaTecnica.Domain.Models
{
    public partial class Factura
    {
        public Factura()
        {
            Detalles = new HashSet<Detalle>();
        }

        public long IdFactura { get; set; }
        public long IdCaja { get; set; }
        public long IdEstablecimiento { get; set; }
        public long IdCliente { get; set; }
        public string NumeroFactura { get; set; }
        public DateTime Fecha { get; set; }
        public double? Subtotal { get; set; }
        public double? TotalIva { get; set; }
        public double? Total { get; set; }

        public virtual Caja IdCajaNavigation { get; set; }
        public virtual Cliente IdClienteNavigation { get; set; }
        public virtual Establecimiento IdEstablecimientoNavigation { get; set; }
        public virtual ICollection<Detalle> Detalles { get; set; }
    }
}
