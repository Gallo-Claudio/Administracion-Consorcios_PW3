using System.Collections.Generic;

namespace Servicios
{
    public interface IServicios<J>
    {
        List<J> Listar();

        void Eliminar(int id);

        J Buscar(int id);

    }
}