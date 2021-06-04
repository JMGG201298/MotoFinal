using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MotoFinal.Models
{
    public class Producto
    {
        public string idProducto { get; set; }
        public string nombre { get; set; }
        public string contenidoNeto { get; set; }
        public string precio { get; set; }
        public string descripcion { get; set; }
        public byte[] foto { get; set; }
        public string tipo { get; set; }
        public string proveedor { get; set; }
        public string subCategorias_idSubCategorias { get; set; }
    }
}