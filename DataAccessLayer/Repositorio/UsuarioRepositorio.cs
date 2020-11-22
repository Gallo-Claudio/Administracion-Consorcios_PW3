using DataAccessLayer.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositorio
{
    public class UsuarioRepositorio : BaseRepositorio<Usuario>
    {
        public UsuarioRepositorio(ContextoEntities contexto) : base(contexto)
        {
        }

        public Usuario BuscaPorMail(string Email)
        {
            Usuario usuario = (from usuariobd in dbSet
                               where usuariobd.Email == Email
                               select usuariobd).FirstOrDefault();
            return usuario;
        }
        //public Usuario BuscaPorId(int id) // <- BaseRepository
        //{
        //    Usuario usuario = (from usuariobd in dbSet
        //                       where usuariobd.IdUsuario == id
        //                       select usuariobd).FirstOrDefault();
        //    return usuario;
        //}

        public void UltimoLogin(Usuario usuarioActualiza)
        {
            usuarioActualiza.FechaUltLogin = DateTime.Now;
            ctx.SaveChanges();
        }
    }
}
