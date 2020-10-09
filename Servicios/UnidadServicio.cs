using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class UnidadServicio
    {
        public static int ContarUnidades(int id)
        {
            int cantidadUnidades = 0;
            foreach (Unidad unid in Hardcodeo.unidad)
            {
                if (unid.IdConsorcio.IdConsorcio == id)
                {
                    cantidadUnidades++;
                }
            }

            return cantidadUnidades;
        }
    }
}
