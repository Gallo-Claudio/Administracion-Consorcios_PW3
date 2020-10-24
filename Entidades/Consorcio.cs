using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Consorcio
    {
        public int IdConsorcio { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required]
        // many to one
        public Provincia IdProvincia { get; set; }

        [Required]
        [StringLength(50)]
        public string Ciudad { get; set; }

        [Required]
        [StringLength(50)]
        public string Calle { get; set; }

        [Required]
        public int Altura { get; set; }

        [Required]
        [Range(1, 28)]
        public int DiaVencimientoExpensas { get; set; }

        public DateTime FechaCreacion { get; set; }

        // many to one
        //public Usuario IdUsuarioCreador { get; set; }
    }
}
