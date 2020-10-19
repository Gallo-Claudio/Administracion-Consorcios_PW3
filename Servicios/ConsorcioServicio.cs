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

        public static void AgregarConsorcio(Consorcio nuevoConsorcio)
        {
            nuevoConsorcio.IdProvincia = ProvinciaServicio.BuscarProvincia(nuevoConsorcio.IdProvincia.IdProvincia);
            //nuevoConsorcio.FechaCreacion = DateTime.Now;
            //nuevoConsorcio.IdUsuarioCreador = Hardcodeo.usu1; // HARDCODEADO - Este valor se debe obtener de la sesion
            nuevoConsorcio.IdConsorcio = Hardcodeo.consorcio.Last().IdConsorcio + 1;   // Este valor es un autoincremental generado en la BD
            Hardcodeo.consorcio.Add(nuevoConsorcio);
        }

        public static Consorcio BuscarConsorcio(int id)
        {
            Consorcio busquedaConsorcio = Hardcodeo.consorcio.Find(c => c.IdConsorcio == id);
            return busquedaConsorcio;
        }

        public static int BuscarIdConsorcio(Consorcio consorcio)
        {
            int idConsorcio = consorcio.IdConsorcio;
            return idConsorcio;
        }

        public static void ModificarConsorcio(Consorcio consorcioModificacion)
        {
            int id = consorcioModificacion.IdConsorcio;
            Consorcio edicionConsorcio = Hardcodeo.consorcio.Find(c => c.IdConsorcio == id);

            edicionConsorcio.Altura = consorcioModificacion.Altura;
            edicionConsorcio.Calle = consorcioModificacion.Calle;
            edicionConsorcio.Ciudad = consorcioModificacion.Ciudad;
            edicionConsorcio.DiaVencimientoExpensas = consorcioModificacion.DiaVencimientoExpensas;
            //edicionConsorcio.FechaCreacion = consorcioModificacion.FechaCreacion;
            edicionConsorcio.IdConsorcio = consorcioModificacion.IdConsorcio;
            edicionConsorcio.Nombre = consorcioModificacion.Nombre;
            //edicionConsorcio.IdUsuarioCreador = consorcioModificacion.IdUsuarioCreador;
            edicionConsorcio.IdProvincia = ProvinciaServicio.BuscarProvincia(consorcioModificacion.IdProvincia.IdProvincia);
        }


        // ***** PASARLO A GASTOSERVICIO O COMO SE TERMINE LLAMANDO *****
        public static void EliminarGastos(Consorcio consorcioEliminar)
        {
            foreach (Gasto gastoEliminar in Hardcodeo.gasto)
            {
                if (gastoEliminar.IdConsorcio == consorcioEliminar)
                {
                    Hardcodeo.gasto.RemoveAt(gastoEliminar.IdGasto);
                }
            }
        }

        // ***** PASARLO A UNIDADSERVICIO O COMO SE TERMINE LLAMANDO *****
        public static void EliminarUnidades(Consorcio consorcioEliminar)
        {
            foreach (Unidad unidadEliminar in Hardcodeo.unidad)
            {
                if (unidadEliminar.IdConsorcio == consorcioEliminar)
                {
                    Hardcodeo.unidad.RemoveAt(unidadEliminar.IdUnidad);
                }
            }
        }

        public static void EliminarConsorcio(Consorcio consorcioEliminar)
        {
            int Id = consorcioEliminar.IdConsorcio;
            Hardcodeo.consorcio.RemoveAt(Id);
        }
    }
}