using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_VM
{
    public class Usuario_VM
    {
        [Required(ErrorMessage = "Debe ingresar un nombre")]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Debe ingresar un Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Debe ingresar un password")]
        [StringLength(20, MinimumLength = 7)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Debe re-ingresar el password")]
        [Compare("Password")]
        public string ReingresoPassword { get; set; }
    }
}
