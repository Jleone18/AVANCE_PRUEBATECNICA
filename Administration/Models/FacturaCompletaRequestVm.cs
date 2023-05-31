using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Administration.Models
{
    public class FacturaCompletaRequestVm
    {
     
        public long IdCaja { get; set; }
        public long IdEstablecimiento { get; set; }
        public string NumeroFactura { get; set; }
        public DateTime Fecha { get; set; }
        public long IdCliente { get; set; }
        public double? Subtotal { get; set; }
        public double? TotalIva { get; set; }
        public double? Total { get; set; }
        public List<DetalleVm2> Detalles { get; set; }
    }
    public class DetalleVm2
    {
     
        public long IdProducto { get; set; }
        public decimal Cantidad { get; set; }
        public string UnidadMedida { get; set; }
        public double Precio { get; set; }
        public double Iva { get; set; }
        public double Subtotal { get; set; }
    }
  
}
