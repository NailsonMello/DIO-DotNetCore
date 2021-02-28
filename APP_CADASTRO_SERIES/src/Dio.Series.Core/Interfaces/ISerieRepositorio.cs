using Dio.Series.Core.Domain.Entities;
using System.Collections.Generic;

namespace Dio.Series.Core.Interfaces
{
    public interface ISerieRepositorio
    {
        void Atualiza(int id, Serie objeto);
        void Exclui(int id);
        void Insere(Serie objeto);
        List<Serie> Lista();
        int ProximoId();
        Serie RetornaPorId(int id);
    }
}
