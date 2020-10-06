using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Gasto
    {
        public int IdGasto { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        // many to one
        public Consorcio IdConsorcio { get; set; }

        // many to one
        public TipoGasto IdTipoGasto { get; set; }

        public DateTime FechaGasto { get; set; }

        public int AnioExpensa { get; set; }

        public int MesExpensa { get; set; }

        public string ArchivoComprobante { get; set; }

        public double Monto { get; set; }

        public DateTime FechaCreacion { get; set; }

        // many to one
        public Usuario IdUsuarioCreador { get; set; }
    }
}
