using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Administration.Models
{
    public class ProductVm
    {
        public long IdProducto { get; set; }
        public long IdCategoria { get; set; }
        public string Categoria { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
    }
}
