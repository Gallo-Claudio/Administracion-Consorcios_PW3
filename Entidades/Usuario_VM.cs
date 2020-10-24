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
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 7)]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        [Display(Name = "Reingresar Password")]
        public string ReingresoPassword { get; set; }
    }
}
