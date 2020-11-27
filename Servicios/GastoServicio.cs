using DataAccessLayer.Modelos;
using DataAccessLayer.Repositorio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

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
            nuevoGasto.Consorcio = repoConsorcio.ObtenerPorId(nuevoGasto.IdConsorcio);
            nuevoGasto.TipoGasto = repoTipoGasto.ObtenerPorId(nuevoGasto.IdTipoGasto);
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
            gastoModificacion.TipoGasto = repoTipoGasto.ObtenerPorId(gastoModificacion.IdTipoGasto);
            repo.Modificar(gastoModificacion);
        }

        public string NombreArchivoASubir(HttpPostedFileBase ArchivoComprobante)
        {
            string nombre = Path.GetFileNameWithoutExtension(ArchivoComprobante.FileName);
            string extension = Path.GetExtension(ArchivoComprobante.FileName);

            string fileName = string.Format("{0}_{2:yyyyMMdd-HHmmss}{1}", nombre, extension, DateTime.Now);

            return fileName;
        }
    }
}