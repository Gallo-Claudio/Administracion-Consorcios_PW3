using DataAccessLayer.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositorio
{
    public class TipoGastoRepositorio
    {
        ContextoEntities ctxTipoGasto;

        public TipoGastoRepositorio(ContextoEntities contexto)
        {
            ctxTipoGasto = contexto;
        }

        public List<TipoGasto> ObtenerTodos()
        {
            List<TipoGasto> todosLosTiposGastos = (from tipogastobd in ctxTipoGasto.TipoGasto
                                                   select tipogastobd).ToList();
            return todosLosTiposGastos;
        }

        public TipoGasto ObtenerPorId(int id)
        {
            TipoGasto tipoGasto;
            tipoGasto = ctxTipoGasto.TipoGasto.Find(id);
            return tipoGasto;
        }
    }
}
