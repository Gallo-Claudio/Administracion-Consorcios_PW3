using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Consorcio
    {
        public int IdConsorcio { get; set; }

        public string Nombre { get; set; }

        // many to one
        public Provincia IdProvincia { get; set; }

        public string Ciudad { get; set; }

        public string Calle { get; set; }

        public int Altura { get; set; }

        public int DiaVencimientoExpensas { get; set; }

        public DateTime FechaCreacion { get; set; }

        // many to one
        public Usuario IdUsuarioCreador { get; set; }
    }
}
