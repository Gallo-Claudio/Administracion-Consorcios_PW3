using DataAccessLayer.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositorio
{
    public class ProvinciaRepositorio : BaseRepositorio<Provincia>
    {
        public ProvinciaRepositorio (ContextoEntities contexto) : base(contexto)
        {
        }

    }
}
