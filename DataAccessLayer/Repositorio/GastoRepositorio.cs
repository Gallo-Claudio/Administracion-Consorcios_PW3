using DataAccessLayer.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositorio
{
    public class GastoRepositorio
    {
        ContextoEntities ctxGasto;

        public GastoRepositorio(ContextoEntities contexto)
        {
            ctxGasto = contexto;
        }

        public void Alta(Gasto gasto)
        {
            ctxGasto.Gasto.Add(gasto);
            ctxGasto.SaveChanges();
        }

        public List<Gasto> ObtenerTodos(int id)
        {
            List<Gasto> todosLosGastos = (from gastobd in ctxGasto.Gasto
                                          where gastobd.Consorcio.IdConsorcio == id
                                          orderby gastobd.FechaGasto descending
                                          select gastobd).ToList();
            return todosLosGastos;
        }
       
        public Gasto ObtenerPorId(int idGasto)
        {
            Gasto gasto;
            gasto = ctxGasto.Gasto.Find(idGasto);
            return gasto;
        } 
       
        public void EliminarGastosConsorcio(int id)
        {
            List<Gasto> GastosConsorcio = (from gastobd in ctxGasto.Gasto
                                              where gastobd.IdConsorcio == id
                                              select gastobd).ToList();

            foreach (Gasto gasto in GastosConsorcio)
            {
                ctxGasto.Gasto.Remove(gasto);
            }

            ctxGasto.SaveChanges();
        }

        public void Modificar(Gasto gasto)
        {
            Gasto gastoActual = ObtenerPorId(gasto.IdGasto);
            gastoActual.Nombre = gasto.Nombre;
            gastoActual.Descripcion = gasto.Descripcion;
            gastoActual.TipoGasto = gasto.TipoGasto;
            gastoActual.FechaGasto = gasto.FechaGasto;
            gastoActual.AnioExpensa = gasto.AnioExpensa;
            gastoActual.MesExpensa = gasto.MesExpensa;
            gastoActual.ArchivoComprobante = gasto.ArchivoComprobante;
            gastoActual.Monto = gasto.Monto;

            ctxGasto.SaveChanges();
        }
        public void EliminarGasto(int idGasto)
        {
            Gasto gasto = ObtenerPorId(idGasto);
            ctxGasto.Gasto.Remove(gasto);
            ctxGasto.SaveChanges();

        }
        
    }
}
