using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Unidad
    {
        public int IdUnidad { get; set; }

        // many to one
        public Consorcio IdConsorcio { get; set; }

        public string Nombre { get; set; }

        public string NombrePropietario { get; set; }

        public string ApellidoPropietario { get; set; }

        public string EmailPropietario { get; set; }

        public int Superficie { get; set; }

        public DateTime FechaCreacion { get; set; }

        // many to one
        public Usuario IdUsuarioCreador { get; set; }
    }
}
