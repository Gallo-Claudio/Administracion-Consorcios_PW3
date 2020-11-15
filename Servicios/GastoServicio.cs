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

        public List<Gasto> ListarGastos(int id)
        {
            return repoGasto.ObtenerTodos(id);
        }

        public void AgregarGasto(Gasto nuevoGasto, object Session)
        {
            //TODO Fijarse que onda el consorcio
            nuevoGasto.IdUsuarioCreador = (int)Session;
            repoGasto.Alta(nuevoGasto);
        }
        public Gasto BuscarGasto(int id)
        {
            Gasto busquedaGasto = repoGasto.ObtenerPorId(id);
            return busquedaGasto;
        }

        public void EliminarGastosDeConsorcio(int id)
        {
            repoGasto.EliminarGastosConsorcio(id);
        }
        
        public void ModificarGasto(Gasto gastoModificacion)
        {
            repoGasto.Modificar(gastoModificacion);
        }

        public void EliminarGasto(int id)
        {
            repoGasto.EliminarGasto(id);
        }
    }
}
