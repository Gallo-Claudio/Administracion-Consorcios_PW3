using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public static class ConsorcioServicio
    {
        public static List<Consorcio> ListarConsorcios()
        {
            return Hardcodeo.consorcio;
        }
    }
}
