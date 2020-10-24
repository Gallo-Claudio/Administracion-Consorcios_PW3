using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Usuario6
    {
        public int IdUsuario { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Nombre { get; set; }

        public DateTime FechaRegistracion { get; set; }

        public DateTime FechaUltLogin { get; set; }
    }
}