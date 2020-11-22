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
        ConsorcioRepositorio repoConsorcio;
        ProvinciaRepositorio repoProvincia;

        public ConsorcioServicio(ContextoEntities contexto)
        {
            ContextoEntities ctx = contexto;
            repoConsorcio = new ConsorcioRepositorio(ctx);
            repoProvincia = new ProvinciaRepositorio(ctx);
        }

        public List<Consorcio> ListarConsorcios(object Session)
        {
            int id = (int)Session;
            return repoConsorcio.ObtenerTodos(id);
        }

        public void AgregarConsorcio(Consorcio nuevoConsorcio, object Session)
        {
            nuevoConsorcio.Provincia = repoProvincia.ObtenerPorId(nuevoConsorcio.Provincia.IdProvincia);
            nuevoConsorcio.FechaCreacion = DateTime.Now;
            nuevoConsorcio.IdUsuarioCreador = (int)Session;
            repoConsorcio.Alta(nuevoConsorcio);
        }

        public Consorcio BuscarConsorcio(int id)
        {
            Consorcio busquedaConsorcio = repoConsorcio.ObtenerPorId(id);
            return busquedaConsorcio;
        }

        //public int BuscarIdConsorcio(Consorcio consorcio)
        //{
        //    int idConsorcio = consorcio.IdConsorcio;
        //    return idConsorcio;
        //}

        public void ModificarConsorcio(Consorcio consorcioModificacion)
        {
            int id = consorcioModificacion.IdConsorcio;
            Consorcio edicionConsorcio = repoConsorcio.ObtenerPorId(id);

            edicionConsorcio.Altura = consorcioModificacion.Altura;
            edicionConsorcio.Calle = consorcioModificacion.Calle;
            edicionConsorcio.Ciudad = consorcioModificacion.Ciudad;
            edicionConsorcio.DiaVencimientoExpensas = consorcioModificacion.DiaVencimientoExpensas;
            //edicionConsorcio.IdConsorcio = consorcioModificacion.IdConsorcio;
            edicionConsorcio.Nombre = consorcioModificacion.Nombre;
            edicionConsorcio.Provincia = repoProvincia.ObtenerPorId(consorcioModificacion.Provincia.IdProvincia);
            repoConsorcio.Modificar(edicionConsorcio);
        }

        public void EliminarConsorcio(int id)
        {
            repoConsorcio.Eliminar(id);
        }
    }
}