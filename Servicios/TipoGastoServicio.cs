using DataAccessLayer.Modelos;
using DataAccessLayer.Repositorio;
using System.Collections.Generic;

namespace Servicios
{
    public class TipoGastoServicio
    {
        TipoGastoRepositorio repoTipoGasto;

        public TipoGastoServicio(ContextoEntities contexto)
        {
            ContextoEntities ctx = contexto;

            repoTipoGasto = new TipoGastoRepositorio(ctx);
        }
        public List<TipoGasto> ListarTipoGastos()
        {
            return repoTipoGasto.ObtenerTodos();
        }

        public TipoGasto BuscarUnidad(int id)
        {
            TipoGasto tipoGasto = repoTipoGasto.ObtenerPorId(id);
            return tipoGasto;
        }

    }
}