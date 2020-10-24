using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

namespace Entidades_VM
{
    public class RedireccionUsuario_VM
    {
        public string Controlador { get; set; }

        public string Accion { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }        
    }
}