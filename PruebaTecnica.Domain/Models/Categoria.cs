using System;
using System.Collections.Generic;

#nullable disable

namespace PruebaTecnica.Domain.Models
{
    public partial class Categoria
    {
        public Categoria()
        {
            Productos = new HashSet<Producto>();
        }

        public long IdCategoria { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Producto> Productos { get; set; }
    }
}
