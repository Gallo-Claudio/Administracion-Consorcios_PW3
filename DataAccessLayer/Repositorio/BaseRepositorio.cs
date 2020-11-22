using DataAccessLayer.Modelos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositorio
{
    public class BaseRepositorio<T> : IRepositorio<T> where T : class
    {
        protected ContextoEntities ctx;
        protected DbSet<T> dbSet;

        public BaseRepositorio(ContextoEntities contexto)
        {
            ctx = contexto;
            dbSet = ctx.Set<T>();
        }

        public void Alta(T t)
        {
            dbSet.Add(t);
            ctx.SaveChanges();
        }

        public void Eliminar(int t)
        {
            T objt = dbSet.Find(t);
            dbSet.Remove(objt);
            ctx.SaveChanges();
        }

        public T ObtenerPorId(int t)
        {
            T objt;
            objt = dbSet.Find(t);
            return objt;
        }

        public List<T> ObtenerTodos()
        {
            List<T> objt = dbSet.ToList();
            return objt;
        }
    }
}
