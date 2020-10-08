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

        public static void AgregarConsorcio(Consorcio nuevoConsorcio, int IdProvincia)
        {
            nuevoConsorcio.IdProvincia = ProvinciaServicio.BuscarProvincia(IdProvincia);          
            nuevoConsorcio.FechaCreacion = DateTime.Now;
            nuevoConsorcio.IdUsuarioCreador = Hardcodeo.usu1; // HARDCODEADO - Este valor se debe obtener de la sesion
            nuevoConsorcio.IdConsorcio = Hardcodeo.consorcio.Last().IdConsorcio + 1;   // Este valor es un autoincremental generado en la BD
            Hardcodeo.consorcio.Add(nuevoConsorcio);
        }

    }
}
