using DataAccessLayer.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositorio
{
    public class GastoRepositorio : BaseRepositorio<Gasto>
    {
        public GastoRepositorio(ContextoEntities contexto) : base(contexto)
        {
        }

        public List<Gasto> ObtenerTodos(int id)
        {
            List<Gasto> todosLosGastos = (from gastobd in dbSet
                                          where gastobd.Consorcio.IdConsorcio == id
                                          orderby gastobd.FechaGasto descending
                                          select gastobd).ToList();
            return todosLosGastos;
        }
       
        // Elimina todos los gastos del consorcio pasado por id
        public void EliminarGastosConsorcio(int id)
        {
            List<Gasto> GastosConsorcio = (from gastobd in dbSet
                                           where gastobd.IdConsorcio == id
                                              select gastobd).ToList();

            foreach (Gasto gasto in GastosConsorcio)
            {
                dbSet.Remove(gasto);
            }

            ctx.SaveChanges();
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

            ctx.SaveChanges();
        }
        
    }
}
