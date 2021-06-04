using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MotoFinal.Models;
using System.ComponentModel.DataAnnotations;

namespace MotoFinal.Models
{
    public class ModeloEstablecimiento
    {
        [Required]
        public Establecimiento establecimiento { get; set; }
        [Required]
        public Usuario usuario { get; set; }
        [Required]
        public Domicilio domicilio { get; set; }
    }
}