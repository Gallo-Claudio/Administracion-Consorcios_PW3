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
        ConsorcioRepositorio repoConsorcio;
        TipoGastoRepositorio repoTipoGasto;
        UsuarioRepositorio repoUsuario;

        public GastoServicio(ContextoEntities contexto)
        {
            ContextoEntities ctx = contexto;
            repoGasto = new GastoRepositorio(ctx);
            repoConsorcio = new ConsorcioRepositorio(ctx);
            repoTipoGasto = new TipoGastoRepositorio(ctx);
            repoUsuario = new UsuarioRepositorio(ctx);
        }

        public List<Gasto> ListarGastos(int id)
        {
            return repoGasto.ObtenerTodos(id);
        }

        public void AgregarGasto(Gasto nuevoGasto, object Session)
        {
            nuevoGasto.IdConsorcio = repoConsorcio.ObtenerPorId(nuevoGasto.Consorcio.IdConsorcio).IdConsorcio;
            nuevoGasto.IdTipoGasto = repoTipoGasto.ObtenerPorId(nuevoGasto.TipoGasto.IdTipoGasto).IdTipoGasto;
            nuevoGasto.IdUsuarioCreador = (int)Session;
            nuevoGasto.FechaCreacion = DateTime.Now;
            nuevoGasto.ArchivoComprobante = "/Gastos/" + nuevoGasto.ArchivoComprobante;
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
            gastoModificacion.TipoGasto = repoTipoGasto.ObtenerPorId(gastoModificacion.IdTipoGasto);
            repoGasto.Modificar(gastoModificacion);
        }

        public void EliminarGasto(int id)
        {
            repoGasto.EliminarGasto(id);
        }
    }
}
