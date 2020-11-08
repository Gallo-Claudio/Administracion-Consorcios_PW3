using DataAccessLayer.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositorio
{
    public class UnidadRepositorio
    {
        ContextoEntities ctxUnidad;

        public UnidadRepositorio(ContextoEntities contexto)
        {
            ctxUnidad = contexto;
        }

        public void Alta(Unidad unidad)
        {
            ctxUnidad.Unidad.Add(unidad);
            ctxUnidad.SaveChanges();
        }

        public List<Unidad> MostrarTodas(int id)
        {
            List<Unidad> todasUnidades = (from unidadbd in ctxUnidad.Unidad
                                          where unidadbd.Consorcio.IdConsorcio == id
                                          orderby unidadbd.Nombre
                                          select unidadbd).ToList();
            return todasUnidades;
        }

        public Unidad BuscarPorId(int idUnidad)
        {
            Unidad unidad;
            unidad = ctxUnidad.Unidad.Find(idUnidad);

            return unidad;
        }

        public void Eliminar(int idUnidad)
        {
            Unidad unidad;
            unidad = BuscarPorId(idUnidad);

            if (unidad != null)
            {
                ctxUnidad.Unidad.Remove(unidad);
                ctxUnidad.SaveChanges();
            }
        }

        public void Modificar(Unidad unidad)
        {
            Unidad unidadActual;

            unidadActual = BuscarPorId(unidad.IdUnidad);
            unidadActual.Nombre = unidad.Nombre;
            unidadActual.NombrePropietario = unidad.NombrePropietario;
            unidadActual.ApellidoPropietario = unidad.ApellidoPropietario;
            unidadActual.EmailPropietario = unidad.EmailPropietario;
            unidadActual.Superficie = unidad.Superficie;

            ctxUnidad.SaveChanges();

        }

        public void EliminarUnidadesConsorcio(int id)
        {
            List<Unidad> UnidadesConsorcio = (from unidadbd in ctxUnidad.Unidad
                                              where unidadbd.IdConsorcio == id
                                              select unidadbd).ToList();

            foreach (Unidad unidad in UnidadesConsorcio)
            {
                ctxUnidad.Unidad.Remove(unidad);
            }

            ctxUnidad.SaveChanges();
        }
    }
}

