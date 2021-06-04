using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MotoFinal.Models
{
    public class Repartidor
    {
        public string idRepartidor { get; set; }
        public string puntosRepartidor { get; set; }
        public string usuario_nombreUsuario { get; set; }
    }
}