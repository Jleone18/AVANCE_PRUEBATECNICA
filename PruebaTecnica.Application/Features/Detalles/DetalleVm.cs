using PruebaTecnica.Application.Features.Productos.Queries.GetProductos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Application.Features.Detalles
{
    public class DetalleVm
    {
        public long? IdDetalle { get; set; }
        public ProductoVm? Producto { get; set; }
        public decimal? Cantidad { get; set; }
        public string? UnidadMedida { get; set; }
        public double? Precio { get; set; }
        public double? Iva { get; set; }
        public double? Subtotal { get; set; }
    }
}
