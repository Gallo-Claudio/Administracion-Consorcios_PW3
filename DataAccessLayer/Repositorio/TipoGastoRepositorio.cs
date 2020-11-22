using DataAccessLayer.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositorio
{
    public class TipoGastoRepositorio : BaseRepositorio<TipoGasto>
    {

        public TipoGastoRepositorio(ContextoEntities contexto) : base(contexto)
        {
        }

    }
}
