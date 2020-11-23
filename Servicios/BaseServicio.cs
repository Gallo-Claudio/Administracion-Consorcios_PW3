using DataAccessLayer.Modelos;
using DataAccessLayer.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class BaseServicios<T, J> : IServicios<J> where T : BaseRepositorio<J> where J : class
    {
        protected T repo;
        public BaseServicios(ContextoEntities contexto)
        {
            repo = Activator.CreateInstance(typeof(T), new object[] { contexto }) as T;
        }

        public virtual List<J> Listar()
        {
            return repo.ObtenerTodos();
        }

        public virtual void Eliminar(int id)
        {
            repo.Eliminar(id);
        }

        public virtual J Buscar(int id)
        {
            J objt = repo.ObtenerPorId(id);
            return objt;
        }
    }
}