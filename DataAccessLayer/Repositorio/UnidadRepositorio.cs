using DataAccessLayer.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositorio
{
    public class UnidadRepositorio : BaseRepositorio<Unidad>
    {
        public UnidadRepositorio(ContextoEntities contexto) : base(contexto)
        {
        }

        public List<Unidad> MostrarTodas(int id)
        {
            List<Unidad> todasUnidades = (from unidadbd in dbSet
                                          where unidadbd.Consorcio.IdConsorcio == id
                                          orderby unidadbd.Nombre
                                          select unidadbd).ToList();

            return todasUnidades;
        }

        public void Modificar(Unidad unidad)
        {
            Unidad unidadActual;

            unidadActual = ObtenerPorId(unidad.IdUnidad);
            unidadActual.Nombre = unidad.Nombre;
            unidadActual.NombrePropietario = unidad.NombrePropietario;
            unidadActual.ApellidoPropietario = unidad.ApellidoPropietario;
            unidadActual.EmailPropietario = unidad.EmailPropietario;
            unidadActual.Superficie = unidad.Superficie;

            ctx.SaveChanges();
        }

        public void EliminarUnidadesConsorcio(int id)
        {
            List<Unidad> UnidadesConsorcio = (from unidadbd in dbSet
                                              where unidadbd.IdConsorcio == id
                                              select unidadbd).ToList();

            foreach (Unidad unidad in UnidadesConsorcio)
            {
                dbSet.Remove(unidad);
            }

            ctx.SaveChanges();
        }
    }
}