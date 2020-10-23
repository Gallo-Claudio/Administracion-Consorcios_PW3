using DataAccessLayer.Modelos;
using DataAccessLayer.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class ProvinciaServicio
    {
        public ProvinciaRepositorio repositorio;

        public ProvinciaServicio(ContextoEntities contexto)
        {
            ContextoEntities ctx = contexto;
            repositorio = new ProvinciaRepositorio(ctx);
        }

        public List<Provincia> ListarProvincias()
        {
            return repositorio.ObtenerTodos();
        }

        public Provincia SeleccionarProvincia(int id)
        {
            Provincia provinciaBuscada = repositorio.ObtenerPorId(id);
            return provinciaBuscada;
        }
    }
}