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
    }
}
