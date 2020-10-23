using DataAccessLayer.Modelos;
using DataAccessLayer.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class ConsorcioServicio
    {
        ConsorcioRepositorio repositorio;
        ProvinciaRepositorio repoProvincia;

        public ConsorcioServicio(ContextoEntities contexto)
        {
            ContextoEntities ctx = contexto;
            repositorio = new ConsorcioRepositorio(ctx);
            repoProvincia = new ProvinciaRepositorio(ctx);
        }

        public List<Consorcio> ListarConsorcios()
        {
            return repositorio.ObtenerTodos();
        }

        public void AgregarConsorcio(Consorcio nuevoConsorcio, object Session)
        {
            nuevoConsorcio.Provincia = repoProvincia.ObtenerPorId(nuevoConsorcio.Provincia.IdProvincia);
            nuevoConsorcio.FechaCreacion = DateTime.Now;
            nuevoConsorcio.IdUsuarioCreador = (int)Session; 
            repositorio.Alta(nuevoConsorcio);
        }

        public Consorcio BuscarConsorcio(int id)
        {
            Consorcio busquedaConsorcio = repositorio.ObtenerPorId(id);
            return busquedaConsorcio;
        }

        public int BuscarIdConsorcio(Consorcio consorcio)
        {
            int idConsorcio = consorcio.IdConsorcio;
            return idConsorcio;
        }

        public void ModificarConsorcio(Consorcio consorcioModificacion)
        {
            int id = consorcioModificacion.IdConsorcio;
            Consorcio edicionConsorcio = repositorio.ObtenerPorId(id);

            edicionConsorcio.Altura = consorcioModificacion.Altura;
            edicionConsorcio.Calle = consorcioModificacion.Calle;
            edicionConsorcio.Ciudad = consorcioModificacion.Ciudad;
            edicionConsorcio.DiaVencimientoExpensas = consorcioModificacion.DiaVencimientoExpensas;
            edicionConsorcio.IdConsorcio = consorcioModificacion.IdConsorcio;
            edicionConsorcio.Nombre = consorcioModificacion.Nombre;
            edicionConsorcio.Provincia = repoProvincia.ObtenerPorId(consorcioModificacion.Provincia.IdProvincia);
            repositorio.Modificar(edicionConsorcio);
        }


        //// ***** PASARLO A GASTOSERVICIO O COMO SE TERMINE LLAMANDO *****
        //public static void EliminarGastos(Consorcio consorcioEliminar)
        //{
        //    foreach (Gasto gastoEliminar in Hardcodeo.gasto)
        //    {
        //        if (gastoEliminar.IdConsorcio == consorcioEliminar)
        //        {
        //            Hardcodeo.gasto.RemoveAt(gastoEliminar.IdGasto);
        //        }
        //    }
        //}

        //// ***** PASARLO A UNIDADSERVICIO O COMO SE TERMINE LLAMANDO *****
        //public static void EliminarUnidades(Consorcio consorcioEliminar)
        //{
        //    foreach (Unidad unidadEliminar in Hardcodeo.unidad)
        //    {
        //        if (unidadEliminar.IdConsorcio == consorcioEliminar)
        //        {
        //            Hardcodeo.unidad.RemoveAt(unidadEliminar.IdUnidad);
        //        }
        //    }
        //}

        //public static void EliminarConsorcio(Consorcio consorcioEliminar)
        //{
        //    int Id = consorcioEliminar.IdConsorcio;
        //    Hardcodeo.consorcio.RemoveAt(Id);
        //}
    }
}