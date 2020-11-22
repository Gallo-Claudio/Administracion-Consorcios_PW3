using DataAccessLayer.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositorio
{
    public class ConsorcioRepositorio : BaseRepositorio<Consorcio>
    {
        public ConsorcioRepositorio(ContextoEntities contexto) : base(contexto)
        {
        }

        public List<Consorcio> ObtenerTodos(int id)
        {
            List<Consorcio> todosLosConsorcios = (from consorciobd in dbSet
                                                  where consorciobd.Usuario.IdUsuario == id
                                                  orderby consorciobd.Nombre
                                                  select consorciobd).ToList();
            return todosLosConsorcios;
        }

        public void Modificar(Consorcio consorcio)
        {
            Consorcio consorcioActual = ObtenerPorId(consorcio.IdConsorcio);
            consorcioActual.Altura = consorcio.Altura;
            consorcioActual.Calle = consorcio.Calle;
            consorcioActual.Ciudad = consorcio.Ciudad;
            consorcioActual.DiaVencimientoExpensas = consorcio.DiaVencimientoExpensas;
            consorcioActual.Gasto = consorcio.Gasto;
            consorcioActual.IdProvincia = consorcio.IdProvincia;
            consorcioActual.Nombre = consorcio.Nombre;
            consorcioActual.Unidad = consorcio.Unidad;
            consorcioActual.Provincia = consorcio.Provincia;
            //consorcioActual.FechaCreacion = new DateTime(1700, 01, 01, 22, 45, 36);  //Activar para probar la execpcion
            ctx.SaveChanges();
        }

    }
}