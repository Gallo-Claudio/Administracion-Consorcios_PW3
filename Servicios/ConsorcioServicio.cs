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


        //public static Consorcio BuscarConsorcio(int id)
        //{
        //    Consorcio busquedaConsorcio = Hardcodeo.consorcio.Find(c => c.IdConsorcio == id);
        //    return busquedaConsorcio;
        //}

        //public static int BuscarIdConsorcio(Consorcio consorcio)
        //{
        //    int idConsorcio = consorcio.IdConsorcio;
        //    return idConsorcio;
        //}

        //public static void ModificarConsorcio(Consorcio consorcioModificacion)
        //{
        //    int id = consorcioModificacion.IdConsorcio;
        //    Consorcio edicionConsorcio = Hardcodeo.consorcio.Find(c => c.IdConsorcio == id);

        //    edicionConsorcio.Altura = consorcioModificacion.Altura;
        //    edicionConsorcio.Calle = consorcioModificacion.Calle;
        //    edicionConsorcio.Ciudad = consorcioModificacion.Ciudad;
        //    edicionConsorcio.DiaVencimientoExpensas = consorcioModificacion.DiaVencimientoExpensas;
        //    //edicionConsorcio.FechaCreacion = consorcioModificacion.FechaCreacion;
        //    edicionConsorcio.IdConsorcio = consorcioModificacion.IdConsorcio;
        //    edicionConsorcio.Nombre = consorcioModificacion.Nombre;
        //    //edicionConsorcio.IdUsuarioCreador = consorcioModificacion.IdUsuarioCreador;
        //    edicionConsorcio.IdProvincia = ProvinciaServicio.BuscarProvincia(consorcioModificacion.IdProvincia.IdProvincia);
        //}


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