using System;
using System.Collections.Generic;

#nullable disable

namespace PruebaTecnica.Domain.Models
{
    public partial class Caja
    {
        public Caja()
        {
            Facturas = new HashSet<Factura>();
        }

        public long IdCaja { get; set; }
        public string NumeroCaja { get; set; }

        public virtual ICollection<Factura> Facturas { get; set; }
    }
}
