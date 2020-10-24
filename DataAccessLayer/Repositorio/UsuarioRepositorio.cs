using DataAccessLayer.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositorio
{
    public class UsuarioRepositorio
    {
        ContextoEntities ctxUsuario;

        public UsuarioRepositorio(ContextoEntities contexto)
        {
            ctxUsuario = contexto;
        }

        public void Alta(Usuario nuevoUsuario)
        {
            ctxUsuario.Usuario.Add(nuevoUsuario);
            ctxUsuario.SaveChanges();
        }

        public Usuario BuscaPorMail(string Email)
        {
            Usuario usuario = (from usuariobd in ctxUsuario.Usuario
                               where usuariobd.Email == Email
                               select usuariobd).FirstOrDefault();
            return usuario;
        }
    }
}
