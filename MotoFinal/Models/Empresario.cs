using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MotoFinal.Models
{
    public class Empresario
    {
        public string idEmpresario { get; set; }
        public string usuario_nombreUsuario { get; set; }
        public string establecimiento_idEstablecimiento { get; set; }

        public Empresario(string idEmpresario, string usuario_nombreUsuario, string establecimiento_idEstablecimiento)
        {
            this.idEmpresario = idEmpresario;
            this.usuario_nombreUsuario = usuario_nombreUsuario;
            this.establecimiento_idEstablecimiento = establecimiento_idEstablecimiento;
        }
    }
}