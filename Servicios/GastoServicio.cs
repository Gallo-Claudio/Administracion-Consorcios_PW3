using DataAccessLayer.Modelos;
using DataAccessLayer.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class GastoServicio : BaseServicios<GastoRepositorio, Gasto>
    {
        ConsorcioRepositorio repoConsorcio;
        TipoGastoRepositorio repoTipoGasto;

        public GastoServicio(ContextoEntities contexto) : base(contexto)
        {
            ContextoEntities ctx = contexto;
            repoConsorcio = new ConsorcioRepositorio(ctx);
            repoTipoGasto = new TipoGastoRepositorio(ctx);
        }

        public List<Gasto> ListarGastos(int id)
        {
            return repo.ObtenerTodos(id);
        }

        public void AgregarGasto(Gasto nuevoGasto, object Session)
        {
            nuevoGasto.Consorcio= repoConsorcio.ObtenerPorId(nuevoGasto.IdConsorcio);
            nuevoGasto.TipoGasto = repoTipoGasto.ObtenerPorId(nuevoGasto.TipoGasto.IdTipoGasto);
            nuevoGasto.IdUsuarioCreador = (int)Session;
            nuevoGasto.FechaCreacion = DateTime.Now;
            nuevoGasto.ArchivoComprobante = "/Gastos/" + nuevoGasto.ArchivoComprobante;
            repo.Alta(nuevoGasto);
        }

        public void EliminarGastosDeConsorcio(int id)
        {
            repo.EliminarGastosConsorcio(id);
        }

        public void ModificarGasto(Gasto gastoModificacion)
        {
            gastoModificacion.TipoGasto = repoTipoGasto.ObtenerPorId(gastoModificacion.TipoGasto.IdTipoGasto);
            repo.Modificar(gastoModificacion);
        }

    }
}