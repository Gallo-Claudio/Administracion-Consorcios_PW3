using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public static class ProvinciaServicio
    {
        public static List<Provincia> ListarProvincias()
        {
            return Hardcodeo.provincia;
        }

        public static Provincia BuscarProvincia (int id)
        {
            Provincia provinciaBuscada = Hardcodeo.provincia.Find(p => p.IdProvincia == id);
            return provinciaBuscada;
        }
    }
}