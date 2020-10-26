using DataAccessLayer.Modelos;
using DataAccessLayer.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class UnidadServicio
    {
        UnidadRepositorio repoUnidad;

        public UnidadServicio(ContextoEntities contexto)
        {
            ContextoEntities ctx = contexto;

            repoUnidad = new UnidadRepositorio(ctx);
        }

        public List<Unidad> ListarUnidades(object session)
        {
            int id = (int)session;
            return repoUnidad.MostrarTodas(id);
        }

        /*public void AgregarUnidades(Unidad unidad, object session)
        {

        }*/
        public void EliminarUnidad(object session)
        {
            int id = (int)session;
            repoUnidad.Eliminar(id);
        }

        public Unidad BuscarUnidad(int id)
        {
            Unidad unidad = repoUnidad.BuscarPorId(id);

            return unidad;
        }

        public int BuscarIdDeUnidad(Unidad unidad)
        {
            int idUnidad = unidad.IdUnidad;

            return idUnidad;
        }

        public void ModificarUnidad(Unidad unidad)
        {
            int id = unidad.IdUnidad;

            Unidad unidadModificada = repoUnidad.BuscarPorId(id);

            unidadModificada.Nombre = unidad.Nombre;
            unidadModificada.NombrePropietario = unidad.NombrePropietario;
            unidadModificada.ApellidoPropietario = unidad.ApellidoPropietario;
            unidadModificada.EmailPropietario = unidad.EmailPropietario;
            unidadModificada.Superficie = unidad.Superficie;

            repoUnidad.Modificar(unidadModificada);

        }
    }
}
