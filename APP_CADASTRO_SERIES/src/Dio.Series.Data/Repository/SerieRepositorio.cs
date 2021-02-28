using Dio.Series.Core.Domain.Entities;
using Dio.Series.Core.Interfaces;
using System.Collections.Generic;

namespace Dio.Series.Data.Repository
{
    public class SerieRepositorio: ISerieRepositorio
    {
        private List<Serie> listaSerie = new List<Serie>();

        public void Atualiza(int id, Serie objeto)
        {
            listaSerie[id] = objeto;
        }

        public void Exclui(int id)
        {
            listaSerie[id].Excluir();
        }

        public void Insere(Serie objeto)
        {
            listaSerie.Add(objeto);
        }

        public List<Serie> Lista() => listaSerie;

        public int ProximoId() => listaSerie.Count;
    
        public Serie RetornaPorId(int id) => listaSerie[id];
    }
}
