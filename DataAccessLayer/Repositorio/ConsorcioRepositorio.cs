using DataAccessLayer.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositorio
{
    public class ConsorcioRepositorio
    {
        ContextoEntities ctxConsorcio;

        public ConsorcioRepositorio(ContextoEntities contexto)
        {
            ctxConsorcio = contexto;
        }


        public void Alta(Consorcio consorcio)
        {
            ctxConsorcio.Consorcio.Add(consorcio);
            ctxConsorcio.SaveChanges();
        }

        public List<Consorcio> ObtenerTodos(int id)
        {
            List<Consorcio> todosLosConsorcios = (from consorciobd in ctxConsorcio.Consorcio
                                                  where consorciobd.Usuario.IdUsuario == id
                                                  orderby consorciobd.Nombre
                                                  select consorciobd).ToList();
            return todosLosConsorcios;
        }

        public Consorcio ObtenerPorId(int idConsorcio)
        {
            Consorcio consorcio;
            consorcio = ctxConsorcio.Consorcio.Find(idConsorcio);
            return consorcio;
        }

        public void Eliminar(int idConsorcio)
        {
            Consorcio consorcio = ObtenerPorId(idConsorcio);
            if (consorcio != null)
            {
                ctxConsorcio.SaveChanges();
            }
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
            ctxConsorcio.SaveChanges();
        }

        public void EliminarConsorcio(int idConsorcio)
        {
            Consorcio consorcio = ctxConsorcio.Consorcio.Find(idConsorcio);
            ctxConsorcio.Consorcio.Remove(consorcio);
            ctxConsorcio.SaveChanges();
        }
    }
}