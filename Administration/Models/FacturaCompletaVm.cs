using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Administration.Models
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
    public class ClienteVm
    {
        public long IdCliente { get; set; }
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
    }
    public class DetalleVm
    {
        public long IdDetalle { get; set; }
        public ProductoVm Producto { get; set; }
        public decimal Cantidad { get; set; }
        public string UnidadMedida { get; set; }
        public double Precio { get; set; }
        public double Iva { get; set; }
        public double Subtotal { get; set; }
    }
    public class ProductoVm
    {
        public long IdProducto { get; set; }
        public string Categoria { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
    }
}
