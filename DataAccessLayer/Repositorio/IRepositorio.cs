using System.Collections.Generic;

namespace DataAccessLayer.Repositorio
{
    interface IRepositorio<T>
    {
        void Alta(T t);

        List<T> ObtenerTodos();

        T ObtenerPorId(int t);

        void Eliminar(int t);

    }
}