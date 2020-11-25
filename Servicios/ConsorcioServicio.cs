using DataAccessLayer.Modelos;
using DataAccessLayer.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class ConsorcioServicio : BaseServicios<ConsorcioRepositorio, Consorcio>
    {
        ProvinciaRepositorio repoProvincia;

        public ConsorcioServicio(ContextoEntities contexto) : base(contexto)
        {
            ContextoEntities ctx = contexto;
            repoProvincia = new ProvinciaRepositorio(ctx);
        }

        public List<Consorcio> ListarConsorcios(object Session)
        {
            int id = (int)Session;
            return repo.ObtenerTodos(id);
        }

        public void AgregarConsorcio(Consorcio nuevoConsorcio, object Session)
        {
            nuevoConsorcio.Provincia = repoProvincia.ObtenerPorId(nuevoConsorcio.IdProvincia);
            nuevoConsorcio.FechaCreacion = DateTime.Now;
            nuevoConsorcio.IdUsuarioCreador = (int)Session;
            repo.Alta(nuevoConsorcio);
        }

        public void ModificarConsorcio(Consorcio consorcioModificacion)
        {
            consorcioModificacion.Provincia = repoProvincia.ObtenerPorId(consorcioModificacion.IdProvincia);
            repo.Modificar(consorcioModificacion);
        }

    }
}