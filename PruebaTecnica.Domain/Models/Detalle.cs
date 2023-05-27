using System;
using System.Collections.Generic;

#nullable disable

namespace PruebaTecnica.Domain.Models
{
    public partial class Detalle
    {
        public long IdDetalle { get; set; }
        public long IdFactura { get; set; }
        public long IdProducto { get; set; }
        public decimal Cantidad { get; set; }
        public string UnidadMedida { get; set; }
        public double Precio { get; set; }
        public double Iva { get; set; }
        public double Subtotal { get; set; }

        public virtual Factura IdFacturaNavigation { get; set; }
        public virtual Producto IdProductoNavigation { get; set; }
    }
}
