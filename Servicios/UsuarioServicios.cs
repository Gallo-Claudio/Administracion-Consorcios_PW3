using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public static class UsuarioServicios
    {
        public static int UltimoIdRegistro()
        {
            int ultimoId = Hardcodeo.usuario.Last().IdUsuario;
            return ultimoId;
        }

        public static string BuscarNombre(string Email)
        {
            string Nombre = Hardcodeo.usuario.Find(n => n.Email == Email).Nombre;
            return Nombre;
        }
        
        public static int BuscarIdUsuario(string Email)
        {
            int IdUsuario = Hardcodeo.usuario.Find(i => i.Email == Email).IdUsuario;
            return IdUsuario;
        }
    }
}
