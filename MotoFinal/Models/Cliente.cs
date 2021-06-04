using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MotoFinal.Models
{
    public class Cliente
    {
        public string idCliente { get; set; }
        public string puntosCliente { get; set; }
        public string usuario_nombreUsuario { get; set; }

    }
}