using DataAccessLayer.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositorio
{
    public class ProvinciaRepositorio
    {
        ContextoEntities provincia;

        public ProvinciaRepositorio (ContextoEntities contexto)
        {
            provincia = contexto;
        }

        public List<Provincia> ObtenerTodos()
        {
            List<Provincia> todasLasProvincias = provincia.Provincia.ToList();
            return todasLasProvincias;
        }

        public Provincia ObtenerPorId(int idProvincia)
        {
            Provincia provincia;
            provincia = this.provincia.Provincia.Find(idProvincia);
            return provincia;
        }
    }
}
