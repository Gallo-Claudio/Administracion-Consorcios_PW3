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
    }
}
