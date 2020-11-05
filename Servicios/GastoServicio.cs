using DataAccessLayer.Modelos;
using DataAccessLayer.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class GastoServicio
    {
        GastoRepositorio repoGasto;

        public GastoServicio(ContextoEntities contexto)
        {
            ContextoEntities ctx = contexto;

            repoGasto = new GastoRepositorio(ctx);
        }

        public void EliminarGastosDeConsorcio(int id)
        {
            repoGasto.EliminarGastosConsorcio(id);
        }
    }
}
