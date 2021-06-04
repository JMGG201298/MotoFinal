using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MotoFinal.Models
{
    public class Subcategorias
    {
        public string idSubcategorias { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string establecimiento_idEstablecimiento { get; set; }
    }
}