using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MotoFinal.Models
{
    public class Domicilio
    {
        public int idDomicilio { get; set; }
        [Required(ErrorMessage ="Este campo es obligatorio")]
        public string calle { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string entreCalle { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string yCalle { get; set; }
        public string tipo { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string pais { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string estado { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string municipio { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [StringLength(5,ErrorMessage ="El código postal consta de 5 caracteres")]
        public string codigoPostal { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string descripcion { get; set; }
        public string establecimiento_idEstablecimiento { get; set; }
    }
}