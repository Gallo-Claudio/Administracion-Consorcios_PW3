using DataAccessLayer.Modelos;
using DataAccessLayer.Repositorio;
using System.Collections.Generic;

namespace Servicios
{
    public class TipoGastoServicio : BaseServicios<TipoGastoRepositorio, TipoGasto>
    {
        public TipoGastoServicio(ContextoEntities contexto) : base(contexto)
        {
        }

        public TipoGasto BuscarTipoGasto(int id)
        {
            TipoGasto tipoGasto = repo.ObtenerPorId(id);
            return tipoGasto;
        }

    }
}