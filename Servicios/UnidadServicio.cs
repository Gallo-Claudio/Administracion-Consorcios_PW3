using DataAccessLayer.Modelos;
using DataAccessLayer.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class UnidadServicio : BaseServicios<UnidadRepositorio, Unidad>
    {
        public UnidadServicio(ContextoEntities contexto) : base(contexto)
        {
        }

        public List<Unidad> ListarUnidades(int id)
        {
            return repo.MostrarTodas(id);
        }

        public void AgregarUnidades(Unidad unidad, object Session)
        {
            unidad.FechaCreacion = DateTime.Now;
            unidad.IdUsuarioCreador = (int)Session;
            repo.Alta(unidad);
        }

        //public int BuscarIdDeUnidad(Unidad unidad)
        //{
        //    int idUnidad = unidad.IdUnidad;

        //    return idUnidad;
        //}

        public void ModificarUnidad(Unidad unidad)
        {
            repo.Modificar(unidad);
        }

        public void EliminarUnidadesDeConsorcio(int id)
        {
            repo.EliminarUnidadesConsorcio(id);
        }
    }
}