using System;
using System.Collections.Generic;

#nullable disable

namespace PruebaTecnica.Domain.Models
{
    public partial class Producto
    {
        public Producto()
        {
            Detalles = new HashSet<Detalle>();
        }

        public long IdProducto { get; set; }
        public long IdCategoria { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }

        public virtual Categoria IdCategoriaNavigation { get; set; }
        public virtual ICollection<Detalle> Detalles { get; set; }
    }
}
