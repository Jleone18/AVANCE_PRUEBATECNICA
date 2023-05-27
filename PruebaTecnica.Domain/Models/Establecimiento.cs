using System;
using System.Collections.Generic;

#nullable disable

namespace PruebaTecnica.Domain.Models
{
    public partial class Establecimiento
    {
        public Establecimiento()
        {
            Facturas = new HashSet<Factura>();
        }

        public long IdEstablecimiento { get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }

        public virtual ICollection<Factura> Facturas { get; set; }
    }
}
