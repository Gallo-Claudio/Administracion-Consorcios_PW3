using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Usuario
    {
        public int IdUsuario { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 7)]
        public string Password { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        public DateTime FechaRegistracion { get; set; }

        public DateTime FechaUltLogin { get; set; }
    }
}
