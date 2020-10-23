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
        ContextoEntities contexto = new ContextoEntities();

        public void Alta(Consorcio consorcio)
        {
            contexto.Consorcio.Add(consorcio);
            contexto.SaveChanges();
        }

        public List<Consorcio> ObtenerTodos()
        {
            List<Consorcio> todosLosConsorcios = contexto.Consorcio.ToList();
            return todosLosConsorcios;
        }

        public Consorcio ObtenerPorId(int idConsorcio)
        {
            Consorcio consorcio;
            consorcio = contexto.Consorcio.Find(idConsorcio);
            return consorcio;
        }

        public void Eliminar(int idConsorcio)
        {
            Consorcio consorcio = ObtenerPorId(idConsorcio);
            if (consorcio != null)
            {
                contexto.SaveChanges();
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

            contexto.SaveChanges();
        }
    }
}