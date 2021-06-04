using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MotoFinal.Models
{
    public class Usuario
    {
        [Required(ErrorMessage ="Ingresa un nombre de usuario")]
        public string nombreUsuario { get; set; }
        [Required(ErrorMessage = "Ingresa una contraseña")]
        public string contrasena { get; set; }
        [Required(ErrorMessage = "Ingresa tu nombre")]
        public string nombre { get; set; }
        [Required(ErrorMessage = "Ingresa un apellido")]
        public string apellido1 { get; set; }
        public string apellido2 { get; set; }
        [Required(ErrorMessage = "Selecciona un sexo")]
        public string sexo { get; set; }
        [Required(ErrorMessage = "Ingresa tu fecha de nacimiento")]
        public string fechaNacimiento { get; set; }
        [Required(ErrorMessage = "Ingresa tu numeor de telefono")]
        [StringLength(10,ErrorMessage ="El numero debe contener 10 digitos")]
        public string telefono { get; set; }

        
    }
}