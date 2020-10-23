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

        public List<Consorcio> ObtenerTodos()
        {
            List<Consorcio> todosLosConsorcios = ctxConsorcio.Consorcio.ToList();
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

            ctxConsorcio.SaveChanges();
        }
    }
}