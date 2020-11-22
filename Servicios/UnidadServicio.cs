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

        public List<Unidad> ListarUnidades(int id)
        {
            return repoUnidad.MostrarTodas(id);
        }

        public void AgregarUnidades(Unidad unidad)
        {
            repoUnidad.Alta(unidad);
        }
        public void EliminarUnidad(int id)
        {
            repoUnidad.Eliminar(id);
        }

        public Unidad BuscarUnidad(int id)
        {
            Unidad unidad = repoUnidad.ObtenerPorId(id);

            return unidad;
        }

        public int BuscarIdDeUnidad(Unidad unidad)
        {
            int idUnidad = unidad.IdUnidad;

            return idUnidad;
        }

        public void ModificarUnidad(Unidad unidad)
        {
            repoUnidad.Modificar(unidad);

        }

        public void EliminarUnidadesDeConsorcio(int id)
        {
            repoUnidad.EliminarUnidadesConsorcio(id);
        }
    }
}
