using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MotoFinal.Models
{
    public class Establecimiento
    {
        public int idEstablecimiento { get; set; }
        [Required(ErrorMessage = "Es necesario colocar un nombre al negocio")]
        public string nombre { get; set; }
        [Required(ErrorMessage ="Es necesario un numero de telefono")]
        [StringLength(10,ErrorMessage ="El telefono solo deben contener 10 digitos")]
        public string telefono1 { get; set; }
        [StringLength(10, ErrorMessage = "El telefono solo deben contener 10 digitos")]
        public string telefono2 { get; set; }
        [Required(ErrorMessage ="Ingrese un correo")]
        [EmailAddress(ErrorMessage ="Ingrese un correo valido")]
        public string correo { get; set; }
        public string paginaWeb { get; set; }
        public string estatus { get; set; }     
        public byte[] fotoPerfil { get; set; }
        public byte[] fotoPortada { get; set; }
        public string descripcion { get; set; }

        /*public Establecimiento(int idEstablecimiento, string nombre, string telefono1, string telefono2, string correo, string paginaWeb, string estatus, byte[] fotoPerfil, byte[] fotoPortada, string descripcion)
        {
            this.idEstablecimiento = idEstablecimiento;
            this.nombre = nombre;
            this.telefono1 = telefono1;
            this.telefono2 = telefono2;
            this.correo = correo;
            this.paginaWeb = paginaWeb;
            this.estatus = estatus;
            this.fotoPerfil = fotoPerfil;
            this.fotoPortada = fotoPortada;
            this.descripcion = descripcion;
        }*/
    }
}