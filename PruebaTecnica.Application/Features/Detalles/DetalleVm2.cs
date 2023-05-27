using PruebaTecnica.Application.Features.Productos.Queries.GetProductos;
using PruebaTecnica.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Application.Features.Detalles
{
    public class DetalleVm2
    {
        public long IdDetalle { get; set; }
        public List<Producto> Producto { get; set; }
        public decimal Cantidad { get; set; }
        public string UnidadMedida { get; set; }
        public double Precio { get; set; }
        public double Iva { get; set; }
        public double Subtotal { get; set; }
    }
}
